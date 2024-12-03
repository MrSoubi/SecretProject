using UnityEngine;

public class Win : MonoBehaviour
{
    [Header("ScriptableObject")]
    [SerializeField] private PlayerStats playerStats;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerStats.Win();
        }
    }
}
