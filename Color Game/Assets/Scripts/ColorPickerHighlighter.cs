using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColorPickerHighlighter : MonoBehaviour
{
    public GameObject[] colorCircles; // Array of color circle sprites
    private GameObject selectedCircle; // To store the currently selected circle

    private void Update()
    {
        // Listen for mouse click
        if (Input.GetMouseButtonDown(0))  // 0 means left mouse button
        {
            DetectClick();
        }
    }

    private void DetectClick()
    {
        // Create a ray from the mouse position
        RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);

        // Check if the ray hit anything
        if (hit.collider != null)
        {
            // If the clicked object has a SpriteRenderer and is one of the color circles
            if (hit.collider.gameObject.CompareTag("ColorCircle"))
            {
                OnColorCircleClick(hit.collider.gameObject);
            }
        }
    }

    public void OnColorCircleClick(GameObject clickedCircle)
    {
        // If there's already a selected circle, reset its state
        if (selectedCircle != null)
        {
            ResetCircle(selectedCircle);
        }

        // Set the clicked circle as the new selected one
        selectedCircle = clickedCircle;

        // Highlight the clicked circle
        HighlightCircle(clickedCircle);
    }

    private void HighlightCircle(GameObject circle)
    {
        // Change the scale to highlight
        circle.transform.localScale = Vector3.one * 1.3f;  // Slightly increase the scale

        // Add or modify the outline component
        Outline outline = circle.GetComponent<Outline>();
        if (outline == null)
        {
            // If no Outline component exists, add one
            outline = circle.AddComponent<Outline>();
        }
        outline.effectColor = Color.yellow;  // Set outline color
        outline.effectDistance = new Vector2(10f, 10f); // Adjust the thickness of the outline
    }

    private void ResetCircle(GameObject circle)
    {
        // Reset the circle to its original state (scale, color, and outline)
        circle.transform.localScale = Vector3.one;  // Reset scale

        // Remove the outline if it exists
        Outline outline = circle.GetComponent<Outline>();
        if (outline != null)
        {
            Destroy(outline);  // Remove the outline component
        }
    }
}
