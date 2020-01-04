﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterHealth : MonoBehaviour
{
    [SerializeField] int health;
    LevelManager level;

    void Start()
    {
        level = FindObjectOfType<LevelManager>();
        if(tag == "Monster")
        {
            level.MonstersCount();
        }
    }

    void Update()
    {
        
    }
}
