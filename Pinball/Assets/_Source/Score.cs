using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    [SerializeField] private Text scoreText;
    [SerializeField] private int scoreChangeAmount;

    public static Action OnObstacle;
    public static Action OnFall;
    public static Action<int> OnBonus;

    private int _score;
    private int _scaler;

    private void Start()
    {
        OnObstacle += AddScore;
        OnFall += ResetScaler;
        OnBonus += OnBonusChange;
    }

    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.R))
            Expose();
    }

    private void Expose()
    {
        OnObstacle -= AddScore;
        OnFall -= ResetScaler;
        OnBonus -= OnBonusChange;
        SceneManager.LoadScene(0);
    }

    private void AddScore()
    {
        _score += scoreChangeAmount + _scaler++;
        scoreText.text = _score.ToString();
    }
    private void OnBonusChange(int change)
    {
        _score += change;
        scoreText.text = _score.ToString();
    }

    private void ResetScaler()
    {
        _scaler = 0;
    }
}
