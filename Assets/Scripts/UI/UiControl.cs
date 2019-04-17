using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Controls all the UI elements of the game.
/// </summary>
public class UiControl : MonoBehaviour
{
    GameObject player;
    GameObject enemy;
    public GameObject endGame;

    private bool run = true; //Used to call the EndGame class so that it only runs once

    private float gameTimer;

    public int shownGameTime;
    public int enemyConverted;
    public int playerConverted;

    public Text playerConvertedText;
    public Text enemyConvertedText;
    public Text gameTimerText;
    // Start is called before the first frame update
    void Start()
    {
        enemyConverted = 0;
        playerConverted = 0;
        gameTimer = 0;
        shownGameTime = 60;
        player = GameObject.FindWithTag("Player");
        enemy = GameObject.FindWithTag("Enemy");
        SetText();
    }

    // Update is called once per frame
    void Update()
    {
        TimerControl();
        UpdateText();
    }

    //Updates text according to changes in player/enemyConverted values.
    void UpdateText()
    {
        playerConvertedText.text = "Player Slaves: " + playerConverted;
        enemyConvertedText.text = "Enemy Slaves: " + enemyConverted;
        gameTimerText.text = shownGameTime.ToString();
    }

    //Sets initial text;
    void SetText()
    {
        playerConvertedText.text = "Player Slaves: " + 0;
        enemyConvertedText.text = "Enemy Slaves: " + 0;
    }

    //Controls the global game timer.
    void TimerControl()
    {
        gameTimer += Time.deltaTime;
        if (gameTimer >= 1f)
        {
            shownGameTime -= 1;
            gameTimer = 0;
        }

        if (shownGameTime <= 0 && run)
        {
            endGame.SetActive(true);
            endGame.GetComponent<EndGame>().ShowEndScreen();
            run = false; //Set to false so it doesn't continuously call
        }
    }
}
