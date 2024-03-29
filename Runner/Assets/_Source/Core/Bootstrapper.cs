using UnityEngine;
using Pool;
using CharacterSystem;
using System.Collections.Generic;
using TileSystem;

namespace Core
{
    public class Bootstrapper : MonoBehaviour
    {
        [SerializeField] private List<Tile> tiles;
        [SerializeField] private List<TileSO> tilesSO;
        [SerializeField] private GameObject road;
        [SerializeField] private Transform startPosition;
        [SerializeField] private bool autoExpand;
        [SerializeField] private int count;
        [SerializeField] private Character character;

        private void Awake()
        {
            ServiceLocator serviceLocator = new ServiceLocator();

            //character.Construct(new TilePool<Tile>(tiles, road.transform.localScale.z, autoExpand, startPosition.position, count, serviceLocator), serviceLocator);
            character.Construct(new TileSOPool(tilesSO, road.transform.localScale.z, autoExpand, startPosition.position, count, serviceLocator), serviceLocator);
        }
    }
}