using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectile : MonoBehaviour
{
    Rigidbody2D projectileRigidbody2D;
    [SerializeField] float speed = 1f;
    [SerializeField] GameObject hitParticle;
    [SerializeField] GameObject wallHit;
    PlayerHealth player;

    void Start()
    {
        player = FindObjectOfType<PlayerHealth>();
        projectileRigidbody2D = GetComponent<Rigidbody2D>();
        projectileRigidbody2D.velocity = new Vector2(Random.Range(-5f, 5f), Random.Range(1f, -10f) * speed * Time.deltaTime);
        Destroy(gameObject, 7f);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Paddle"))
        {
            Debug.Log("health minus");
            player.DealDamage();

            GameObject particle = Instantiate(hitParticle, transform.position, Quaternion.identity);

            Destroy(particle, 0.5f);
            Destroy(gameObject);
        }

        if (collision.gameObject.tag.Equals("Wall"))
        {
            Debug.Log("wall hit");

            GameObject particle = Instantiate(wallHit, transform.position, Quaternion.identity);

            Destroy(particle, 0.5f);
            Destroy(gameObject);
        }
    } 
}
