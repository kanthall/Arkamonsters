using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] float xPush = 2f;
    [SerializeField] float yPush = 15f;
    [SerializeField] float randomFactor = 0.5f;

    [Space(10)]
    [SerializeField] Paddle paddle;
    [SerializeField] AudioClip ballHitSound;

    [Space(10)]
    Vector2 paddleToBallVector;
    bool gameStarted = false;
    Rigidbody2D ballRigidBody2D;
    AudioSource audio;

    void Start()
    {
        ballRigidBody2D = GetComponent<Rigidbody2D>();
        audio = GetComponent<AudioSource>();

        paddleToBallVector = transform.position - paddle.transform.position;
    }


    void Update()
    {
        if(!gameStarted)
        {
            LaunchBall();
        }
    }

    void LaunchBall()
    {
        if(Input.GetMouseButtonDown(0))
        {
            gameStarted = true;
            ballRigidBody2D.velocity = new Vector2(xPush, yPush);
            //Debug.Log("ball launched");
        }
    }

    void LockBallTopaddle()
    {
        Vector2 paddlePosition = new Vector2(paddle.transform.position.x, paddle.transform.position.y);
        transform.position = paddlePosition + paddleToBallVector;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        Vector2 velocityTweak = new Vector2(Random.Range(0f, randomFactor), Random.Range(0f, randomFactor));

        if(gameStarted)
        {
            audio.PlayOneShot(ballHitSound);
            ballRigidBody2D.velocity += velocityTweak;
        }
    }
}
