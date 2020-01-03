using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{

    int startingScore = 0;
    [SerializeField] Text scoreField;


    void Start()
    {
        scoreField.text = startingScore.ToString();
    }
}
