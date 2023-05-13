using Service;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace TileSystem
{
    public class DestroyableTile : MonoBehaviour
    {
        [SerializeField] private AudioClip destroyClip;
        [SerializeField] private List<Rigidbody> afterDestroyObjects;
        [SerializeField] private LayerMask bulletLayer;
        [SerializeField] private int forceStrengthMax;
        [SerializeField] private int forceStrengthMin;
        
        private void OnCollisionEnter(Collision collision)
        {
            if (LayerService.CheckLayersEquality(collision.gameObject.layer, bulletLayer))
            {
                gameObject.SetActive(false);
                foreach(Rigidbody rb in afterDestroyObjects)
                {
                    rb.gameObject.SetActive(true);
                    rb.useGravity = true;
                    rb.AddForce(new Vector3(
                        Random.Range(forceStrengthMin, forceStrengthMax),
                        Random.Range(forceStrengthMin, forceStrengthMax),
                        Random.Range(forceStrengthMin, forceStrengthMax)),
                        ForceMode.Impulse);
                }
            }
        }
    }
}