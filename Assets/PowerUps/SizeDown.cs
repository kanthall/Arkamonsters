using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SizeDown : PowerUp
{
    PlayerHealth player;

    private void Start()
    {
        player = FindObjectOfType<PlayerHealth>();
        DestroyPowerUp();
        MoveDown();
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Paddle"))
        {
            Destroy(gameObject);
            player.SizeDown();
            CreateAndDestroyParticle();
        }
    }
}  


