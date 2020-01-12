using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class SceneLoader : MonoBehaviour
{
    LevelManager level;
    int monsters;
    Score score;

    IEnumerator coroutine;

    private void Start()
    {
        score = FindObjectOfType<Score>();
        coroutine = WaitBeforeGameOver(2);
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.G))
        {
            GameOver();
        }

        if (Input.GetKeyDown(KeyCode.N))
        {
            NextLevel();
        }

        if (monsters < 0)
        {
            NextLevel();
        }

        if(Input.GetKeyDown(KeyCode.R))
        {
            int currentScene = SceneManager.GetActiveScene().buildIndex;
            SceneManager.LoadScene(currentScene);
            score.ReloadScore();
        }
    }

    public void NextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        StartCoroutine(coroutine);
    }

    public void GameOver()
    {
        score.ReloadScore();
        StartCoroutine(coroutine);
        SceneManager.LoadScene("4Scene_GameOver");
    }

    public void Credits()
    {
        SceneManager.LoadScene("5Scene_Credits");
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    IEnumerator WaitBeforeGameOver(int waitTime)
    {
        yield return new WaitForSeconds(waitTime);
    }
}
