using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectile : MonoBehaviour
{
    Rigidbody2D projectileRigidbody2D;
    [SerializeField] GameObject playerHitParticle;
    [SerializeField] GameObject wallHit;
    PlayerHealth player;

    [Header("Movement Params")]
    [SerializeField] float xMin;
    [SerializeField] float xMax;
    [Space(10)]
    [SerializeField] float yMin;
    [SerializeField] float yMax;
    [Space(10)]
    [SerializeField] float speed = 1f;
    [SerializeField] float rotation;

    void Start()
    {
        player = FindObjectOfType<PlayerHealth>();

        projectileRigidbody2D = GetComponent<Rigidbody2D>();
        projectileRigidbody2D.velocity = new Vector2(Random.Range(xMin, xMax), Random.Range(yMin, yMax) * speed * Time.deltaTime);
        projectileRigidbody2D.rotation = 45f;
    }

    private void FixedUpdate()
    {
        projectileRigidbody2D.rotation += rotation;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Paddle"))
        {
            Debug.Log("health minus");
            player.DealDamage();
            
            CreateAndDestroy();
        }

        if (collision.gameObject.tag.Equals("Wall"))
        {
            //Debug.Log("wall hit");

            CreateAndDestroy();
        }
    }

    void CreateAndDestroy()
    {
        GameObject particle = Instantiate(playerHitParticle, transform.position, Quaternion.identity);

        Destroy(particle, 0.5f);
        Destroy(gameObject);
    }
}
