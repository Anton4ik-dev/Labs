using UnityEngine;

namespace GhostSystem
{
    public class RotateTrigger : MonoBehaviour
    {
        [SerializeField] private Vector2[] AvailableDirections;

        public Vector3 GetRandomDirection()
        {
            return AvailableDirections[Random.Range(0, AvailableDirections.Length)];
        }

        public Vector3 GetDirectionByNumber(int numOfDirection)
        {
            return AvailableDirections[numOfDirection];
        }
    }
}