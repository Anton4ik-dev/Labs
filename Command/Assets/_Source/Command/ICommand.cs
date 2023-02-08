using UnityEngine;

namespace Command
{
    public interface ICommand
    {
        void Invoke(Vector3 position);
        void Undo();
    }
}