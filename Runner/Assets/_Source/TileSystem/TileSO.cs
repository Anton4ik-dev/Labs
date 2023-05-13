using System.Collections.Generic;
using UnityEngine;

namespace TileSystem
{
    [CreateAssetMenu(fileName = "Tile", menuName = "TileData")]
    public class TileSO : ScriptableObject
    {

        [SerializeField] private List<TileSO> connectedTiles;
        [SerializeField] private int priority;
        [SerializeField] private GameObject tilePrefab;

        public List<TileSO> ConnectedTiles { get => connectedTiles; }
        public int Priority { get => priority; }
        public GameObject TilePrefab { get => tilePrefab; }
    }
}