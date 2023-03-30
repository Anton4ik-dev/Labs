using UnityEngine;

public class FallZone : MonoBehaviour
{
    [SerializeField] private GameObject ball;
    [SerializeField] private Transform spawnPos;
    [SerializeField] private int howMuchBalls;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
            if (howMuchBalls > 0)
            {
                Instantiate(ball, spawnPos);
                Score.OnFall();
            }
            howMuchBalls--;
        }
    }
}