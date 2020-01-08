using UnityEngine.SceneManagement;
using UnityEngine;

public class LoseCollider : MonoBehaviour
{
    PlayerHealth health;
    SceneLoader scene;
    Paddle paddle;

    private void Start()
    {
        health = GetComponent<PlayerHealth>();
        scene = GetComponent<SceneLoader>();
        paddle = GetComponent<Paddle>();

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //decrease health



        //load game over
        //scene.GameOver();

    }
}

