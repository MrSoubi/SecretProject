using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [Header("ScriptableObject")]
    [SerializeField] private PlayerStats playerStats;

    private void LateUpdate()
    {
        Move();
    }

    /// <summary>
    /// Move the Camera to the Player
    /// </summary>
    private void Move()
    {
        Vector3 targetPosition = new Vector3(playerStats.Position.x, transform.position.y, playerStats.Position.z);
        transform.position = Vector3.Lerp(transform.position, targetPosition, 1);
    }
}
