using UnityEngine.SceneManagement;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [SerializeField] public int monsters;
    int hearts;

    SceneLoader scene;

    private void Start()
    {
        scene = FindObjectOfType<SceneLoader>();
    }

    public void MonstersCount()
    {
        monsters++;
    }

    public void MonsterKilled()
    {
        monsters--;
        if (monsters <= 0)
        {
            scene.NextLevel();
        }
    }

    public void PlayerHealthCount()
    {
        hearts++;
    }

    public void LifeLost()
    {
        hearts--;
        if (hearts <= 0)
        {
            scene.GameOver();
        }
    }
}
