using UnityEngine;

namespace Service
{
    public class SoundService
    {
        private AudioSource _source;

        public SoundService(AudioSource source)
        {
            _source = source;
        }

        public void PlayClip(AudioClip clip) => _source.PlayOneShot(clip);
    }
}