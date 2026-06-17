using UnityEngine;

public class EnemyDamageController : MonoBehaviour
{
    [SerializeField] private float damage = 10f;

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Triggered with: " + other.name);

        if (other.tag != "Player") {
            return;
        }
        
        HealthSystem health =
            other.GetComponent<HealthSystem>();

        if (health != null)
        {
            health.TakeDamage(damage);
        }
    }
}
