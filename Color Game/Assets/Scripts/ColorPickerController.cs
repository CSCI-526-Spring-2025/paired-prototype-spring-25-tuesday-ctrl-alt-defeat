using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorPickerController : MonoBehaviour
{

    // Private variables

    // Assigned to the renderer of current obstacle
    private SpriteRenderer spriteRenderer;
    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void OnMouseDown()
    {
        if(spriteRenderer != null)
        {
            ColorData.currentColor = spriteRenderer.color;
        }
    }
}
