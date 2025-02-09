using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleController : MonoBehaviour
{
    // Public variables

    // Assigned to the background sprite
    public SpriteRenderer backgroundSprite;


    // Private variables

    // Assigned to the renderer of current obstacle
    private SpriteRenderer spriteRenderer;
    // Assigned to the collider of current obstacle
    private Collider2D spriteCollider;
    
    void Start()
    {
        // Get the SpriteRenderer and Collider components
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteCollider = GetComponent<Collider2D>();
    }

    void OnMouseDown()
    {
        if (spriteRenderer != null)
        {
            // Change the sprite color to white
            // Temporary implementation to change to white; has to be a selectable color
            spriteRenderer.color = Color.white;
        }

        if (backgroundSprite != null && spriteRenderer != null)
        {
            // Check if the background is also white
            if (backgroundSprite.color == Color.white)
            {
                // Disable collision detection
                if (spriteCollider != null)
                {
                    spriteCollider.enabled = false;
                }
            }
        }
    }
}
