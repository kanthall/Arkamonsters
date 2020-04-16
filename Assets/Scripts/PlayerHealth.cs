using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] List<GameObject> hearts = new List<GameObject>();
    [SerializeField] int health;
    [SerializeField] int maxHealth;

    SceneLoader scene;
    CameraShake camera;
    Chromatic chromatic;

    Vector2 temp;
    int actualSize = 0;

    [Header("Sound")]
    [SerializeField] AudioClip playerHit;
    [SerializeField] [Range(0, 1)] float playerHitVolume;
    AudioSource audioSource;

    [Header("Flash Square")]
    [SerializeField] float flashTime;
    [SerializeField] GameObject flashSquare;


    private void Awake()
    {
        int paddle = FindObjectsOfType<PlayerHealth>().Length;
        if (paddle > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    void Start()
    {
        camera = FindObjectOfType<CameraShake>();
        chromatic = FindObjectOfType<Chromatic>();

        health = hearts.Count;
        maxHealth = health;
        scene = FindObjectOfType<SceneLoader>();

        audioSource = GetComponent<AudioSource>();
    }

    public void DealDamage()
    {
        health -= 1;
        camera.Shake();
        chromatic.UseChromaticAbberation();
        StartCoroutine(YellowFlash());
        audioSource.PlayOneShot(playerHit, playerHitVolume);

        if (hearts.Count > 0)
        {
            Destroy(hearts[0].gameObject);
            hearts.RemoveAt(0);
        }

        if (health == 0)
        {
            Debug.Log("Game over");
            scene.GameOver();
        }
    }

    public void AddHealth()
    {
        if (health < maxHealth)
        {
            Debug.Log("I can add health");
        }
        else
        {
            Debug.Log("Health max");
        }
    }

    public void SizeUp()
    {
        if (actualSize < 2)
        {
            temp = transform.localScale;

            temp.x += 0.25f;

            transform.localScale = temp;
            actualSize++;

            Debug.Log("SizeUP " + actualSize);
        }
        else
        {
            Debug.Log("Resize prevent");
            return;
        }
    }

    public void SizeDown()
    {
        if (actualSize > -1)
        {
            temp = transform.localScale;

            temp.x -= 0.25f;

            transform.localScale = temp;
            actualSize--;

            Debug.Log("SizeDOWN " + actualSize);
        }
        else
        {
            Debug.Log("Resize prevent");
            return;
        }
    }

    public void ResetPaddleSize()
    {
        actualSize = 0;
        Debug.Log("Paddle Reset");
    }

    IEnumerator YellowFlash()
    {
        flashSquare.GetComponent<SpriteRenderer>().enabled = true;

        yield return new WaitForSeconds(flashTime);

        flashSquare.GetComponent<SpriteRenderer>().enabled = false;
    }
}
