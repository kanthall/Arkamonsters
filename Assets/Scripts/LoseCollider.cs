using UnityEngine.SceneManagement;
using UnityEngine;

public class LoseCollider : MonoBehaviour
{
    PlayerHealth health;
    SceneLoader scene;

    private void Start()
    {
        health = GetComponent<PlayerHealth>();
        scene = GetComponent<SceneLoader>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("end");
        //load game over
    }
}

