using System;
using System.Collections.Generic;
using Zenject;

namespace UISystem
{
    public class UISwitcher : IUISwitcher
    {
        public Dictionary<Type, AUIState> States { get; set; }
        private AUIState _activeState;

        [Inject]
        public UISwitcher([Inject(Id = BindId.MAIN_STATE)] AUIState mainMenuState, [Inject(Id = BindId.ADD_STATE)] AUIState additionalMenuState)
        {
            States = new Dictionary<Type, AUIState>();

            States.Add(typeof(MainScreen), mainMenuState);
            States.Add(typeof(AdditionalScreen), additionalMenuState);

            foreach (var state in States)
                state.Value.SetOwner(this);
        }

        private void ExitState()
        {
            _activeState?.Exit();
        }

        private void EnterState(AUIState newState)
        {
            _activeState = newState;
            _activeState.Enter();
        }

        public void ChangeState(AUIState newState)
        {
            ExitState();
            EnterState(newState);
        }
    }
}