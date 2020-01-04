using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
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
    }

    public void NextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void GameOver()
    {
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
