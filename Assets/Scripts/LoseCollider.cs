using UnityEngine.SceneManagement;
using UnityEngine;

public class LoseCollider : MonoBehaviour
{
    PlayerHealth health;
    SceneLoader scene;
    Paddle paddle;

    private void Start()
    {
        health = FindObjectOfType<PlayerHealth>();
        scene = FindObjectOfType<SceneLoader>();
        paddle = FindObjectOfType<Paddle>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag.Equals("Ball"))
        {
            health.DealDamage();
        }
    }
}

