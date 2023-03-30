using UnityEngine;

public class Obstacle : MonoBehaviour
{
    [SerializeField] private float force;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
            Vector3 heading = transform.position - collision.gameObject.transform.position;
            float distance = heading.magnitude;
            Vector3 direction = heading / distance;
            collision.gameObject.GetComponent<Rigidbody>().AddForce(new Vector3(direction.x * force, direction.y * force, direction.z * force), ForceMode.Impulse);
            Score.OnObstacle();
        }
    }
}