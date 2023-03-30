using UnityEngine;

public class InputListener : MonoBehaviour
{
    [SerializeField] private Rigidbody _leftFipperRb;
    [SerializeField] private Rigidbody _rightFipperRb;
    [SerializeField] private Spring _spring;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
            _leftFipperRb.AddForce(150, 0, 0, ForceMode.Impulse);

        if (Input.GetKeyDown(KeyCode.X))
            _rightFipperRb.AddForce(-150, 0, 0, ForceMode.Impulse);

        if (Input.GetKey(KeyCode.Space))
            _spring.AddStrength();

        if (Input.GetKeyUp(KeyCode.Space))
            _spring.Release();
    }
}