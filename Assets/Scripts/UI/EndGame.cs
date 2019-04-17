using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


/// <summary>
/// For the end panel to show
/// </summary>
public class EndGame : MonoBehaviour
{
    public Text winText;
    public Text drawText;
    public Text loseText;

    //Show end screen
    public void ShowEndScreen()
    {
        Time.timeScale = 0;
        if (gameObject.GetComponentInParent<UiControl>().playerConverted > gameObject.GetComponentInParent<UiControl>().enemyConverted)
        {
            winText.gameObject.SetActive(true);
        }
        else if (gameObject.GetComponentInParent<UiControl>().playerConverted < gameObject.GetComponentInParent<UiControl>().enemyConverted)
        {
            loseText.gameObject.SetActive(true);
        }
        else
        {
            drawText.gameObject.SetActive(true);
        }
        
    }
}
