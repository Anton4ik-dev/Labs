using System.Collections.Generic;
using UnityEngine;

namespace Command
{
    public class CommandInvoker
    {
        private const int CAPACITY = 10;

        private List<ICommand> _commandQueue;

        private ICommand _rightClickCommand;
        private ICommand _leftClickCommand;

        public CommandInvoker(GameObject prefab, Transform character)
        {
            _rightClickCommand = new RightClickCommand(prefab);
            _leftClickCommand = new LeftClickCommand(character);

            _commandQueue = new List<ICommand>();
        }

        public void Execute(ClickType commandType, Vector3 position)
        {
            if (commandType == ClickType.LeftClick)
            {
                _leftClickCommand.Invoke(position);
                _commandQueue.Add(_leftClickCommand);
            }
            else if (commandType == ClickType.RightClick)
            {
                _rightClickCommand.Invoke(position);
            }

            if (_commandQueue.Count > CAPACITY)
                _commandQueue.RemoveAt(0);
        }

        public void ExecuteRightClickCommands()
        {
            RightClickCommand rc = (RightClickCommand)_rightClickCommand;
            for (int i = 0; i < rc.AmountOfCommands; i++)
            {
                _commandQueue.Add(_rightClickCommand);

                if (_commandQueue.Count > CAPACITY)
                    _commandQueue.RemoveAt(0);
            }
            rc.Invoke();
        }

        public void Undo()
        {
            if (_commandQueue.Count > 0)
            {
                _commandQueue[_commandQueue.Count - 1].Undo();
                _commandQueue.RemoveAt(_commandQueue.Count - 1);
            }
        }
    }
}