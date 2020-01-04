using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heart : MonoBehaviour
{
    LevelManager level;

    void Start()
    {
        level = FindObjectOfType<LevelManager>();
        if (tag == "Heart")
        {
            level.PlayerHealthCount();
        }
    }
}
