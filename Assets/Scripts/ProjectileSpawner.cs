﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileSpawner : MonoBehaviour
{
    [SerializeField]Transform spawnerPosition;
    [SerializeField] GameObject projectile;
    
    void Start()
    {
        //Instantiate(projectile, transform.position, Quaternion.identity);
    }

    
}
