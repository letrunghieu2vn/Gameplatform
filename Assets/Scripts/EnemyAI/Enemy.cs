using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int health = 100;
    public float eDamage;
    public GameObject deathEffect;
    public Transform mySpawnPoint;
    private HealthBar playerHealth;

    public void TakeDamage(int damage)
    {
        health -= damage;

        if (health <= 0)
        {
            SpawnPoint.instance.ChangeTime(mySpawnPoint);
            Die();
        }
    }

    internal void ChangeHp(float damage)
    {
        throw new NotImplementedException();
    }

    void Die()
    {
        //Instantiate(deathEffect, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.layer == 12)
        {
            playerHealth = collision.GetComponent<HealthBar>();
            playerHealth.TakeDamage(eDamage);
        }    
    }
}
 
