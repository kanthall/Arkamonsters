using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{

    int startingScore = 0;
    [SerializeField] int score; 
    [SerializeField] Text scoreField;
    
    void Start()
    {
        score = 0;
        UpdateScore();
    }

    public void AddToScore(int points)
    {
        score += points;
        UpdateScore();
    }
    
    public void ReloadScore()
    {
        scoreField.text = startingScore.ToString();
    }

    void UpdateScore()
    {
        scoreField.text = "" + score;
    }
}
