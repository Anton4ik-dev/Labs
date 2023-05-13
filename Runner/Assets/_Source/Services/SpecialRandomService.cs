using System.Collections.Generic;
using TileSystem;
using UnityEngine;

namespace Service
{
    public class SpecialRandomService
    {
        private TileSO _lastTile;

        public TileSO GetRandomSO(List<TileSO> tileSOs)
        {
            if (_lastTile == null)
            {
                _lastTile = tileSOs[Random.Range(0, tileSOs.Count)];
                return _lastTile;
            }

            _lastTile = _lastTile.ConnectedTiles[Random.Range(0, _lastTile.ConnectedTiles.Count)];
            return _lastTile;
        }

        public TileSO GetRandomSO()
        {
            _lastTile = _lastTile.ConnectedTiles[Random.Range(0, _lastTile.ConnectedTiles.Count)];
            return _lastTile;
        }
    }
}