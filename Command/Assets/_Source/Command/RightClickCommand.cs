using UnityEngine;

namespace Command
{
    public class RightClickCommand : ICommand
    {
        private GameObject _prefab;

        public RightClickCommand(GameObject prefab)
        {
            _prefab = prefab;
        }

        public void Invoke(Vector3 position)
        {
            position.z = 0;
            GameObject.Instantiate(_prefab, position, Quaternion.identity);
        }
    }
}