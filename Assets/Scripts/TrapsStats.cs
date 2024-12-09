using UnityEngine;

[CreateAssetMenu(fileName = "TrapsStats", menuName = "Traps Stats")]
public class TrapsStats : ScriptableObject
{
    [SerializeField] private int damage;

    public int Damage
    {
        get => damage;
    }
}
