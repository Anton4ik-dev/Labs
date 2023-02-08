using System.Collections.Generic;
using UnityEngine;

namespace Command
{
    public class LeftClickCommand : ICommand
    {
        private List<Vector3> _positions;
        private Transform _character;

        public LeftClickCommand(Transform character)
        {
            _character = character;
            _positions = new List<Vector3>();
        }

        public void Invoke(Vector3 position)
        {
            position.z = 0;
            _positions.Add(_character.position);
            _character.position = position;
        }

        public void Undo()
        {
            if(_positions.Count > 0)
            {
                _character.position = _positions[_positions.Count - 1];
                _positions.RemoveAt(_positions.Count - 1);
            }
        }
    }
}