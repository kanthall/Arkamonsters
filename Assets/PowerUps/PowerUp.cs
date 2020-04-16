using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    Rigidbody2D powerUpRigidbody2D;
    [SerializeField] GameObject powerUpParticle;

    [Header("Movement Params")]
    [SerializeField] float yMin;
    [SerializeField] float yMax;

    [Space(10)]
    [SerializeField] float speed = 1f;

    protected void MoveDown()
    {
        powerUpRigidbody2D = GetComponent<Rigidbody2D>();  
        powerUpRigidbody2D.velocity = new Vector2(0f, Random.Range(yMin, yMax) * speed * Time.deltaTime);
    }
    
    public void DestroyPowerUp()
    {
        Destroy(gameObject, 30.0f);
    }

    public void CreateAndDestroyParticle()
    {
        GameObject particle = Instantiate(powerUpParticle, transform.position, Quaternion.identity);
        Destroy(particle, 0.5f);
    }
}