using UnityEngine;

namespace Template
{
    public abstract class ABaseEnemy
    {
        public abstract Animator Animator { get; set; }
        public abstract int ID { get; set; }
        public abstract void DoAttack();
    }
}