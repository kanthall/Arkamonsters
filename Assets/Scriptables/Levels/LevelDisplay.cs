using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelDisplay : MonoBehaviour
{
    public Level level;
    public Text levelNameField;

    void Start()
    {
        levelNameField.text = level.levelName;
    }
}
