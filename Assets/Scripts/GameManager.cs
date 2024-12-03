using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [Header("ScriptableObject")]
    [SerializeField] private PlayerStats playerStats;
    [SerializeField] private MapsInfos mapInfos;

    [Header("Traps")]
    [SerializeField] private GameObject trapPrefab;
    [SerializeField] private int numberOfTraps;
    [SerializeField] private float spawnRadius;
    [SerializeField] private LayerMask trapLayer;

    private List<GameObject> traps = new List<GameObject>();

    private Vector3 posPlayer;
    private float healthPlayer;
    private float speedPlayer;

    private void Start()
    {
        SavePlayerStats();

        SpawnTraps();
    }

    private void OnEnable()
    {
        playerStats.OnWin += OnPlayerWin;
    }

    private void OnDisable()
    {
        playerStats.OnWin -= OnPlayerWin;

        playerStats.Position = posPlayer;
        playerStats.Health = healthPlayer;
        playerStats.Speed = speedPlayer;

        mapInfos.Map = null;
        mapInfos.Bounds = new Bounds(Vector3.zero, Vector3.zero);
    }

    /// <summary>
    /// Save the Player Stats at Initialisation
    /// </summary>
    private void SavePlayerStats()
    {
        posPlayer = playerStats.Position;
        healthPlayer = playerStats.Health;
        speedPlayer = playerStats.Speed;
    }

    /// <summary>
    /// Spawn Traps
    /// </summary>
    private void SpawnTraps()
    {
        Vector3 trapSize = trapPrefab.GetComponent<Renderer>().bounds.size;

        int attempts = 0;
        int spawnedTraps = 0;

        while (spawnedTraps < numberOfTraps && attempts < numberOfTraps * 10)
        {
            Vector3 randomPosition = GetRandomPositionInBox(trapSize);

            if (!IsPositionOccupied(randomPosition))
            {
                GameObject trap = Instantiate(trapPrefab, randomPosition, Quaternion.identity, mapInfos.Map.transform);
                traps.Add(trap);

                spawnedTraps++;
            }

            attempts++;
        }
    }

    /// <summary>
    /// Get a Position in Box
    /// </summary>
    /// <param name="trapSize"></param>
    /// <returns></returns>
    private Vector3 GetRandomPositionInBox(Vector3 trapSize)
    {
        Bounds bounds = mapInfos.Bounds;

        float x = Random.Range(bounds.min.x + trapSize.x / 2, bounds.max.x - trapSize.x / 2);
        float z = Random.Range(bounds.min.z + trapSize.z / 2, bounds.max.z - trapSize.z / 2);

        return new Vector3(x, 0.5f, z);
    }

    /// <summary>
    /// Already something at the Position
    /// </summary>
    /// <param name="position"></param>
    /// <returns></returns>
    private bool IsPositionOccupied(Vector3 position)
    {
        return Physics.CheckSphere(position, spawnRadius, trapLayer);
    }

    /// <summary>
    /// Player Win
    /// </summary>
    private void OnPlayerWin()
    {
        for(int i = 0; i < traps.Count; i++)
        {
            Destroy(traps[i]);
        }

        traps.Clear();

        SpawnTraps();
    }
}
