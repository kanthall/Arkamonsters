using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
    [Header("Tracklist")]
    [SerializeField] AudioClip[] tracks;

    [Space(10)]
    [SerializeField] AudioSource audioSource;

    public static MusicPlayer Instance { get { return instance; } }

    private static MusicPlayer instance = null;

    private void Awake()
    {
        if (instance)
        {
            Destroy(this.gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    private void Update()
    {
        if (!audioSource.isPlaying)
        {
            audioSource.clip = GetRandomClip();
            audioSource.Play();
        }
    }

    private AudioClip GetRandomClip()
    {
        return tracks[Random.Range(0, tracks.Length)];
    }
}

