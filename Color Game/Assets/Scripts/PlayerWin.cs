using UnityEngine;
using TMPro; // Import for TextMeshPro

public class PlayerWin : MonoBehaviour
{
    public TMP_Text winMessageText; // Drag UI TextMeshPro object here
    public GameObject playerObj;

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Win condition Met");
        WinGame();
    }

    void WinGame()
    {
        Debug.Log("You Win!");

        // Get the player's Rigidbody2D component
        Rigidbody2D rb = playerObj.GetComponent<Rigidbody2D>();

        // Stop the player by freezing their velocity
        rb.velocity = Vector2.zero;  // Stop movement

        // Optionally, freeze the Rigidbody2D entirely (stop all motion)
        rb.constraints = RigidbodyConstraints2D.FreezeAll;
        
        // Update the UI message with the static variable
        winMessageText.text = "<b>You Win! You have collected : \n" + CollectibleData.currCollectibles + " / " + CollectibleData.totalCollectibles + " collectibles!!</b>";
        winMessageText.color = Color.green;

        RectTransform textTransform = winMessageText.GetComponent<RectTransform>();
        textTransform.anchoredPosition += new Vector2(300, -100);  

        winMessageText.gameObject.SetActive(true); // Show UI Message
    }
}
