using UnityEngine;

namespace Command
{
    public class LeftClickCommand : ICommand
    {
        private Transform _character;

        public LeftClickCommand(Transform character)
        {
            _character = character;
        }

        public void Invoke(Vector3 position)
        {
            position.z = 0;
            _character.position = position;
        }
    }
}