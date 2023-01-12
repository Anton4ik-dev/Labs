using Strategy;
using UnityEngine;

public class PlayerAnimatorController
{
    private Animator _animator;
    private IAttackStrategy _attackType;

    public PlayerAnimatorController(Animator animator)
    {
        _animator = animator;
    }

    public void SetStrategy(IAttackStrategy attackType)
    {
        _attackType = attackType;
    }

    public void PerformAttack()
    {
        _attackType.DoAttack(_animator);
    }

}