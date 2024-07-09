using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public abstract class BaseEnemyHealth : MonoBehaviour, EnemyHealth
{
    public float maxHealth;
    protected float currentHealth;

    protected virtual void Start()
    {
        currentHealth = maxHealth;
    }

    public virtual void TakeDamage(float amount)
    {
        currentHealth -= amount;
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    protected virtual void Die()
    {
        // Implement death behavior
        Debug.Log($"{gameObject.name} died.");
    }
}
