using Core;

namespace UISystem
{
    public interface ISoundPlayer : IGameService
    {
        void PlayOpenSound();
        void PlayExitSound();
    }
}