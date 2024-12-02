using UnityEngine;

[CreateAssetMenu(fileName = "PlayerStats", menuName = "Player Stats")]
public class PlayerStats : ScriptableObject
{
    public Vector3 pos;

    public float health;

    public float speed;
}
