using System.Collections;
using UnityEngine.Rendering.PostProcessing;
using UnityEngine;

public class Chromatic : MonoBehaviour
{
    ChromaticAberration chromaticAberration = null;
    [SerializeField] PostProcessVolume volume;

    private void Awake()
    {
        int ball = FindObjectsOfType<Chromatic>().Length;
        if (ball > 1)
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
        volume.profile.TryGetSettings(out chromaticAberration);

        if (chromaticAberration != null)
        {
            chromaticAberration.enabled.value = true;
        }
    }

    public void UseChromaticAbberation()
    {
        StartCoroutine("ChromaticSplitSecond");
    }

    IEnumerator ChromaticSplitSecond()
    {
        chromaticAberration.intensity.value = 0.350f;
        Time.timeScale = 0.5f;
        yield return new WaitForSeconds(0.3f);
        chromaticAberration.intensity.value = 0;
        Time.timeScale = 1.0f;
    }
}

