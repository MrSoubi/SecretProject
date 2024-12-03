using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [Header("ScriptableObject")]
    [SerializeField] private PlayerStats playerStats;

    [Header("References")]
    [SerializeField] private Rigidbody rb;

    private Vector3 startPosition;

    private bool isDead;
    private bool isMoving;

    private Coroutine courotineMove;

    private void Start()
    {
        startPosition = transform.position;
        playerStats.Position = startPosition;
    }

    private void OnEnable()
    {
        playerStats.OnWin += OnPlayerWin;
        playerStats.OnDeath += OnPlayerDead;
    }

    private void OnDisable()
    {
        playerStats.OnWin -= OnPlayerWin;
        playerStats.OnDeath -= OnPlayerDead;
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
            Vector3 movement = new Vector3(touchPress.x, 0f, touchPress.y) * playerStats.Speed;
            rb.MovePosition(rb.position + movement * Time.deltaTime);

            playerStats.Position = transform.position;

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

            Vector2 inputDirection = ctx.ReadValue<Vector2>();

            courotineMove = StartCoroutine(MovePlayer(inputDirection));
        }
        else if (ctx.canceled)
        {
            isMoving = false;
        }
    }

    /// <summary>
    /// Player Win
    /// </summary>
    private void OnPlayerWin()
    {
        transform.position = startPosition;

        playerStats.Position = transform.position;
    }

    /// <summary>
    /// Player Dead
    /// </summary>
    private void OnPlayerDead()
    {
        isDead = true;
    }
}
