using UnityEngine;

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
        currentHealth = maxHealth;  // Initialize health to max at the start
        
        Color greenColor = new Color(1f, 0f, 1f); // Magenta color
        hologramMaterial.SetColor("_Color", greenColor);
        
        UpdateVisuals();
    }

    //********************************///////////*********************************************************//
    //                                UPDATE SHADER                  
    //********************************///////////*********************************************************//
    // Update is called once per frame
    void UpdateVisuals()
    {
        float healthPercent = currentHealth / maxHealth; //  0 / 100 = 0   50 / 100 = .5   100 / 100 = 1 
        
        float speed = Mathf.Lerp(20f, 1f, healthPercent);
        //   0     .25    .5     .75     1     -  HEALTH PERCENTAGE
        //  20     15     10      5      1     -  SPEED     
        float intensity = Mathf.Lerp(60f, 1f, healthPercent);  // the LOWER the health, the HIGHER the brightness 
        //   0     .25    .5     .75     1     -  HEALTH PERCENTAGE
        //  20     15     10      5      1     -  INTENSITY     
        
        hologramMaterial.SetFloat("_Speed", speed);
        hologramMaterial.SetFloat("_Intensity", intensity);
  
    }
    //********************************///////////*********************************************************//
    public void TakeDamage(float damage)
    {
        Debug.Log("Take Damage");
        
        currentHealth -= damage;
        currentHealth = Mathf.Max(currentHealth, 0f);
        
        UpdateVisuals();
        
        Debug.Log("Current Health: " + currentHealth);
        
        if (currentHealth <= 0f)
        {
            //Die();
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
