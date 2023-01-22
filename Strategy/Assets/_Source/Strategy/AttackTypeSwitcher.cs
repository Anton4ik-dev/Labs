using Template;
using UnityEngine;
using UnityEngine.UI;

namespace Strategy
{
    public class AttackTypeSwitcher
    {
        private Button _attackButtonType1;
        private Button _attackButtonType2;
        private Button _attackButtonType3;

        private PlayerController _playerController;
        private EnemyController _enemyController;

        private Color _highlightColor;

        public AttackTypeSwitcher(PlayerController playerController, EnemyController enemyController, Color highlightColor,
            Button attackButtonType1, Button attackButtonType2, Button attackButtonType3)
        {
            _playerController = playerController;
            _enemyController = enemyController;

            _attackButtonType1 = attackButtonType1;
            _attackButtonType2 = attackButtonType2;
            _attackButtonType3 = attackButtonType3;

            _highlightColor = highlightColor;

            BindButtons();
        }

        private void SetAttack(IAttackStrategy attackType, Button attackButtonType, ABaseEnemy enemyType)
        {
            Decolor();
            attackButtonType.image.color = _highlightColor;

            _playerController.SetStrategy(attackType);
            _enemyController.TurnOnEnemy(enemyType);
        }

        private void Decolor()
        {
            _attackButtonType1.image.color = Color.white;
            _attackButtonType2.image.color = Color.white;
            _attackButtonType3.image.color = Color.white;
        }

        private void BindButtons()
        {
            _attackButtonType1.onClick.AddListener(() => SetAttack(new AttackType1("Attack1"), _attackButtonType1, _enemyController.Skeleton));
            _attackButtonType2.onClick.AddListener(() => SetAttack(new AttackType2("Attack2"), _attackButtonType2, _enemyController.Wizard));
            _attackButtonType3.onClick.AddListener(() => SetAttack(new AttackType3("Attack3"), _attackButtonType3, _enemyController.Neon));

            _attackButtonType1.onClick.Invoke();
        }
    }
}