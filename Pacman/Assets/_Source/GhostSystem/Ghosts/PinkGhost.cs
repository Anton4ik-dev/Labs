using UnityEngine;

namespace GhostSystem
{
    public class PinkGhost : AGhost
    {
        protected override void MoveGhost()
        {
            if(_isMovingToPoint)
                transform.position = Vector2.MoveTowards(transform.position, _pointToMoveFor, speed * Time.deltaTime);
            else
                transform.position += (Vector3)_direction * speed * Time.deltaTime;

            if (transform.position == _pointToMoveFor)
                _isMovingToPoint = false;
        }

        protected override void OnRotateTrigger(Collider2D collision)
        {
            _direction = collision.GetComponent<RotateTrigger>().GetRandomDirection();
            _pointToMoveFor = collision.transform.position;
            _isMovingToPoint = true;
        }
    }
}