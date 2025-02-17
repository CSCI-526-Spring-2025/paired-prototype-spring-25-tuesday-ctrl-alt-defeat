using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartScene : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.LeftShift))
        {
            RestartGame();
        }
    }

    // Restart scene
    public void RestartGame()
    {
        PlayerLife.lives -= 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
