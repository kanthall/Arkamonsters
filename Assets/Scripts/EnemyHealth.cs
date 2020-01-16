using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] int health;
    [SerializeField] int scoreValue;
    [SerializeField] GameObject deathParticle;
    [SerializeField] Animator animator;
    [SerializeField] bool killLock;

    ProjectileSpawner spawner;
    LevelManager level;
    Score score;

    void Start()
    {
        level = FindObjectOfType<LevelManager>();
        spawner = GetComponent<ProjectileSpawner>();
        animator = GetComponent<Animator>();

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
            DealDamage();

            if (health <= 0)
            {
                animator.SetTrigger("Die");
                spawner.SpawnOnDeath();
                DestroyMonster();
            }
            else
            {
                animator.SetTrigger("Hit");
            }
        }
    }

    private void DestroyMonster()
    {
        GameObject ps = Instantiate(deathParticle, transform.position, Quaternion.identity);
        Destroy(ps, 1f);

        if (killLock == false)
        {
            killLock = true;
            score.AddToScore(scoreValue);

            Object.Destroy(gameObject, 2f);
            level.MonsterKilled();
        }
    }
}
