using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EndGame : MonoBehaviour
{
    private TextControl canvas;
    
    public Text winText;
    public Text drawText;
    public Text loseText;
    // Start is called before the first frame update
    void Start()
    {
        canvas = gameObject.GetComponentInParent<TextControl>();
        gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ShowEndScreen()
    {
        gameObject.SetActive(true);
        Time.timeScale = 0;
        if(canvas.playerConverted > canvas.enemyConverted)
        {
            loseText.gameObject.SetActive(false);
            drawText.gameObject.SetActive(false);
        }
        else if(canvas.playerConverted < canvas.enemyConverted)
        {
            winText.gameObject.SetActive(false);
            drawText.gameObject.SetActive(false);
        }
        else
        {
            winText.gameObject.SetActive(false);
            loseText.gameObject.SetActive(false);
        }
    }
}
