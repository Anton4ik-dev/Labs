using UnityEngine;

namespace Strategy
{
    public class PlayerController
    {
        private Animator _playerAnimator;
        private IAttackStrategy _attackType;

        public PlayerController(Animator playerAnimator)
        {
            _playerAnimator = playerAnimator;
        }

        public void SetStrategy(IAttackStrategy attackType)
        {
            _attackType = attackType;
        }

        public void PerformAttack()
        {
            _attackType.DoAttack(_playerAnimator);
        }

    }
}