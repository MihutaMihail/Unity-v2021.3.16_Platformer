using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChangeScript: MonoBehaviour
{
    // Function that quits the game 
    public void QuitGame()
    {
        Application.Quit();
        // In the unity editor, the game doesn't really close so by having "Quit Game" in the console whenever we press the
        // quit button is a good indication that code has been reached
        Debug.Log("Quit Game");
    }
    
    // Function that loads the scene of the game
    public void StartGame()
    {
        SceneManager.LoadScene("Game");
        Debug.Log("Start Game");
    }
}
