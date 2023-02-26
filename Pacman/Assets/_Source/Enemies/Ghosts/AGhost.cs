using DG.Tweening;
using MV;
using UnityEngine;

namespace Enemies
{
    public abstract class AGhost : MonoBehaviour, IObserver
    {
        [SerializeField] protected float speed;
        [SerializeField] private float chillTime;
        [SerializeField] private Transform spawnPosition;
        [SerializeField] private BonusObservable bonusObservable;
        [SerializeField] private LayerMask rotateTriggerLayer;

        [Header("VisualSettings")]
        [SerializeField] private SpriteRenderer sprite;
        [SerializeField] private Color baseColor;
        [SerializeField] private Color onBonusColor;
        [SerializeField] private Color damagedColor;

        protected Vector2 _direction;
        protected Vector3 _pointToMoveFor;
        protected bool _isMovingToPoint;
        private bool isDamaged;

        private int _rotateTriggerNum;
        private float remainTime;

        private void Start()
        {
            _rotateTriggerNum = (int)Mathf.Log(rotateTriggerLayer.value, 2);
            bonusObservable.AddObserver(this);
        }

        private void Update()
        {
            if(isDamaged)
            {
                remainTime += Time.deltaTime;
                if(remainTime >= chillTime)
                {
                    remainTime = 0;
                    sprite.DOColor(baseColor, .1f);
                    isDamaged = false;
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
        }

        public void UpdateObserver(bool toActivate)
        {
            if(toActivate)
                sprite.DOColor(onBonusColor, .1f);
            else if (!isDamaged && !toActivate)
                sprite.DOColor(baseColor, .1f);
        }

        public void TakeDamage(int damagedEnemies)
        {
            if(!isDamaged)
            {
                isDamaged = true;
                sprite.DOColor(damagedColor, .1f);
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