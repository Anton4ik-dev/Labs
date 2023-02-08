using System.Collections.Generic;
using UnityEngine;

namespace Command
{
    public class RightClickCommand : ICommand
    {
        private List<GameObject> _prefabs;
        private List<Vector3> _positions;
        private GameObject _prefab;

        public int AmountOfCommands { get => _positions.Count; private set { } }

        public RightClickCommand(GameObject prefab)
        {
            _prefab = prefab;
            _prefabs = new List<GameObject>();
            _positions = new List<Vector3>();
        }

        public void Invoke(Vector3 position)
        {
            position.z = 0;
            _positions.Add(position);
        }

        public void Invoke()
        {
            for (int i = 0; i < _positions.Count; i++)
            {
                _prefabs.Add(GameObject.Instantiate(_prefab, _positions[i], Quaternion.identity));
            }

            _positions.Clear();
        }
        
        public void Undo()
        {
            if(_prefabs.Count > 0)
            {
                GameObject.Destroy(_prefabs[_prefabs.Count - 1]);
                _prefabs.RemoveAt(_prefabs.Count - 1);
            }
        }
    }
}