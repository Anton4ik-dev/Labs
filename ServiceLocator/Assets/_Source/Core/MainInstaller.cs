using SaveSystem;
using UISystem;
using UnityEngine;
using Zenject;

namespace Core
{
    public class MainInstaller : MonoInstaller
    {
        [SerializeField] private MainScreenView mainScreenView;
        [SerializeField] private AdditionalScreenView additionalScreenView;

        [SerializeField] private AudioSource openSound;
        [SerializeField] private AudioSource exitSound;

        public override void InstallBindings()
        {
            Container.Bind<MainScreenView>().FromInstance(mainScreenView).AsSingle().NonLazy();
            Container.Bind<AdditionalScreenView>().FromInstance(additionalScreenView).AsSingle().NonLazy();

            Container.Bind<ISoundPlayer>().To<SoundPlayer>().AsSingle();
            Container.Bind<IFadeService>().To<FadeService>().AsSingle();
            Container.Bind<ISaver>().To<JsonSaver>().AsSingle();
            Container.Bind<ISaver>().To<PlayerPrefsSaver>().AsSingle();
        }
    }
}