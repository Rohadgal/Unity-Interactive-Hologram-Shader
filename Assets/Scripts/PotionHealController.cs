using UnityEngine;

public class PotionHealController : MonoBehaviour
{
    [SerializeField] private float heal = 10f;
    bool canHeal = true;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag != "Player") {
            return;
        }
        
        HealthSystem health =
            other.GetComponent<HealthSystem>();

        if (health != null && canHeal)
        {
            health.Heal(heal);
            canHeal = false;
        }
    }
    
    private void OnTriggerExit(Collider other)
    {
        if (other.tag != "Player") {
            return;
        }
        
        canHeal = true;
    }
}
