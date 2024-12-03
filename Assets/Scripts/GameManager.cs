using UnityEngine;

public class GameManager : MonoBehaviour
{
    public PlayerStats playerStats;

    public GameObject trapPrefab;
    public BoxCollider spawnArea;
    public int numberOfTraps;
    public float spawnRadius;
    public LayerMask trapLayer;

    private void Start()
    {
        SpawnTraps();
    }

    void SpawnTraps()
    {
        Vector3 trapSize = trapPrefab.GetComponent<Renderer>().bounds.size;

        int spawnedTraps = 0;
        while (spawnedTraps < numberOfTraps)
        {
            Vector3 randomPosition = GetRandomPositionInBox(trapSize);
            if (!IsPositionOccupied(randomPosition))
            {
                Instantiate(trapPrefab, randomPosition, Quaternion.identity);
                spawnedTraps++;
            }
        }
    }

    Vector3 GetRandomPositionInBox(Vector3 trapSize)
    {
        Bounds bounds = spawnArea.bounds;

        float x = Random.Range(bounds.min.x + trapSize.x / 2, bounds.max.x - trapSize.x / 2);
        float y = Random.Range(bounds.min.y + trapSize.y / 2, bounds.max.y - trapSize.y / 2);
        float z = Random.Range(bounds.min.z + trapSize.z / 2, bounds.max.z - trapSize.z / 2);

        return new Vector3(x, 0.5f, z);
    }

    bool IsPositionOccupied(Vector3 position)
    {
        Collider[] hitColliders = Physics.OverlapSphere(position, spawnRadius, trapLayer);
        return hitColliders.Length > 0;
    }

    private void OnDisable()
    {
        playerStats.pos = new Vector3(0, 1.5f, 0);
        playerStats.health = 100;
        playerStats.speed = 5;
    }
}
