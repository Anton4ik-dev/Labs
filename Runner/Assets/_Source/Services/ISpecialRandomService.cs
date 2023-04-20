using Core;
using System.Collections.Generic;
using TileSystem;

namespace Service
{
    public interface ISpecialRandomService : IGameService
    {
        Tile GetRandomElement(List<TileSO> prefabs);
        Tile GetRandomElement();
    }
}