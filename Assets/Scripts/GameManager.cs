using UnityEngine;

public class GameManager : MonoBehaviour
{
    public PlayerStats playerStats;

    public GameObject trapPrefab;
    public BoxCollider spawnArea;
    public int numberOfTraps;

    private void Start()
    {
        SpawnTraps();
    }

    void SpawnTraps()
    {
        for (int i = 0; i < numberOfTraps; i++)
        {
            Vector3 randomPosition = GetRandomPositionInBox();
            Instantiate(trapPrefab, randomPosition, Quaternion.identity);
        }
    }

    Vector3 GetRandomPositionInBox()
    {
        Bounds bounds = spawnArea.bounds;

        float x = Random.Range(bounds.min.x, bounds.max.x);
        float y = Random.Range(bounds.min.y, bounds.max.y);
        float z = Random.Range(bounds.min.z, bounds.max.z);

        return new Vector3(x, 0.5f, z);
    }

    private void OnDisable()
    {
        playerStats.pos = new Vector3(0, 1.5f, 0);
        playerStats.health = 100;
        playerStats.speed = 5;
    }
}
