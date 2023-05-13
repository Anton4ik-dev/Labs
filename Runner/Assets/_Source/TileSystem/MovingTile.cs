using UnityEngine;

namespace TileSystem
{
    public class MovingTile : MonoBehaviour
    {
        [SerializeField] private float speed;
        [SerializeField] private Transform parentTransform;

        private Vector3 _startPos;

        private void Start()
        {
            _startPos = transform.position;
        }

        private void Update()
        {
            transform.position += Vector3.back * speed;
        }

        private void OnDisable()
        {
            Vector3 newVector = new Vector3(_startPos.x, _startPos.y, parentTransform.position.z);
            transform.position = newVector;
        }
    }
}