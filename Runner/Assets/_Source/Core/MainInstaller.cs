using CharacterSystem;
using Pool;
using Service;
using System.Collections.Generic;
using TileSystem;
using UnityEngine;
using Zenject;

namespace Core
{
    public class MainInstaller : MonoInstaller<MainInstaller>
    {
        [Header("Character")]
        [SerializeField] private Character character;
        [SerializeField] private InputListener inputListener;
        [SerializeField] private AudioSource source;
        [SerializeField] private float speed;
        [SerializeField] private float jumpForce;

        [Header("TileSOPool")]
        [SerializeField] private List<TileSO> tilesSO;
        [SerializeField] private GameObject road;
        [SerializeField] private bool autoExpand;
        [SerializeField] private Transform startPosition;
        [SerializeField] private int count;

        [Header("BulletPool")]
        [SerializeField] private GameObject bullet;
        [SerializeField] private bool autoExpandForBullet;
        [SerializeField] private Transform startPositionForBullet;
        [SerializeField] private int countForBullet;

        public override void InstallBindings()
        {
            Container.Bind<Character>().FromInstance(character).AsSingle().NonLazy();
            Container.Bind<SoundService>().AsSingle().NonLazy();
            Container.Bind<InputListener>().FromInstance(inputListener).AsSingle().NonLazy();
            Container.Bind<CharacterFunctions>().AsSingle().NonLazy();
            Container.Bind<TileSOPool>().AsSingle().NonLazy();
            Container.Bind<BulletPool>().AsSingle().NonLazy();
            Container.Bind<SpecialRandomService>().AsSingle().NonLazy();

            Container.Bind<List<TileSO>>().FromInstance(tilesSO).AsCached();
            Container.Bind<float>().WithId(BindId.COUNT_ID).FromInstance(road.transform.localScale.z).AsCached();
            Container.Bind<bool>().WithId(BindId.TILE_ID).FromInstance(autoExpand).AsCached();
            Container.Bind<Vector3>().FromInstance(startPosition.position).AsCached();
            Container.Bind<int>().WithId(BindId.TILE_ID).FromInstance(count).AsCached();

            Container.Bind<GameObject>().FromInstance(bullet).AsCached();
            Container.Bind<AudioSource>().FromInstance(source).AsCached();
            Container.Bind<bool>().WithId(BindId.BULLET_ID).FromInstance(autoExpandForBullet).AsCached();
            Container.Bind<Transform>().WithId(BindId.BULLET_ID).FromInstance(startPositionForBullet).AsCached();
            Container.Bind<int>().WithId(BindId.BULLET_ID).FromInstance(countForBullet).AsCached();

            Container.Bind<Transform>().WithId(BindId.COUNT_ID).FromInstance(character.transform).AsCached();
            Container.Bind<float>().WithId(BindId.SPEED_ID).FromInstance(speed).AsCached();
            Container.Bind<float>().WithId(BindId.JUMP_ID).FromInstance(jumpForce).AsCached();

            Container.BindFactory<Bullet, Bullet.Factory>().FromComponentInNewPrefab(bullet);
        }
    }

    public static class BindId
    {
        public const uint SPEED_ID = 0;
        public const uint JUMP_ID = 1;
        public const uint COUNT_ID = 2;
        public const uint TILE_ID = 3;
        public const uint BULLET_ID = 4;
    }
}