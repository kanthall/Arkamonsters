using UnityEngine.SceneManagement;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [SerializeField] int monsters;
    [SerializeField] int hearts;

    void Start()
    {

    }

    public void MonstersCount()
    {
        monsters++;
    }

    public void PlayerHealthCount()
    {
        hearts++;
    }
}
