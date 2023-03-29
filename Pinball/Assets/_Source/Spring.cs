using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spring : MonoBehaviour
{
    [SerializeField] private Rigidbody ballRb;
    [SerializeField] private float strengthMax;
    [SerializeField] private float strengthPlus;

    private bool isTouching;
    private float _totalStrength;

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Ball"))
            isTouching = true;
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
            isTouching = false;
    }

    public void AddStrength()
    {
        if(_totalStrength < strengthMax)
            _totalStrength += strengthPlus;
    }

    public void Release()
    {
        if (isTouching)
            ballRb.AddForce(0, _totalStrength, 0, ForceMode.Impulse);
    }
}