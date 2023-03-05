using UnityEngine;

namespace GhostSystem
{
    public class RedGhost : PinkGhost
    {
        [SerializeField] private Transform pacmanTransform;

        private bool _isAgro;

        protected override void MoveGhost()
        {
            if(!_isAgro)
            {
                if (_isMovingToPoint)
                    transform.position = Vector2.MoveTowards(transform.position, _pointToMoveFor, speed * Time.deltaTime);
                else
                    transform.position += (Vector3)_direction * speed * Time.deltaTime;

                if (transform.position == _pointToMoveFor)
                    _isMovingToPoint = false;
            }
            else
                transform.position = Vector2.MoveTowards(transform.position, pacmanTransform.position, speed * Time.deltaTime);
        }

        public void ChangeMode()
        {
            _isAgro = !_isAgro;
        }
    }
}