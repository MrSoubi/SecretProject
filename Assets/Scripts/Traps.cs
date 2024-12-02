using UnityEngine;

public class Traps : MonoBehaviour
{
    public PlayerStats playerStats;

    public float damage;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerStats.TakeDamage(damage);

            Destroy(gameObject);
        }
    }
}
