using Pool;
using Service;
using UnityEngine;
using Zenject;

namespace CharacterSystem
{
    public class Character : MonoBehaviour
    {
        [SerializeField] private LayerMask triggerLayer;
        [SerializeField] private LayerMask envLayer;

        private TileSOPool _tileSOPool;

        private void OnCollisionEnter(Collision collision)
        {
            if (LayerService.CheckLayersEquality(collision.gameObject.layer, envLayer))
            {
                RestartService.RestartGame();
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            if (LayerService.CheckLayersEquality(other.gameObject.layer, triggerLayer))
            {
                _tileSOPool?.GetFreeElement();
                other.gameObject.SetActive(false);
            }
        }

        [Inject]
        public void Construct(TileSOPool tileSOPool)
        {
            _tileSOPool = tileSOPool;
        }
    }
}