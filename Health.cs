using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] public float health = 100f;
    [SerializeField] GameObject deathVFX;


    public void DealDamage(float damage)
    {
        health -= damage;

        if (health <= 0)
        {
            FindObjectOfType<StarDisplay>().AddStars(10);
            TriggerDeathVFX();
            Destroy(gameObject);
        }
    }


    public void SetHealth(float newHealth)
    {
        health = newHealth;
    }
    private void TriggerDeathVFX()
    {
        if(!deathVFX) { return; }
        GameObject deathVFXObject = Instantiate(deathVFX, transform.position, Quaternion.identity);
        Destroy(deathVFXObject, 1f);
    }
}
