using Bonuses;
using DG.Tweening;
using MV;
using UnityEngine;

namespace GhostSystem
{
    public abstract class AGhost : MonoBehaviour, IObserver
    {
        [Header("MechanicSettings")]
        [SerializeField] protected float speed;
        [SerializeField] private float afkTime;
        [SerializeField] private Transform spawnPosition;
        [SerializeField] private BonusObservable bonusObservable;
        [SerializeField] private LayerMask rotateTriggerLayer;
        [SerializeField] private LayerMask teleportLayer;

        [Header("VisualSettings")]
        [SerializeField] private SpriteRenderer ghostSprite;
        [SerializeField] private Color baseColor;
        [SerializeField] private Color onBonusColor;
        [SerializeField] private Color damagedColor;

        protected Vector2 _direction;
        protected Vector3 _pointToMoveFor;
        protected bool _isMovingToPoint;
        private bool _isDamaged;

        private int _rotateTriggerNum;
        private int _teleportLayerNum;
        private float _remainTime;

        private void Start()
        {
            _rotateTriggerNum = (int)Mathf.Log(rotateTriggerLayer.value, 2);
            _teleportLayerNum = (int)Mathf.Log(teleportLayer.value, 2);
            bonusObservable.AddObserver(this);
        }

        private void Update()
        {
            if(_isDamaged)
            {
                _remainTime += Time.deltaTime;
                if(_remainTime >= afkTime)
                {
                    _remainTime = 0;
                    ghostSprite.DOColor(baseColor, .1f);
                    _isDamaged = false;
                }
            }
            else
                MoveGhost();
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.layer == _rotateTriggerNum)
            {
                OnRotateTrigger(collision);
            }
            else if (collision.gameObject.layer == _teleportLayerNum)
            {
                collision.gameObject.GetComponent<TeleportPoint>().Teleport(gameObject);
            }
        }

        public void UpdateObserver(bool toActivate)
        {
            if(toActivate)
                ghostSprite.DOColor(onBonusColor, .1f);
            else if (!_isDamaged && !toActivate)
                ghostSprite.DOColor(baseColor, .1f);
        }

        public void TakeDamage(int damagedEnemies)
        {
            if(!_isDamaged)
            {
                _isDamaged = true;
                ghostSprite.DOColor(damagedColor, .1f);
                Teleport();
                Score.OnScoreChangeForEnemies(damagedEnemies);
            }
        }

        public void Teleport()
        {
            transform.position = spawnPosition.position;
        }

        protected abstract void MoveGhost();
        protected abstract void OnRotateTrigger(Collider2D collision);
    }
}