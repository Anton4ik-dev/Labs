using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spring : MonoBehaviour
{
    [SerializeField] private float strengthMax;
    [SerializeField] private float strengthPlus;

    private float _totalStrength;
    private Rigidbody ballRb;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
            ballRb = collision.gameObject.GetComponent<Rigidbody>();
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
            ballRb = null;
    }

    public void AddStrength()
    {
        if (_totalStrength < strengthMax)
            _totalStrength += strengthPlus;
    }

    public void Release()
    {
        ballRb?.AddForce(0, _totalStrength, 0, ForceMode.Impulse);
        _totalStrength = 0;
    }
}