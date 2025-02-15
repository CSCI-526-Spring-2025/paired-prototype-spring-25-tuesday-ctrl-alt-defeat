using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorBasedCollision : MonoBehaviour
{
    // sprite renderer of current object
    private SpriteRenderer spriteRenderer; 
    // collider
    private Collider2D objCollider;
    // tracks the previous color of the object
    private Color lastColor;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        objCollider = GetComponent<Collider2D>();
        // init color
        lastColor = spriteRenderer.color;
    }

    void Update()
    {
        //Debug.Log("My object color: " + spriteRenderer.color);
        if (spriteRenderer.color != lastColor)
        {
            // Color changed, re-enable collisions with all objects
            ReenableCollisions();
            lastColor = spriteRenderer.color;

            // detect any contact with obstacles where collisions need to be modified; eg - ground
            Collider2D[] allColliders = FindObjectsOfType<Collider2D>();
            foreach (Collider2D col in allColliders)
            {
                if (col != objCollider)
                {
                    ColorCollider(col);
                }
            }
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        ColorCollider(collision.collider);
    }

    // re-enables collisions
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
    }

    // collides if colors are different
    void ColorCollider(Collider2D otherCollider)
    {
        ColorBasedCollision other = otherCollider.GetComponent<ColorBasedCollision>();
        Debug.Log("Color1: " + spriteRenderer.color);
        Debug.Log("Color2: " + other.spriteRenderer.color);

        if (other != null && AreColorsClose(spriteRenderer.color, other.spriteRenderer.color, 0.03f))
        {
            // Disable collision
            Physics2D.IgnoreCollision(objCollider, otherCollider, true);
            Debug.Log("Ignoring collision with " + otherCollider.gameObject.name);
        }
        else
        {
            // Enable collision
            Physics2D.IgnoreCollision(objCollider, otherCollider, false);
        }
    }

    bool AreColorsClose(Color color1, Color color2, float tolerance)
    {
        return Mathf.Abs(color1.r - color2.r) < tolerance &&
           Mathf.Abs(color1.g - color2.g) < tolerance &&
           Mathf.Abs(color1.b - color2.b) < tolerance &&
           Mathf.Abs(color1.a - color2.a) < tolerance; 
    }
}
