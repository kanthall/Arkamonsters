using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{

    int startingScore = 0;
    int currentScore; 
    [SerializeField] Text scoreField;
    
    void Start()
    {
        scoreField.text = startingScore.ToString();
    }

    public void AddToScore(int score)
    {
        Debug.Log("adding score: " + score);
    }
    
    public void ReloadScore()
    {
        scoreField.text = startingScore.ToString();
    }
}
