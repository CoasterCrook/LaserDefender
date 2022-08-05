using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthScript : MonoBehaviour
{
    [SerializeField] public int health = 50;

    void OnTriggerEnter2D(Collider2D other) 
    {
        DamageDealer damageDealer = other.GetComponent<DamageDealer>();

        if (damageDealer != null)
        {
            damageDealer.Hit();
            TakeDamage(damageDealer.GetDamage());
            
            if (health == 0)
            {
                Destroy(gameObject);
            }
        }
    }

    void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }
}
