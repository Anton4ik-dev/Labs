using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Enemies
{
    public class BonusObservable : MonoBehaviour, IObservable
    {
        [SerializeField] private float duration;
        [SerializeField] private AudioSource extraSound;
        [SerializeField] private AudioSource gameTheme;
        [SerializeField] private AudioSource bonusGameTheme;

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
            {
                gameTheme.Stop();
                extraSound.Play();
                bonusGameTheme.Play();
                StartCoroutine(Countdown());
            }
            else
            {
                gameTheme.Play();
                bonusGameTheme.Stop();
            }
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