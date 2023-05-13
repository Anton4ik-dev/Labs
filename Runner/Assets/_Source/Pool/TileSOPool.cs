using Core;
using Service;
using System;
using System.Collections.Generic;
using TileSystem;
using UnityEngine;
using Zenject;

namespace Pool
{
    public class TileSOPool
    {
        private List<TileSO> _prefabs;
        private float _roadLength;
        private bool _autoExpand;
        private Vector3 _distance;
        private SpecialRandomService _randomService;
        
        private Dictionary<int, List<GameObject>> _poolSO;

        public TileSOPool(List<TileSO> prefabs, [Inject(Id = BindId.COUNT_ID)] float roadLength, [Inject(Id = BindId.TILE_ID)] bool autoExpand, Vector3 startPosition, [Inject(Id = BindId.TILE_ID)] int count, SpecialRandomService randomService)
        {
            _prefabs = prefabs;
            _roadLength = roadLength;
            _autoExpand = autoExpand;
            _distance = startPosition;
            _randomService = randomService;

            CreatePool(count);
        }

        public GameObject GetFreeElement()
        {
            if (HasFreeElement(out GameObject element))
                return element;

            throw new Exception("No free elements");
        }

        private void CreatePool(int count)
        {
            _poolSO = new Dictionary<int, List<GameObject>>();

            for (int i = 0; i < count; i++)
                CreateObject(true);
        }

        private GameObject CreateObject(bool isActiveByDefault = false, TileSO tileSO = null)
        {
            if(isActiveByDefault)
                _distance.z += _roadLength;

            if(tileSO == null)
                tileSO = _randomService.GetRandomSO(_prefabs);

            int tileSOID = tileSO.GetInstanceID();
            GameObject createdObject = GameObject.Instantiate(tileSO.TilePrefab, _distance, new Quaternion());
            createdObject.gameObject.SetActive(isActiveByDefault);

            if (_poolSO.ContainsKey(tileSOID))
                _poolSO[tileSOID].Add(createdObject);
            else
                _poolSO.Add(tileSOID, new List<GameObject> { createdObject });

            return createdObject;
        }

        private bool HasFreeElement(out GameObject element)
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