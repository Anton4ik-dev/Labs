using DG.Tweening;
using GhostSystem;
using MV;
using System.Collections;
using UnityEngine;

namespace Character
{
    public class OnPlayerDamage : MonoBehaviour
    {
        [SerializeField] private AGhost[] ghosts;
        [SerializeField] private InputListener input;
        [SerializeField] private SpriteRenderer playerSprite;
        [SerializeField] private Transform playerPosition;
        [SerializeField] private AudioSource loseSound;
        [SerializeField] private AudioSource gameTheme;
        [SerializeField] private float pauseTime;

        private Vector3 spawnPos;

        private void Start()
        {
            spawnPos = playerPosition.position;
        }

        public void OnDamage()
        {
            TurnOffGame();

            StartCoroutine(Countdown());
        }

        private IEnumerator Countdown()
        {
            float totalTime = 0;

            while (totalTime <= pauseTime)
            {
                totalTime += Time.deltaTime;
                yield return null;
            }

            TurnOnGame();
        }

        private void TurnOnGame()
        {
            for (int i = 0; i < ghosts.Length; i++)
            {
                ghosts[i].enabled = true;
                ghosts[i].Teleport();
            }

            input.enabled = true;
            playerSprite.gameObject.transform.position = spawnPos;
            gameTheme.Play();
        }

        private void TurnOffGame()
        {
            gameTheme.Stop();
            loseSound.Play();
            playerSprite.DOFade(0, pauseTime / 2f).OnComplete(() => playerSprite.DOFade(1, pauseTime / 2f));
            Health.OnHealthChange();
            input.enabled = false;
            for (int i = 0; i < ghosts.Length; i++)
            {
                ghosts[i].enabled = false;
            }
        }
    }
}