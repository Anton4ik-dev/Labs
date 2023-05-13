using Strategy;
using Template;
using UnityEngine;

namespace Core
{
    public class InputListener : MonoBehaviour
    {
        private PlayerController _playerController;
        private EnemyController _enemyController;

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Q))
            {
                _playerController.PerformAttack();
                _enemyController.Neon.DoAttack();
            }

            if (_enemyController.Wizard.Animator.gameObject.activeSelf)
                _enemyController.Wizard.DoAttack();
        }

        public void Construct(PlayerController playerController, EnemyController enemyController)
        {
            _playerController = playerController;
            _enemyController = enemyController;
        }
    }
}