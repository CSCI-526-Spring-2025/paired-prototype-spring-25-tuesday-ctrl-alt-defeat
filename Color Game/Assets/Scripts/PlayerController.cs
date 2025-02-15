using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Public Variables

    // Speed of movement
    public float speed = 10f;
    // Determines how much player can jump
    public float jumpForce = 10f;

    // Assigned to groundcheck object
    public Transform groundCheck;
    // Radius used to check if player is grounded
    public float checkRadius = 0.2f;
    // Assigned to the ground
    public LayerMask groundLayer;

    // Private Variables

    // Stores current rigid body
    private Rigidbody2D rb;
    // Stores horizontal movement input
    private float moveInput;
    // Flag to check if player is grounded
    private bool isGrounded;
    // sprite renderer
    private SpriteRenderer spriteRenderer;
    // default color - gray
    private Color defaultColor = Color.gray;
    private float resetTime = 3f;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.freezeRotation = true;
        spriteRenderer = spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.color = defaultColor;
        
    }

    void Update()
    {
        // Gets movement input
        moveInput = Input.GetAxis("Horizontal"); // Get input (-1, 0, 1)

        // Makes player jump
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }
    }

    void FixedUpdate()
    {
        // Moves player
        rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);

        // check if player is grounded
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, groundLayer);
    }

    void OnMouseDown()
    {
        if (spriteRenderer != null)
        {
            // logic to paint the player
            if ( ColorData.currentColor == Color.white || ColorData.currentColor == Color.black || spriteRenderer.color == Color.gray || spriteRenderer.color == Color.white || spriteRenderer.color == Color.black )
                spriteRenderer.color = ColorData.currentColor;
            else {
                spriteRenderer.color = Color.Lerp(spriteRenderer.color, ColorData.currentColor, 0.5f);
            }

           Invoke("ResetColor", resetTime);
        }
    }

    // resets color
    void ResetColor()
    {
        if (spriteRenderer != null)
        {
            spriteRenderer.color = defaultColor;
        }
    }

}
