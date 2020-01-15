using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectile : MonoBehaviour
{
    Rigidbody2D projectileRigidbody2D;
    [SerializeField] GameObject hitParticle;
    [SerializeField] GameObject wallHit;
    PlayerHealth player;

    [Header("Movement")]
    [SerializeField] float xMin;
    [SerializeField] float xMax;
    [Space(10)]
    [SerializeField] float yMin;
    [SerializeField] float yMax;
    [Space(10)]
    [SerializeField] float speed = 1f;

    void Start()
    {
        player = FindObjectOfType<PlayerHealth>();
        projectileRigidbody2D = GetComponent<Rigidbody2D>();
        projectileRigidbody2D.velocity = new Vector2(Random.Range(xMin, xMax), Random.Range(yMin, yMax) * speed * Time.deltaTime);
        projectileRigidbody2D.rotation = 45f;
        Destroy(gameObject, 7f);
    }

    private void FixedUpdate()
    {
        projectileRigidbody2D.rotation += 5.0f;
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
