using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Enemies
{
    public class BonusObservable : MonoBehaviour, IObservable
    {
        [SerializeField] private float duration;

        private List<IObserver> observers = new List<IObserver>();

        public void AddObserver(IObserver observer)
        {
            observers.Add(observer);
        }

        public void RemoveObserver(IObserver observer)
        {
            observers.Remove(observer);
        }

        public void NotifyObservers(bool toActivate)
        {
            for (int i = 0; i < observers.Count; i++)
            {
                observers[i].UpdateObserver(toActivate);
            }

            if(toActivate)
                StartCoroutine(Countdown());
        }

        private IEnumerator Countdown()
        {
            float totalTime = 0;

            while (totalTime <= duration)
            {
                totalTime += Time.deltaTime;
                yield return null;
            }

            NotifyObservers(false);
        }
    }
}