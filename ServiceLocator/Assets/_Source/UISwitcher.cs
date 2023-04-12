using System;
using System.Collections.Generic;
using UnityEngine;

namespace UISystem
{
    public class UISwitcher
    {
        public Dictionary<Type, IUIState> states;
        private IUIState _activeState;

        public void Construct(IUIState mainMenuState, IUIState additionalMenuState)
        {
            states = new Dictionary<Type, IUIState>();

            states.Add(typeof(MainScreen), mainMenuState);
            states.Add(typeof(AdditionalScreen), additionalMenuState);
        }

        private void ExitState()
        {
            _activeState?.Exit();
        }

        private void EnterState(IUIState newState)
        {
            _activeState = newState;
            _activeState.Enter();
        }

        public void ChangeState(IUIState newState)
        {
            ExitState();
            EnterState(newState);
        }
    }
}