using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    private float timeToDespawn;
    private float timeActive = 0;
    private GameObject player;
    public float projectileSpeed;

    // Start is called before the first frame update
    void Awake()
    {

        timeToDespawn = ProjectileManager.projectileDissappearanceTime;
        player = GameObject.FindGameObjectWithTag("Player");

    }

    // Update is called once per frame
    void Update()
    {

        timeActive += Time.deltaTime;

        if(timeActive > timeToDespawn)
        {

            timeActive = 0;
            gameObject.SetActive(false);

        }

    }

    private void FixedUpdate()
    {

        //Removing normalized makes projectile that catches up faster when far away from player
        transform.Translate((player.transform.position - transform.position).normalized * projectileSpeed);

    }

}
