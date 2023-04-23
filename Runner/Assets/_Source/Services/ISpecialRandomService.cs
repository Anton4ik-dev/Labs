using Core;
using System.Collections.Generic;
using TileSystem;

namespace Service
{
    public interface ISpecialRandomService : IGameService
    {
        TileSO GetRandomSO(List<TileSO> prefabs);
        TileSO GetRandomSO();
    }
}