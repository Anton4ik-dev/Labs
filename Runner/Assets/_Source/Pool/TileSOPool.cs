using Core;
using Service;
using System;
using System.Collections.Generic;
using TileSystem;
using UnityEngine;

namespace Pool
{
    public class TileSOPool
    {
        private List<TileSO> _prefabs;
        private float _roadLength;
        private bool _autoExpand;
        private Vector3 _distance;
        private ISpecialRandomService _randomService;

        private List<Tile> _pool;
        private Dictionary<int, List<Tile>> _poolSO;

        public TileSOPool(List<TileSO> prefabs, float roadLength, bool autoExpand, Vector3 startPosition, int count, ServiceLocator serviceLocator)
        {
            _prefabs = prefabs;
            _roadLength = roadLength;
            _autoExpand = autoExpand;
            _distance = startPosition;

            serviceLocator.GetService(out ISpecialRandomService randomService);
            _randomService = randomService;

            CreatePool(count);
        }

        public Tile GetFreeElement()
        {
            if (HasFreeElement(out Tile element))
                return element;

            if (_autoExpand)
                return CreateObject(true);

            throw new Exception("No free elements");
        }

        private void CreatePool(int count)
        {
            _pool = new List<Tile>();

            for (int i = 0; i < count; i++)
            {
                CreateObject(true);
                CreateObject();
            }
        }

        private Tile CreateObject(bool isActiveByDefault = false)
        {
            if(isActiveByDefault)
                _distance.z += _roadLength;

            Tile createdObject = GameObject.Instantiate(_randomService.GetRandomElement(_prefabs), _distance, new Quaternion());
            createdObject.gameObject.SetActive(isActiveByDefault);
            _pool.Add(createdObject);

            return createdObject;
        }

        private bool HasFreeElement(out Tile element)
        {
            List<Tile> unActivePool = new List<Tile>();

            for (int i = 0; i < _pool.Count; i++)
            {
                if (!_pool[i].gameObject.activeInHierarchy)
                    unActivePool.Add(_pool[i]);
            }

            if(unActivePool.Count != 0)
            {
                element = _randomService.GetRandomElement();
                if(_pool.Contains(element))
                {
                    element.transform.position = _distance;
                    _distance.z += _roadLength;
                    element.gameObject.SetActive(true);
                    return true;
                }
            }
            
            element = null;
            return false;
        }
    }
}