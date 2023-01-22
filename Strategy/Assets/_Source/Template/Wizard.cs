using UnityEngine;

namespace Template
{
    public class Wizard : ABaseEnemy
    {
        public override Animator Animator { get; set; }
        public override int ID { get; set; }
        private GameObject _bulletPrefab;

        public Wizard(Animator animator, string triigerName, GameObject bulletPrefab)
        {
            ID = Animator.StringToHash(triigerName);
            Animator = animator;
            _bulletPrefab = bulletPrefab;
        }

        public override void DoAttack()
        {
            Animator.SetTrigger(ID);
            //GameObject.Instantiate(_bulletPrefab);
        }
    }
}