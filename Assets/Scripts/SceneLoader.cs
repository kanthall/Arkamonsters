using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class SceneLoader : MonoBehaviour
{
    LevelManager level;
    int monsters;
    Score score;
    Ball ball;
    NextLevelCanvas levelCanvas;

    private void Start()
    {
        score = FindObjectOfType<Score>();
        //coroutine = WaitBeforeGameOver(2);
        ball = FindObjectOfType<Ball>();
        levelCanvas = FindObjectOfType<NextLevelCanvas>();
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
            ball.ResetBallPosition();
        }
    }

    public void NextLevel()
    {
        levelCanvas.ShowWarning();
        StartCoroutine("WaitBeforeNextLevel");
        ball.ResetBallPosition();
    }

    public void Credits()
    {
        SceneManager.LoadScene("5Scene_Credits");
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("1Scene_Menu");
    }

    public void GameOver()
    {
        score.ReloadScore();
        StartCoroutine("WaitBeforeGameOver");
    }

    public void LoadFirstLevel()
    {
        SceneManager.LoadScene("2Scene_level0");
    }

    IEnumerator WaitBeforeGameOver()
    {
        yield return new WaitForSeconds(5);
        Debug.Log("Loading next scene");
        SceneManager.LoadScene("4Scene_GameOver");
    }

    IEnumerator WaitBeforeNextLevel()
    {
        yield return new WaitForSeconds(1);
        Debug.Log("Loading next level");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
