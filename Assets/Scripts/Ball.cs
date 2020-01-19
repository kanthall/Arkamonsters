using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] float xPush = 2f;
    [SerializeField] float yPush = 15f;
    [SerializeField] float randomFactor = 1f;
    [SerializeField] float thrust = 10f;

    [Space(10)]
    [Header("Sound")]
    [SerializeField] AudioClip ballHitSound;
    [SerializeField] [Range(0, 1)] float ballHitSoundVolume;

    [Space(10)]
    [SerializeField] Paddle paddle;

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
        if (!gameStarted)
        {
            LaunchBall();
            LockBallTopaddle();
        }
    }

    void LaunchBall()
    {
        if (Input.GetMouseButtonDown(0))
        {
            gameStarted = true;
            ballRigidBody2D.velocity = new Vector2(xPush, yPush);
        }
    }

    void LockBallTopaddle()
    {
        Vector2 paddlePosition = new Vector2(paddle.transform.position.x, paddle.transform.position.y);
        transform.position = paddlePosition + paddleToBallVector;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag.Equals("Projectile")) 
        {
            Debug.Log("Projectile Hit");
        }
        else
        {
            Vector2 velocityTweak = new Vector2(Random.Range(0.1f, randomFactor), Random.Range(0.1f, randomFactor));

            if (gameStarted)
            {
                audio.PlayOneShot(ballHitSound, ballHitSoundVolume);
                ballRigidBody2D.velocity += velocityTweak;
            }
        }

        if (collision.collider.tag.Equals("Paddle"))
        {
            ballRigidBody2D.AddForce(transform.up * thrust);
            Debug.Log("Force Added");
        }
    }
}
