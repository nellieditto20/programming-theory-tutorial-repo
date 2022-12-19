using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicEnemy : MonoBehaviour
{

    [SerializeField] private GameObject projectileManagerGameObject;
    private ProjectileManager projectileManager;
    private float cooldownTime = 1.5f;

    // Start is called before the first frame update
    void Start()
    {

        projectileManager = projectileManagerGameObject.GetComponent<ProjectileManager>();
         InvokeRepeating("Shoot", cooldownTime, cooldownTime);
        
    }

    // Update is called once per frame
    void Update()
    {

       

    }

    public virtual void Shoot()
    {

        projectileManager.SpawnProjectile(transform.position);

    }

}
