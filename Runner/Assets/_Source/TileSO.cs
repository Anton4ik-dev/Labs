using System.Collections.Generic;
using TileSystem;
using UnityEngine;

[CreateAssetMenu(fileName = "Tile", menuName = "TileData")]
public class TileSO : ScriptableObject
{

    [SerializeField] private List<TileSO> connectedTiles;
    [SerializeField] private int priority;
    [SerializeField] private Tile tilePrefab;

    public List<TileSO> ConnectedTiles { get => connectedTiles; }
    public int Priority { get => priority; }
    public Tile TilePrefab { get => tilePrefab; }
}