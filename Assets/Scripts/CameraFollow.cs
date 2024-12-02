using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public PlayerStats playerStats;

    private void Update()
    {
        transform.position = new Vector3(playerStats.pos.x, transform.position.y, playerStats.pos.z);
    }
}
