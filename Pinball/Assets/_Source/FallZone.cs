using UnityEngine;
using UnityEngine.UI;

public class FallZone : MonoBehaviour
{
    [SerializeField] private GameObject ball;
    [SerializeField] private Transform spawnPos;
    [SerializeField] private Text ballsText;
    [SerializeField] private GameObject restartText;
    [SerializeField] private int howMuchBalls;

    private void Start()
    {
        ballsText.text = $"Balls: {howMuchBalls}";
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Ball"))
        {
            if (howMuchBalls == 0)
                restartText.SetActive(true);
            if (howMuchBalls > 0)
            {
                Instantiate(ball, spawnPos);
                Score.OnFall();
                ballsText.text = $"Balls: {--howMuchBalls}";
            }
        }
    }
}