using UnityEngine;

namespace Enemies
{
    public abstract class AGhost : MonoBehaviour, IObserver
    {
        [SerializeField] protected float speed;
        [SerializeField] protected LayerMask rotateTriggerLayer;

        protected Vector2 _direction;
        protected Vector3 _pointToMoveFor;
        protected bool _isMovingToPoint;

        private int _rotateTriggerNum;

        private void Start()
        {
            _rotateTriggerNum = (int)Mathf.Log(rotateTriggerLayer.value, 2);
        }

        private void Update()
        {
            MoveGhost();
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.layer == _rotateTriggerNum)
            {
                OnRotateTrigger(collision);
            }
        }

        public void UpdateObserver()
        {

        }

        protected abstract void MoveGhost();
        protected abstract void OnRotateTrigger(Collider2D collision);
    }
}