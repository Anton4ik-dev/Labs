using Strategy;
using Template;
using UnityEngine;
using UnityEngine.UI;

namespace Core
{
    public class Bootstrapper : MonoBehaviour
    {
        [SerializeField] private InputListener inputListener;

        [SerializeField] private Animator playerAnimator;
        [SerializeField] private Animator skeletonAnimator;
        [SerializeField] private Animator wizardAnimator;
        [SerializeField] private Animator neonAnimator;

        [SerializeField] private Button attackButtonType1;
        [SerializeField] private Button attackButtonType2;
        [SerializeField] private Button attackButtonType3;

        [SerializeField] private Color highlightColor;

        [SerializeField] private GameObject bulletPrefab;
        [SerializeField] private Transform spawnPoint;
        [SerializeField] private float time;

        private PlayerController _playerController;
        private EnemyController _enemyController;

        void Start()
        {
            _playerController = new PlayerController(playerAnimator);
            _enemyController = new EnemyController(new Skeleton(skeletonAnimator, "Attack"),
                new Wizard(wizardAnimator, "Attack", bulletPrefab, spawnPoint, time),
                new Neon(neonAnimator, "Attack"));
            inputListener.Construct(_playerController, _enemyController);
            new AttackTypeSwitcher(_playerController, _enemyController, highlightColor, attackButtonType1, attackButtonType2, attackButtonType3);
        }
    }
}