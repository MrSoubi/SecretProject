using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public PlayerStats playerStats;

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(playerStats.pos.x, transform.position.y, playerStats.pos.z);
    }
}
