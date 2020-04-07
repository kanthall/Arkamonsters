using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{

    [Header("Values")]
    [SerializeField] int health;
    [SerializeField] int scoreValue;
    [SerializeField] bool killLock;
    [SerializeField] int timesHit;

    [Header("Objects")]
    [SerializeField] GameObject deathParticle;
    [SerializeField] GameObject hitParticle;
    [SerializeField] Sprite[] hitSprites;

    ProjectileSpawner spawner;
    LevelManager level;
    Score score;
    Collider2D enemyCollider;
    SpriteRenderer sprite;

    [Header("Probability")]
    [SerializeField] Probability prob;

    void Start()
    {
        level = FindObjectOfType<LevelManager>();
        spawner = GetComponent<ProjectileSpawner>();
        sprite = GetComponent<SpriteRenderer>();


        if(tag == "Monster")
        {
            level.MonstersCount();
        }

        score = FindObjectOfType<Score>();
        enemyCollider = GetComponent<Collider2D>();
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
            if (health > 0)
            {
                GameObject hit = Instantiate(hitParticle, transform.position, Quaternion.identity);
                Destroy(hit, 0.3f);
            }

            timesHit++;
            int maxHits = hitSprites.Length + 1;

            StartCoroutine("ChangeColor");
            
            if (health <= 0) 
            {
                spawner.SpawnOnDeath();
                DestroyMonster();
            }
            else
            {
                ShowNextHitSprite();
                Debug.Log("Loading next sprite");
            }
        }
    }

    IEnumerator ChangeColor()
    {
        sprite.color = Color.red;
        yield return new WaitForSeconds(0.3f);
        sprite.color = Color.white;
    }

    private void ShowNextHitSprite()
    {
        int spriteIndex = timesHit - 1;
        if (hitSprites[spriteIndex] != null)
        {
            GetComponent<SpriteRenderer>().sprite = hitSprites[spriteIndex];
        }
        else
        {
            Debug.LogError("Block sprite is missing from array" + gameObject.name);
        }
    }

    private void DestroyMonster()
    {
        RandomNumber();

        GameObject particle = Instantiate(deathParticle, transform.position, Quaternion.identity);
        Destroy(particle, 1f);

        if (killLock == false)
        {
            enemyCollider.enabled = false;

            killLock = true;
            score.AddToScore(scoreValue);

            Destroy(gameObject, 0.2f);
            level.MonsterKilled();
        }
    }

    private void RandomNumber()
    {
        int test; 
        test = (UnityEngine.Random.Range(prob.minValue, prob.maxValue));

        Debug.Log(test);

        if (test == 5)
        {
            var obj = Instantiate(prob.objectToSpawn, transform.position, Quaternion.identity);
            Destroy(obj, 3f);
        }
    }
}
