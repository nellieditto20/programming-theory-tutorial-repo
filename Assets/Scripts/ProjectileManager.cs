using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileManager : MonoBehaviour
{

    [SerializeField] private GameObject[] projectileArray;
    public int maxProjectilesInScene = 7;
    private GameObject[] spawnedProjectiles;
    public static int projectilesSpawned { private set; get; } = 0;
    public static int nextProjectileToReuse = 0;
    public static float projectileDissappearanceTime { get; } = 4f;

    // Start is called before the first frame update
    void Start()
    {

        spawnedProjectiles = new GameObject[maxProjectilesInScene];

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SpawnProjectile(Vector3 SpawnPos)
    {

        if (projectilesSpawned < spawnedProjectiles.Length)
        {

            GameObject newProjectile = Instantiate(projectileArray[0], SpawnPos, projectileArray[0].transform.rotation);
            spawnedProjectiles[projectilesSpawned] = newProjectile;
            projectilesSpawned++;

        }
        else
        {

            if (nextProjectileToReuse >= spawnedProjectiles.Length)
            {
                
                nextProjectileToReuse = 0;

            }

            spawnedProjectiles[nextProjectileToReuse].transform.position = SpawnPos;
            spawnedProjectiles[nextProjectileToReuse].SetActive(true);

            nextProjectileToReuse++;

        }

    }

}
