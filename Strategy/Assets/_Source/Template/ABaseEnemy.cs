using UnityEngine;

namespace Template
{
    public abstract class ABaseEnemy
    {
        public Animator Animator { get; protected set; }
        public abstract void DoAttack();
    }
}