using UnityEngine.SceneManagement;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [SerializeField] public int monsters;
    int hearts;

    SceneLoader scene;
    Ball ball;

    private void Start()
    {
        scene = FindObjectOfType<SceneLoader>();
        ball = FindObjectOfType<Ball>();
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
            ball.ResetBallPosition();
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
