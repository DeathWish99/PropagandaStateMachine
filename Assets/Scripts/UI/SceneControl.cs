using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Controls traversal of scenes
/// </summary>
public class SceneControl : MonoBehaviour
{
    //Starts the game
    public void StartGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(1);
    }

    //Back to main menu
    public void BackToMenu()
    {
        SceneManager.LoadScene(0);
    }

    //Quits the game;
    public void Quit()
    {
        Application.Quit();
    }
}
