using UnityEngine;

public class ProjectileSpawner : MonoBehaviour
{
    [SerializeField] Transform spawnerPosition;
    [SerializeField] GameObject projectile;
    [SerializeField] int spawn = 0;

    public void SpawnOnDeath()
    {
        if (spawn == 0)
        {
            Instantiate(projectile, transform.position, Quaternion.identity);
            spawn = 1;
        }
    }
}
