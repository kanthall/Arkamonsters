using UnityEngine;

public class ProjectileSpawner : MonoBehaviour
{
    [SerializeField] Transform spawnerPosition;
    [SerializeField] GameObject projectile;
    [SerializeField] int spawnCount = 0;
    [SerializeField] int spawn = 0;

    public void SpawnOnDeath()
    {
        for (int i = 0; i <= spawnCount; i++)
        {
            if (spawn <= spawnCount)
            {
                Instantiate(projectile, transform.position, Quaternion.identity);
                spawn++;
            }
        }
    }
}
