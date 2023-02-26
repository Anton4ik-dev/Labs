using Character;
using DG.Tweening;
using Enemies;
using MV;
using System.Collections;
using UnityEngine;

public class OnDamageAction : MonoBehaviour
{
    [SerializeField] private AGhost[] ghosts;
    [SerializeField] private InputListener input;
    [SerializeField] private SpriteRenderer playerSprite;
    [SerializeField] private Transform playerPosition;
    [SerializeField] private float pauseTime;

    public void OnDamage()
    {
        //sound
        playerSprite.DOFade(0, pauseTime/2f).OnComplete(() => playerSprite.DOFade(1, pauseTime / 2f));
        Health.OnHealthChange();
        input.enabled = false;
        for (int i = 0; i < ghosts.Length; i++)
        {
            ghosts[i].enabled = false;
        }

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

        for (int i = 0; i < ghosts.Length; i++)
        {
            ghosts[i].enabled = true;
            ghosts[i].Teleport();
        }

        input.enabled = true;
        playerSprite.gameObject.transform.position = playerPosition.position;
    }
}