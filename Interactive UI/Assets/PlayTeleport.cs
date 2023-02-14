using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayTeleport : MonoBehaviour
{
    [SerializeField] private Transform tp;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 6)
            other.gameObject.transform.position = tp.position;
    }
}