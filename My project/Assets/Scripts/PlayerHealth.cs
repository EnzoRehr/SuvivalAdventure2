using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [Header("Settings")]
    public float maxHealth; 
    public HealthBar healthBar;
    public float currentHealth;

    private void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetSliderMax(maxHealth);
    }

    public void TakeDamage(float amount)
    {
        currentHealth -= amount;
        healthBar.SetSlider(currentHealth);
    }


    public void Heal(float amount)
    {

        currentHealth += amount;
        currentHealth = Mathf.Min(currentHealth, maxHealth);
        healthBar.SetSlider(currentHealth);
    }

    private void FixedUpdate()
    {
        healthBar.SetSlider(currentHealth);
    }


    private void Update()
    {
        if (currentHealth <=0)
        {
            Die();
        }
    }
    private void Die()
    {
        Debug.LogError("You died");
        // Set the parent GameObject to inactive
        Transform playerParent = transform.parent;
        if (playerParent != null)
        {
            playerParent.gameObject.SetActive(false);
        }
        else
        {
            Debug.LogWarning("The Player GameObject does not have a parent.");
        }
    }
}
