using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRespawn : MonoBehaviour
{
    // sprite renderer
    private SpriteRenderer spriteRenderer;
    // record start position for respawn
    private Vector3 startPosition;

    // Start is called before the first frame update
    void Start()
    {
       startPosition = transform.position+ new Vector3(0, 2f, 0);
       spriteRenderer = GetComponent<SpriteRenderer>(); 
    }

    // Update is called once per frame
    void Update()
    {
        //if paint player in white then restart
        Color currentColor = spriteRenderer.color;
        if (IsColorWhite(currentColor))
        {
            Respawn(); 
        }
        // if fall, restart
        if (transform.position.y < -17f) { 
            Respawn();
        }

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Spike"))
        {
            Respawn();
        }
    }

    bool IsColorWhite(Color color)
    {
        return color.r > 0.95f && color.g > 0.95f && color.b > 0.95f;
    }

    void Respawn()
    {
        transform.position = startPosition;
        spriteRenderer.color = Color.gray;
    }
}
