using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class HealthSystem : MonoBehaviour
{
    [SerializeField]
    float maxHealth = 100f;
    [SerializeField]
    float currentHealth = 100f;
    
    [SerializeField]
    private Material hologramMaterial;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //currentHealth = maxHealth;  // Initialize health to max at the start
        
        Color greenColor = new Color(0f, 1f, 0f); // Red color
        hologramMaterial.SetColor("_Color", greenColor);
        
        UpdateVisuals();
    }

    // Update is called once per frame
    void UpdateVisuals()
    {
        float healthPercent = currentHealth / maxHealth; 
        
        float intensity = Mathf.Lerp(60f, 1f, healthPercent); // 40 -> 0       10-> .8   1 -> 1 // the less health, the more intense the hologram effect
        
        float speed = Mathf.Lerp(20f, 1f, healthPercent);
        
        //hologramMaterial.SetFloat("_Intensity", intensity);
        //hologramMaterial.SetFloat("_Speed", speed);
    }
    
    public void TakeDamage(float damage)
    {
        Debug.Log("Take Damage");
        
        currentHealth -= damage;
        currentHealth = Mathf.Max(currentHealth, 0f);
        
        UpdateVisuals();
        
        Debug.Log("Current Health: " + currentHealth);
        
        if (currentHealth <= 0f)
        {
            Die();
        }
    }
    
    public void Heal(float healAmount)
    {
        Debug.Log("Heal");
        
        currentHealth += healAmount;
        currentHealth = Mathf.Min(currentHealth, maxHealth);
        
        UpdateVisuals();
        
        Debug.Log("Current Health: " + currentHealth);
    }
    
    private void Die()
    {
        // Handle death logic here (e.g., play animation, disable character, etc.)
        Debug.Log("Character has died.");
        
        Color redColor = new Color(1f, 0f, 0f); // Red color
        hologramMaterial.SetColor("_Color", redColor); // Change color to red on death
        
        // For example, you could disable the GameObject:
        // gameObject.SetActive(false);
    }
}
