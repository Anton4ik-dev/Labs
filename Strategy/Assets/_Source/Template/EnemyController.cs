namespace Template
{
    public class EnemyController
    {
        public Skeleton Skeleton { get; private set; }
        public Wizard Wizard { get; private set; }
        public Neon Neon { get; private set; }

        public EnemyController(Skeleton skeleton, Wizard wizard, Neon neon)
        {
            Skeleton = skeleton;
            Wizard = wizard;
            Neon = neon;
        }

        public void TurnOnEnemy(ABaseEnemy enemy)
        {
            TurnOffEnemies();
            enemy.Animator.gameObject.SetActive(true);

            if (enemy != Neon)
                enemy.DoAttack();
        }

        private void TurnOffEnemies()
        {
            Skeleton.Animator.gameObject.SetActive(false);
            Wizard.Animator.gameObject.SetActive(false);
            Neon.Animator.gameObject.SetActive(false);
        }
    }
}