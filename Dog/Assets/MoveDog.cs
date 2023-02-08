using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveDog : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private Rigidbody rb;

    private void FixedUpdate()
    {
        rb.velocity = new Vector3(speed, 0, 0);
    }
}