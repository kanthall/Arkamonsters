using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterHealth : MonoBehaviour
{
    [SerializeField] int health;
    LevelManager level;

    // Start is called before the first frame update
    void Start()
    {
        level = FindObjectOfType<LevelManager>();
        if(tag == "Monster")
        {
            level.MonstersCount();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
