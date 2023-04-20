using Service;
using System;
using System.Collections.Generic;
using TileSystem;

namespace Core
{
    public class ServiceLocator : IServiceLocator
    {
        private Dictionary<Type, IGameService> _services;

        public ServiceLocator()
        {
            _services = new Dictionary<Type, IGameService>
            {
                { typeof(ILayerService), new LayerService() },
                { typeof(IRandomService<Tile>), new RandomService<Tile>() },
                { typeof(ISpecialRandomService), new SpecialRandomService() }
            };
        }

        public void RegisterService<T>(IGameService service)
        {
            if (!_services.ContainsKey(typeof(T)))
                _services.Add(typeof(T), service);
        }

        public void DeleteService<T>()
        {
            if (_services.ContainsKey(typeof(T)))
                _services.Remove(typeof(T));
        }

        public bool GetService<T>(out T service)
        {
            service = default;
            if (_services.ContainsKey(typeof(T)))
            {
                service = (T)_services[typeof(T)];
                return true;
            }

            return false;
        }
    }
}