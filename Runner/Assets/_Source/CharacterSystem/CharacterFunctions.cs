using Core;
using Pool;
using UnityEngine;
using Zenject;

namespace CharacterSystem
{
    public class CharacterFunctions
    {
        private Transform _transform;
        private float _speed;
        private float _jumpForce;
        private BulletPool _bulletPool;

        public CharacterFunctions([Inject(Id = BindId.COUNT_ID)] Transform transform, [Inject(Id = BindId.SPEED_ID)] float speed, [Inject(Id = BindId.JUMP_ID)] float jumpForce, BulletPool bulletPool)
        {
            _transform = transform;
            _speed = speed;
            _jumpForce = jumpForce;
            _bulletPool = bulletPool;
        }

        public void Run()
        {
            _transform.position += Vector3.forward * _speed;
        }

        public void Jump()
        {
            _transform.position += Vector3.up * _jumpForce;
        }

        public void Slide()
        {
            _transform.position += Vector3.down * _jumpForce;
        }

        public void Right()
        {
            if(_transform.position.x < 1)
                _transform.position += Vector3.right;
        }

        public void Left()
        {
            if (_transform.position.x > -1)
                _transform.position += Vector3.left;
        }

        public void Shoot()
        {
            _bulletPool?.GetFreeElement();
        }
    }
}