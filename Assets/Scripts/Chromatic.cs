using System.Collections;
using UnityEngine.Rendering.PostProcessing;
using UnityEngine;

public class Chromatic : MonoBehaviour
{
    ChromaticAberration chromaticAberration = null;
    [SerializeField] PostProcessVolume volume;

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

