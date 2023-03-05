using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace UI
{
    public class ScreensAndSettings : MonoBehaviour
    {
        [SerializeField] private AudioMixer mixer;
        [SerializeField] private Slider musicSlider;
        [SerializeField] private Slider sfxSlider;

        private const string MUSIC_VOLUME = "MUSIC_VOLUME";
        private const string SFX_VOLUME = "SFX_VOLUME";

        private void Awake()
        {
            musicSlider.onValueChanged.AddListener(SetMusicVolume);
            sfxSlider.onValueChanged.AddListener(SetSfxVolume);
        }

        private void SetMusicVolume(float value)
        {
            mixer.SetFloat(MUSIC_VOLUME, Mathf.Log10(value) * 20);
        }

        private void SetSfxVolume(float value)
        {
            mixer.SetFloat(SFX_VOLUME, Mathf.Log10(value) * 20);
        }

        public void LoadMenu()
        {
            SceneManager.LoadScene(0);
        }

        public void LoadGame()
        {
            SceneManager.LoadScene(1);
        }
    }
}