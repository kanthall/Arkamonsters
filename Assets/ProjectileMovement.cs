using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileMovement : MonoBehaviour
{
    Rigidbody2D projectileRigidbody2D;
    [SerializeField] float speed = 1f;

    void Start()
    {
        projectileRigidbody2D = GetComponent<Rigidbody2D>();
        projectileRigidbody2D.velocity = new Vector2(Random.Range(-5f, 5f), Random.Range(1f, -10f) * speed * Time.deltaTime);
    }
}
