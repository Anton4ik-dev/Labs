using CharacterSystem;
using Core;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Pool
{
    public class BulletPool
    {
        private bool _autoExpand;
        private Transform _container;
        private List<Bullet> _pool;
        private Bullet.Factory _bulletFactory;

        public BulletPool(Bullet.Factory bulletFactory, [Inject(Id = BindId.BULLET_ID)] bool autoExpand, [Inject(Id = BindId.BULLET_ID)] Transform container, [Inject(Id = BindId.BULLET_ID)] int count)
        {
            _bulletFactory = bulletFactory;
            _autoExpand = autoExpand;
            _container = container;

            CreatePool(count);
        }

        public Bullet GetFreeElement()
        {
            if (HasFreeElement(out Bullet element))
                return element;

            if (_autoExpand)
                return CreateObject(true);

            throw new System.Exception("No free elements");
        }

        private void CreatePool(int count)
        {
            _pool = new List<Bullet>();

            for (int i = 0; i < count; i++)
                CreateObject();
        }

        private Bullet CreateObject(bool isActiveByDefault = false)
        {
            Bullet createdObject = _bulletFactory.Create();
            createdObject.gameObject.SetActive(isActiveByDefault);
            _pool.Add(createdObject);
            return createdObject;
        }

        private bool HasFreeElement(out Bullet element)
        {
            for (int i = 0; i < _pool.Count; i++)
            {
                if (!_pool[i].gameObject.activeInHierarchy)
                {
                    element = _pool[i];
                    _pool[i].transform.position = _container.position;
                    _pool[i].transform.rotation = _container.rotation;
                    _pool[i].TurnOn();
                    return true;
                }
            }

            element = null;
            return false;
        }
    }
}