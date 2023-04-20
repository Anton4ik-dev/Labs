using System.Collections.Generic;
using UnityEngine;

namespace Service
{
    public class RandomService<T> : IRandomService<T> where T : MonoBehaviour
    {
        private T _newPrefab;
        private T _lastPrefab;

        public T GetRandomElement(List<T> prefabs) 
        {
            do
                _newPrefab = prefabs[Random.Range(0, prefabs.Count)];
            while (_newPrefab == _lastPrefab);

            _lastPrefab = _newPrefab;
            return _lastPrefab;
        }
    }
}