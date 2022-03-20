using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Actor
{
    public GameObject deathEffect;
    public Transform mySpawnPoint;

    public override void ChangeHealth(float valueChange)
    {
        base.ChangeHealth(valueChange);
        if (m_Health <= 0)
        {
            SpawnPoint.instance.ChangeTime(mySpawnPoint);
            Die();
        }
    }

    void Die()
    {
        //Instantiate(deathEffect, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }

}
 
