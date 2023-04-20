using System.Collections.Generic;
using TileSystem;
using UnityEngine;

namespace Service
{
    public class SpecialRandomService : ISpecialRandomService
    {
        private TileSO _lastTile;

        public Tile GetRandomElement(List<TileSO> tileSOs)
        {
            if (_lastTile == null)
            {
                _lastTile = tileSOs[Random.Range(0, tileSOs.Count)];
                return _lastTile.TilePrefab;
            }

            _lastTile = _lastTile.ConnectedTiles[Random.Range(0, _lastTile.ConnectedTiles.Count)];
            return _lastTile.TilePrefab;
        }

        public Tile GetRandomElement()
        {
            _lastTile = _lastTile.ConnectedTiles[Random.Range(0, _lastTile.ConnectedTiles.Count)];
            return _lastTile.TilePrefab;
        }
    }
}