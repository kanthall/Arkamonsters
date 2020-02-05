using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] List<GameObject> hearts = new List<GameObject>();
    [SerializeField] int health;

    SceneLoader scene;
    CameraShake camera;
    Chromatic chromatic;

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
            Debug.Log("Game ends");
            scene.GameOver();
        }
    }

    IEnumerator YellowFlash()
    {
        flashSquare.GetComponent<SpriteRenderer>().enabled = true;

        yield return new WaitForSeconds(flashTime);

        flashSquare.GetComponent<SpriteRenderer>().enabled = false;
    }
}
