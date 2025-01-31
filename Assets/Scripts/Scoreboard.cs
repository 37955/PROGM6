using UnityEngine;
using TMPro;

public class Scoreboard : MonoBehaviour
{
    private int score = 0;
    public TMP_Text scoreText;

    void Start()
    {
        PickUp.OnPickupCollected += AddScore;
        UpdateScoreText();
    }

    private void OnDestroy()
    {
        PickUp.OnPickupCollected -= AddScore;
    }

    private void AddScore()
    {
        score += 50;
        UpdateScoreText();
    }

    private void UpdateScoreText()
    {
        if (scoreText != null)
        {
            scoreText.text = "Score: " + score;
        }
    }
}