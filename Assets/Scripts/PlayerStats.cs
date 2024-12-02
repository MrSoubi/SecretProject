using UnityEngine;
using UnityEngine.Events;
using System;

[CreateAssetMenu(fileName = "PlayerStats", menuName = "Player Stats")]
public class PlayerStats : ScriptableObject
{
    public Vector3 pos;

    public float health;

    public float speed;

    public Action Death;

    public void Position(Vector3 position)
    {
        pos = position;
    }

    public void TakeDamage(float damage)
    {
        health -= damage;

        if(health <= 0)
        {
            health = 0;

            Death?.Invoke();
        }
    }
}
