using System;
using System.Collections.Generic;

namespace UISystem
{
    public interface IUISwitcher
    {
        Dictionary<Type, AUIState> States { get; set; }
        void ChangeState(AUIState newState);
    }
}
