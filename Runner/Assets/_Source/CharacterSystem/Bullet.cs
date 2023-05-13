using Core;
using Service;
using System.Collections;
using UnityEngine;
using Zenject;

namespace CharacterSystem
{
    public class Bullet : MonoBehaviour
    {
        [SerializeField] private float speed;
        [SerializeField] private float lifeTime;
        [SerializeField] private AudioClip shootClip;
        [SerializeField] private AudioClip inClip;

        [Inject]
        private SoundService _soundService;
        private Transform _aim;

        private void Update()
        {
            transform.position = Vector3.MoveTowards(transform.position, _aim.position, speed * Time.deltaTime);
        }

        private void OnCollisionEnter(Collision collision)
        {
            _soundService.PlayClip(inClip);
            gameObject.SetActive(false);
        }

        [Inject]
        public void Construct(SoundService soundService, [Inject(Id = BindId.TILE_ID)] Transform aim)
        {
            _soundService = soundService;
            _aim = aim;
        }

        public void TurnOn()
        {
            gameObject.SetActive(true);
            _soundService.PlayClip(shootClip);
            StartCoroutine(LifeTime());
        }

        private IEnumerator LifeTime()
        {
            yield return new WaitForSeconds(lifeTime);

            gameObject.SetActive(false);
        }

        public class Factory : PlaceholderFactory<Bullet> { }
    }
}