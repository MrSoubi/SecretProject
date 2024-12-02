using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public PlayerStats playerStats;

    public Rigidbody rb;

    private bool isMoving;
    private bool isDead;

    private Coroutine courotineMove;

    private void Start()
    {
        playerStats.Death += OnPlayerDeath;
    }

    /// <summary>
    /// Move the Player
    /// </summary>
    /// <param name="touchPress"></param>
    /// <returns></returns>
    private IEnumerator MovePlayer(Vector2 touchPress)
    {
        while(isMoving && !isDead)
        {
            playerStats.Position(transform.position);

            Vector3 movement = new Vector3(touchPress.x, 0f, touchPress.y) * playerStats.speed;
            rb.MovePosition(rb.position + movement * Time.deltaTime);

            yield return null;
        } 
    }

    /// <summary>
    /// Arrow Key
    /// </summary>
    /// <param name="ctx"></param>
    public void Move(InputAction.CallbackContext ctx)
    {
        if(ctx.performed && !isDead)
        {
            if(courotineMove != null)
            {
                StopCoroutine(courotineMove);
            }

            isMoving = true;

            Vector2 touchPress = ctx.ReadValue<Vector2>();

            courotineMove = StartCoroutine(MovePlayer(touchPress));
        }
        else if (ctx.canceled)
        {
            isMoving = false;
        }
    }

    /// <summary>
    /// Player Dead
    /// </summary>
    private void OnPlayerDeath()
    {
        isDead = true;
    }
}
