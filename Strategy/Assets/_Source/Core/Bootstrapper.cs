using Strategy;
using Template;
using UnityEngine;
using UnityEngine.UI;

public class Bootstrapper : MonoBehaviour
{
    [SerializeField] private Animator playerAnimator;
    [SerializeField] private Animator skeletonAnimator;
    [SerializeField] private Animator wizardAnimator;
    [SerializeField] private Animator neonAnimator;

    [SerializeField] private Button attackButtonType1;
    [SerializeField] private Button attackButtonType2;
    [SerializeField] private Button attackButtonType3;

    [SerializeField] private Color highlightColor;

    [SerializeField] private GameObject bulletPrefab;

    private PlayerController _playerController;
    private EnemyController _enemyController;

    void Start()
    {
        _playerController = new PlayerController(playerAnimator);
        _enemyController = new EnemyController(new Skeleton(skeletonAnimator, "Attack"), new Wizard(wizardAnimator, "Attack", bulletPrefab), new Neon(neonAnimator, "Attack"));

        new AttackTypeSwitcher(_playerController, _enemyController, highlightColor, attackButtonType1, attackButtonType2, attackButtonType3);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            _playerController.PerformAttack();
            _enemyController.Neon.DoAttack();
        }
    }
}