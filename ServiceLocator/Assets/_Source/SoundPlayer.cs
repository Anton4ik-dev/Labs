using Core;
using UnityEngine;

namespace UISystem
{
    public class SoundPlayer : ISoundPlayer, IGameService
    {
        private AudioSource _openSound;
        private AudioSource _exitSound;

        public SoundPlayer(AudioSource openSound, AudioSource exitSound)
        {
            _openSound = openSound;
            _exitSound = exitSound;
        }

        public void PlayOpenSound() => _openSound.Play();

        public void PlayExitSound() => _exitSound.Play();
    }
}