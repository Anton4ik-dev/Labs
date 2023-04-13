using SaveSystem;
using System;
using System.Collections.Generic;
using UISystem;
using UnityEngine;

namespace Core
{
    public class ServiceLocator : IServiceLocator
    {
        private Dictionary<Type, IGameService> _services;

        public ServiceLocator(AudioSource openSound, AudioSource exitSound)
        {
            _services = new Dictionary<Type, IGameService>
            {
                { typeof(IFadeService), new FadeService() },
                { typeof(ISoundPlayer), new SoundPlayer(openSound, exitSound) },
                //{ typeof(ISaver), new PlayerPrefsSaver() }
                { typeof(ISaver), new JsonSaver() }
            };
        }

        public bool GetService<T>(out T service)
        {
            service = default;
            if(_services.ContainsKey(typeof(T)))
            {
                service = (T)_services[typeof(T)];
                return true;
            }

            return false;
        }
    }
}