using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterHealth : MonoBehaviour
{
    [SerializeField] int health;
    [SerializeField] int scoreValue;
    [SerializeField] GameObject deathParticle;

    LevelManager level;
    Score score;

    void Start()
    {
        level = FindObjectOfType<LevelManager>();
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
        //Debug.Log("you hit me");

        if (collision.collider.tag == "Ball")
        {
            if (health > 0)
            {
                Debug.Log("damage");
                DealDamage();
            }
            else
            {
                DestroyMonster();
            }
        }
    }

    private void DestroyMonster()
    {
        GameObject ps = Instantiate(deathParticle, transform.position, Quaternion.identity);
        Destroy(ps, 2f);

        score.AddToScore(scoreValue);
        Object.Destroy(gameObject);
        level.MonsterKilled();
    }
}
