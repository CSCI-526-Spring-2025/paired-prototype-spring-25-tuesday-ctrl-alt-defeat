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
        if(Input.GetKeyDown(KeyCode.LeftShift) && !PlayerLife.gameLost)
        {
            RestartGame();
        }
    }

    // Restart scene
    public void RestartGame()
    {
        if(!PlayerLife.gameLost) PlayerLife.lives -= 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
