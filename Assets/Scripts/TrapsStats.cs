using UnityEngine;

[CreateAssetMenu(fileName = "TrapsStats", menuName = "Traps Stats")]
public class TrapsStats : ScriptableObject
{
    [SerializeField] private float damage;

    public float Damage
    {
        get => damage;
    }
}
