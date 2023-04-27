using UnityEngine;
using Zenject;

namespace UISystem
{
    public class SoundPlayer : ISoundPlayer
    {
        private AudioSource _openSound;
        private AudioSource _exitSound;

        [Inject]
        public SoundPlayer([Inject(Id = BindId.MAIN_STATE)] AudioSource openSound, [Inject(Id = BindId.ADD_STATE)] AudioSource exitSound)
        {
            _openSound = openSound;
            _exitSound = exitSound;
        }

        public void PlayOpenSound() => _openSound.Play();

        public void PlayExitSound() => _exitSound.Play();
    }
}