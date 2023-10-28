using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    private Text scoreText;
    private int score;

    private void Start()
    {
        scoreText = GetComponent<Text>();
        score = 0; 
    }
    private void Update()
    {
        UpdateScore();
    }
    public void AddScore(int scoreAmount)
    {
        score += scoreAmount;
    }
    private void UpdateScore()
    {
        scoreText.text = "Score : " + score;
    }
}
