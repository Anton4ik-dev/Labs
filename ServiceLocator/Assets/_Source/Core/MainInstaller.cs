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
            Container.Bind<AudioSource>().WithId(BindId.MAIN_STATE).FromInstance(openSound);
            Container.Bind<AudioSource>().WithId(BindId.ADD_STATE).FromInstance(exitSound);

            Container.Bind<AUIState>().WithId(BindId.ADD_STATE).To<AdditionalScreen>().AsSingle();
            Container.Bind<AUIState>().WithId(BindId.MAIN_STATE).To<MainScreen>().AsSingle();

            Container.Bind<IUISwitcher>().To<UISwitcher>().AsSingle();
            Container.Bind<Score>().AsSingle();

            Container.Bind<ISoundPlayer>().To<SoundPlayer>().AsSingle();
            Container.Bind<IFadeService>().To<FadeService>().AsSingle();
            //Container.Bind<ISaver>().To<JsonSaver>().AsSingle();
            Container.Bind<ISaver>().To<PlayerPrefsSaver>().AsSingle();
        }
    }
}

public static class BindId
{
    public const uint MAIN_STATE = 0;
    public const uint ADD_STATE = 1;

}