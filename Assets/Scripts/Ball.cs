using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    bool gameStarted = false;

    void Start()
    {
        
    }


    void Update()
    {
        if(!gameStarted)
        {
            LaunchBall();
        }
    }

    private void LaunchBall()
    {
        if(Input.GetMouseButtonDown(0))
        {
            gameStarted = true;
            Debug.Log("ball launched");
        }
    }


}
