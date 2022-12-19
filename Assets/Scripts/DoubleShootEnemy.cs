using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//INHERITANCE
public class DoubleShootEnemy : BasicEnemy
{

    private float secondShotCooldown = 0.5f;

    //POLYMORPHISM
    public override void Shoot()
    {
        base.Shoot();

        StartCoroutine(SecondShotRoutine());

    }

    private IEnumerator SecondShotRoutine()
    {

        yield return new WaitForSeconds(secondShotCooldown);

        base.Shoot();

    }

}
