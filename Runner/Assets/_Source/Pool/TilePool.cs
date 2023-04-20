using Core;
using Service;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Pool
{
    public class TilePool<T> where T : MonoBehaviour
    {
        private List<T> _prefabs;
        private float _roadLength;
        private bool _autoExpand;
        private Vector3 _distance;
        private IRandomService<T> _randomService;

        private List<T> _pool;

        public TilePool(List<T> prefabs, float roadLength, bool autoExpand, Vector3 startPosition, int count, ServiceLocator serviceLocator)
        {
            _prefabs = prefabs;
            _roadLength = roadLength;
            _autoExpand = autoExpand;
            _distance = startPosition;

            serviceLocator.GetService(out IRandomService<T> randomService);
            _randomService = randomService;

            CreatePool(count);
        }

        public T GetFreeElement()
        {
            if (HasFreeElement(out T element))
                return element;

            if (_autoExpand)
                return CreateObject(true);

            throw new Exception("No free elements");
        }

        private void CreatePool(int count)
        {
            _pool = new List<T>();

            for (int i = 0; i < count; i++)
            {
                CreateObject(true);
                CreateObject();
            }
        }

        private T CreateObject(bool isActiveByDefault = false)
        {
            if(isActiveByDefault)
                _distance.z += _roadLength;

            T createdObject = GameObject.Instantiate(_randomService.GetRandomElement(_prefabs), _distance, new Quaternion());
            createdObject.gameObject.SetActive(isActiveByDefault);
            _pool.Add(createdObject);

            return createdObject;
        }

        private bool HasFreeElement(out T element)
        {
            List<T> unActivePool = new List<T>();

            for (int i = 0; i < _pool.Count; i++)
            {
                if (!_pool[i].gameObject.activeInHierarchy)
                    unActivePool.Add(_pool[i]);
            }

            if(unActivePool.Count != 0)
            {
                element = _randomService.GetRandomElement(unActivePool);
                element.transform.position = _distance;
                _distance.z += _roadLength;
                element.gameObject.SetActive(true);
                return true;
            }
            
            element = null;
            return false;
        }
    }
}