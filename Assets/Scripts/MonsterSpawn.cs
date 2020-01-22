using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterSpawn : MonoBehaviour
{
    [SerializeField] List<GameObject> monsters = new List<GameObject>();

    void Start()
    {
        Spawn();
    }

    public void Spawn()
    {
        GameObject monster = monsters[Random.Range(0, monsters.Count)];

        var newObject = Instantiate(monster, transform.position, Quaternion.identity);
        newObject.transform.parent = gameObject.transform;
    }
}
