using System.Collections;
using UnityEngine;

public class NextLevelCanvas : MonoBehaviour
{ 
    [SerializeField] Canvas levelCanvas;

    private void Awake()
    {
        int ball = FindObjectsOfType<NextLevelCanvas>().Length;
        if (ball > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    private void Start()
    {
        levelCanvas.enabled = false;
    }

    public void ShowWarning()
    {
        StartCoroutine(WaveCanvasEnable());
    }

    private IEnumerator WaveCanvasEnable()
    {
        levelCanvas.enabled = true;
        yield return new WaitForSeconds(5);
        levelCanvas.enabled = false;
    }
}