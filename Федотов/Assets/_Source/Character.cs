using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private float walkTime;

    private const string WALK_TRIGGER = "IsWalk";
    private const string ATTACK_TRIGGER = "IsAttack";

    public IEnumerator MoveCharacter(List<Hex> Way)
    {
        for (int i = 0; i < Way.Count; i++)
        {
            if (i == 4)
                break;
            transform.position = Way[i].transform.position;
            animator.SetTrigger(WALK_TRIGGER);
            yield return new WaitForSeconds(walkTime);
        }
        animator.SetTrigger(ATTACK_TRIGGER);
    }
}