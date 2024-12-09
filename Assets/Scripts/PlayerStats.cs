using UnityEngine;
using System;

[CreateAssetMenu(fileName = "PlayerStats", menuName = "Player Stats")]
public class PlayerStats : ScriptableObject
{
    [SerializeField] private Vector3 pos;
    [SerializeField] private int health;
    [SerializeField] private float speed;

    public event Action OnLooseHealth;
    public event Action OnDeath;
    public event Action OnWin;

    public Vector3 Position
    {
        get => pos;
        set => pos = value;
    }

    public int Health
    {
        get => health;
        set => health = value;
    }

    public float Speed
    {
        get => speed;
        set => speed = value;
    }

    public void TakeDamage(int damage)
    {
        Health -= damage;

        OnLooseHealth?.Invoke();

        if (health <= 0)
        {
            OnDeath?.Invoke();
        }
    }

    public void Win()
    {
        OnWin?.Invoke();
    }
}
