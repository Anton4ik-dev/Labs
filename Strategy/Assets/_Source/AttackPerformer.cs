using Strategy;
using UnityEngine;
using UnityEngine.UI;

public class AttackPerformer : MonoBehaviour
{
    [SerializeField] private Animator animator;

    [SerializeField] private Button attackButton1;
    [SerializeField] private Button attackButton2;
    [SerializeField] private Button attackButton3;

    [SerializeField] private Color highlightColor;

    private PlayerAnimatorController _playerAnimatorController;

    private IAttackStrategy _attack1;
    private IAttackStrategy _attack2;
    private IAttackStrategy _attack3;

    private void Start()
    {
        _playerAnimatorController = new PlayerAnimatorController(animator);
        _attack1 = new Attack1();
        _attack2 = new Attack2();
        _attack3 = new Attack3();

        attackButton1.onClick.AddListener(SetAttack1);
        attackButton2.onClick.AddListener(SetAttack2);
        attackButton3.onClick.AddListener(SetAttack3);
        SetAttack1();
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Q))
        {
            _playerAnimatorController.PerformAttack();
        }
    }

    private void SetAttack1()
    {
        Decolor();
        attackButton1.image.color = highlightColor;

        _playerAnimatorController.SetStrategy(_attack1);
    }

    private void SetAttack2()
    {
        Decolor();
        attackButton2.image.color = highlightColor;

        _playerAnimatorController.SetStrategy(_attack2);
    }

    private void SetAttack3()
    {
        Decolor();
        attackButton3.image.color = highlightColor;

        _playerAnimatorController.SetStrategy(_attack3);
    }

    private void Decolor()
    {
        attackButton1.image.color = Color.white;
        attackButton2.image.color = Color.white;
        attackButton3.image.color = Color.white;
    }
}