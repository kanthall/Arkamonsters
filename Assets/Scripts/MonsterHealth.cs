using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterHealth : MonoBehaviour
{
    [SerializeField] int health;
    [SerializeField] int scoreValue;
    [SerializeField] GameObject deathParticle;

    ProjectileSpawner spawner;
    LevelManager level;
    Score score;

    void Start()
    {
        level = FindObjectOfType<LevelManager>();
        spawner = GetComponent<ProjectileSpawner>();

        if(tag == "Monster")
        {
            level.MonstersCount();
        }

        score = FindObjectOfType<Score>();
    }
    
    void DealDamage()
    {
        health = health - 1;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("Ball"))
        {
            Debug.Log("damage");
            DealDamage();

            if (health <= 0)
            {
                spawner.SpawnOnDeath();
                DestroyMonster();
            } 
        }
    }

    private void DestroyMonster()
    {
        GameObject ps = Instantiate(deathParticle, transform.position, Quaternion.identity);
        Destroy(ps, 2f);

        score.AddToScore(scoreValue);
        Debug.Log("adding points" + scoreValue);
        Object.Destroy(gameObject);
        level.MonsterKilled();
    }
}
