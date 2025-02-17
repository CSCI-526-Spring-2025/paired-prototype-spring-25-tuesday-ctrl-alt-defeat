using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LifeCounter : MonoBehaviour
{
    public TextMeshProUGUI livesText;
    public TMP_Text loseMessageText;
    public GameObject playerObj;

    private bool gameLost = false;
    // Start is called before the first frame update
    void Start()
    {
        UpdatePlayerLives();
    }

    // Update is called once per frame
    void Update()
    {
        if(!gameLost) UpdatePlayerLives();
    }

    void UpdatePlayerLives()
    {
        if(PlayerLife.lives == 0)
        {   
            gameLost = true;
            LoseGame();
        }
        livesText.text = "<b>LIVES: " + PlayerLife.lives + "</b>";
        livesText.color = Color.red;
    }

    void LoseGame()
    {
        Debug.Log("You Win!");

        // Get the player's Rigidbody2D component
        Rigidbody2D rb = playerObj.GetComponent<Rigidbody2D>();

        // Stop the player by freezing their velocity
        rb.velocity = Vector2.zero;  // Stop movement

        // Optionally, freeze the Rigidbody2D entirely (stop all motion)
        rb.constraints = RigidbodyConstraints2D.FreezeAll;
        
        // Update the UI message with the static variable
        loseMessageText.text = "<b>You Lose :(</b>";
        loseMessageText.color = Color.green;

        RectTransform textTransform = loseMessageText.GetComponent<RectTransform>();
        textTransform.anchoredPosition += new Vector2(300, -100);  

        loseMessageText.gameObject.SetActive(true);

        Time.timeScale = 0;
    }
}
