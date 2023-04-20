using Core;
using System.Collections.Generic;

namespace Service
{
    public interface IRandomService<T> : IGameService
    {
        T GetRandomElement(List<T> prefabs);
    }
}