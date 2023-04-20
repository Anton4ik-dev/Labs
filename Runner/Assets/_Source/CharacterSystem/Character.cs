using Core;
using Pool;
using Service;
using TileSystem;
using UnityEngine;

namespace CharacterSystem
{
    public class Character : MonoBehaviour
    {
        [SerializeField] private float speed;
        [SerializeField] private LayerMask triggerLayer;

        private TilePool<Tile> _tilePool;
        private TileSOPool _tileSOPool;
        private ILayerService _layerService;

        private void OnTriggerEnter(Collider other)
        {
            if (_layerService.CheckLayersEquality(other.gameObject.layer, triggerLayer))
            {
                _tilePool?.GetFreeElement();
                _tileSOPool?.GetFreeElement();
                other.gameObject.SetActive(false);
            }
        }

        private void Update()
        {
            transform.position += Vector3.forward * speed;
        }

        public void Construct(TilePool<Tile> tilePool, ServiceLocator serviceLocator)
        {
            _tilePool = tilePool;

            serviceLocator.GetService(out ILayerService layerService);
            _layerService = layerService;
        }

        public void Construct(TileSOPool tileSOPool, ServiceLocator serviceLocator)
        {
            _tileSOPool = tileSOPool;

            serviceLocator.GetService(out ILayerService layerService);
            _layerService = layerService;
        }
    }
}