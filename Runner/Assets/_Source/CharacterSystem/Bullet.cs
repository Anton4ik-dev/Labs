using Service;
using System.Collections;
using UnityEngine;
using Zenject;

namespace CharacterSystem
{
    [RequireComponent(typeof(Rigidbody))]
    public class Bullet : MonoBehaviour
    {
        [SerializeField] private float speed;
        [SerializeField] private Rigidbody rb;
        [SerializeField] private float lifeTime;
        [SerializeField] private AudioClip shootClip;
        [SerializeField] private AudioClip inClip;

        [Inject]
        private SoundService _soundService;

        private void Awake()
        {
            if (rb == null)
                rb = GetComponent<Rigidbody>();
        }

        private void Update()
        {
            rb.velocity = transform.forward * speed;
        }

        private void OnCollisionEnter(Collision collision)
        {
            _soundService.PlayClip(inClip);
            gameObject.SetActive(false);
        }

        [Inject]
        public void Construct(SoundService soundService)
        {
            _soundService = soundService;
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