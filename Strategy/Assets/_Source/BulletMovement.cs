using UnityEngine;

public class BulletMovement : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private int speed;
    void Update()
    {
        rb.velocity = transform.right * speed;
    }
}