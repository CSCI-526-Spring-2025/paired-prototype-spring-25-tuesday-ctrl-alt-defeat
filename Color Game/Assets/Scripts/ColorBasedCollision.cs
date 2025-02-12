using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorBasedCollision : MonoBehaviour
{
    private SpriteRenderer spriteRenderer; 
    private Collider2D objCollider;
    private Color lastColor;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        objCollider = GetComponent<Collider2D>();
        lastColor = spriteRenderer.color;
    }

    void Update()
    {
        if (spriteRenderer.color != lastColor)
        {
            // Color changed, re-enable collisions with all objects
            ReenableCollisions();
            lastColor = spriteRenderer.color;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        ColorBasedCollision other = collision.gameObject.GetComponent<ColorBasedCollision>();
        Debug.Log("Collision detected with " + collision.gameObject.name);

        if (other != null && spriteRenderer != null && other.spriteRenderer != null)
        {
            if (spriteRenderer.color == other.spriteRenderer.color)
            {
                // Disable collision
                Physics2D.IgnoreCollision(objCollider, other.GetComponent<Collider2D>(), true);
                Debug.Log("Collision ignored due to matching colors.");
            }
            else
            {
                // Enable collision
                Physics2D.IgnoreCollision(objCollider, other.GetComponent<Collider2D>(), false);
                Debug.Log("Collision allowed due to different colors.");
            }
        }
    }

    void ReenableCollisions()
    {
        Collider2D[] allColliders = FindObjectsOfType<Collider2D>();
        foreach (Collider2D col in allColliders)
        {
            if (col != objCollider)
            {
                Physics2D.IgnoreCollision(objCollider, col, false);
            }
        }
        Debug.Log("Collisions re-enabled after color change.");
    }
}
