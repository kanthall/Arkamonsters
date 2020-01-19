using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] List<GameObject> hearts = new List<GameObject>();
    [SerializeField] int health;

    SceneLoader scene;
    CameraShake camera;

    [Header("Sound")]
    [SerializeField] AudioClip playerHit;
    [SerializeField] [Range(0, 1)] float playerHitVolume;
    AudioSource audioSource;

    [Header("Flash Square")]
    [SerializeField] float flashTime;
    [SerializeField] GameObject flashSquare;

    void Start()
    {
        camera = FindObjectOfType<CameraShake>();

        health = hearts.Count;
        scene = FindObjectOfType<SceneLoader>();

        audioSource = GetComponent<AudioSource>();
    }

    public void DealDamage()
    {
        health -= 1;
        camera.Shake();
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
