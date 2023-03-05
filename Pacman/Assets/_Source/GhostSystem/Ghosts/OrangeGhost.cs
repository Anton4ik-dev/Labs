using UnityEngine;

namespace GhostSystem
{
    public class OrangeGhost : PinkGhost
    {
        [SerializeField] private int[] WayPoints;

        private int wayNumber;

        protected override void OnRotateTrigger(Collider2D collision)
        {
            _direction = collision.GetComponent<RotateTrigger>().GetDirectionByNumber(WayPoints[wayNumber++]);
            _pointToMoveFor = collision.transform.position;
            _isMovingToPoint = true;

            if (wayNumber == WayPoints.Length)
                wayNumber = 0;
        }
    }
}