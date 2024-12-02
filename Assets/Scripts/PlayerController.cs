using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public PlayerStats playerStats;

    public Rigidbody rb;

    private void FixedUpdate()
    {
        playerStats.pos = transform.position;

        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(horizontalInput, 0f, verticalInput) * playerStats.speed;

        rb.MovePosition(rb.position + movement * Time.fixedDeltaTime);
    }
}
