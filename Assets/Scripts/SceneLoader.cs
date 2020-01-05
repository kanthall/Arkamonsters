using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    LevelManager level;
    int monsters;
    Score score;

    private void Start()
    {
        score = FindObjectOfType<Score>();
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
    }

    public void GameOver()
    {
        score.ReloadScore();
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
}
