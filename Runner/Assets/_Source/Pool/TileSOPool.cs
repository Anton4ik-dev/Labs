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

            throw new Exception("No free elements");
        }

        private void CreatePool(int count)
        {
            _poolSO = new Dictionary<int, List<Tile>>();

            for (int i = 0; i < count; i++)
                CreateObject(true);
        }

        private Tile CreateObject(bool isActiveByDefault = false, TileSO tileSO = null)
        {
            if(isActiveByDefault)
                _distance.z += _roadLength;

            if(tileSO == null)
                tileSO = _randomService.GetRandomSO(_prefabs);

            int tileSOID = tileSO.GetInstanceID();
            Tile createdObject = GameObject.Instantiate(tileSO.TilePrefab, _distance, new Quaternion());
            createdObject.gameObject.SetActive(isActiveByDefault);

            if (_poolSO.ContainsKey(tileSOID))
                _poolSO[tileSOID].Add(createdObject);
            else
                _poolSO.Add(tileSOID, new List<Tile> { createdObject });

            return createdObject;
        }

        private bool HasFreeElement(out Tile element)
        {
            TileSO tileSO = _randomService.GetRandomSO();
            int randomSOID = tileSO.GetInstanceID();

            if (_poolSO.ContainsKey(randomSOID))
            {
                for (int i = 0; i < _poolSO[randomSOID].Count; i++)
                {
                    element = _poolSO[randomSOID][i];
                    if (!element.gameObject.activeInHierarchy)
                    {
                        _distance.z += _roadLength;
                        element.transform.position = _distance;
                        element.gameObject.SetActive(true);
                        return true;
                    }
                }
            }

            if(_autoExpand)
            {
                element = CreateObject(true, tileSO);
                return true;
            }

            element = null;
            return false;
        }
    }
}