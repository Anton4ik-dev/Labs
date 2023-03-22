using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "EventSO", menuName = "SO/Event", order = 0)]
public class EventSO : ScriptableObject
{
    private List<IGameEventListener> listeners = new List<IGameEventListener>();

    public void RegisterObserver(IGameEventListener listener)
    {
        listeners.Add(listener);
    }

    public void RemoveObserver(IGameEventListener listener)
    {
        listeners.Remove(listener);
    }

    public void Notify()
    {
        for (int i = 0; i < listeners.Count; i++)
        {
            listeners[i].Notify();
        }
    }
}