using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "Values", menuName = "Scriptables/Values")]
public class Probability : ScriptableObject
{
    public int minValue;
    public int maxValue;
    public GameObject objectToSpawn;
}
