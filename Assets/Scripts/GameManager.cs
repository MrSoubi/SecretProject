using UnityEngine;

public class GameManager : MonoBehaviour
{
    public PlayerStats playerStats;

    private void OnDisable()
    {
        playerStats.pos = new Vector3(0, 1.5f, 0);
        playerStats.health = 100;
        playerStats.speed = 5;
    }
}
