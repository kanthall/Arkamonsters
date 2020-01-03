using UnityEngine.SceneManagement;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [SerializeField] int monsters; 

    void Start()
    {

    }

    public void MonstersCount()
    {
        monsters++;
    }
}
