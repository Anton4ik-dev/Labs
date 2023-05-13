using UnityEngine;

namespace Template
{
    public class Wizard : ABaseEnemy
    {
        private readonly int _id;
        private GameObject _bulletPrefab;
        private Transform _spawnpoint;
        private float _saveTime;
        private float _time;

        public Wizard(Animator animator, string triigerName, GameObject bulletPrefab, Transform spawnPoint, float time)
        {
            _id = Animator.StringToHash(triigerName);
            Animator = animator;
            _bulletPrefab = bulletPrefab;
            _spawnpoint = spawnPoint;
            _saveTime = time;
        }

        public override void DoAttack()
        {
            if(_time <= 0)
            {
                Animator.SetTrigger(_id);
                GameObject.Instantiate(_bulletPrefab, _spawnpoint.position, Quaternion.identity);
                _time = _saveTime;
            }
            _time -= Time.deltaTime;
        }
    }
}