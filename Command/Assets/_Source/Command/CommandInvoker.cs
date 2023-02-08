using UnityEngine;

namespace Command
{
    public class CommandInvoker
    {
        private ICommand _rightClickCommand;
        private ICommand _leftClickCommand;

        public CommandInvoker(GameObject prefab, Transform character)
        {
            _rightClickCommand = new RightClickCommand(prefab);
            _leftClickCommand = new LeftClickCommand(character);
        }

        public void Execute(ClickType commandType, Vector3 position)
        {
            if (commandType == ClickType.LeftClick)
                _leftClickCommand.Invoke(position);
            else if (commandType == ClickType.RightClick)
                _rightClickCommand.Invoke(position);
        }
    }
}