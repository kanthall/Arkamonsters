using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] List<GameObject> hearts = new List<GameObject>();
    [SerializeField] int health;
    SceneLoader scene;

    void Start()
    {
        health = hearts.Count;
        scene = FindObjectOfType<SceneLoader>();
    }

    public void DealDamage()
    {
        health -= 1;

        if (hearts.Count > 0)
        {
            Destroy(hearts[0].gameObject);
            hearts.RemoveAt(0);
        }

        if (health == 0)
        {
            Debug.Log("Game ends");
            scene.GameOver();
        }
    }
}
