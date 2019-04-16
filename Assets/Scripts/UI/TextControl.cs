using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextControl : MonoBehaviour
{
    GameObject player;
    GameObject enemy;
    public GameObject endGame;

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
        gameTimer += Time.deltaTime;
        if(gameTimer >= 1f)
        {
            shownGameTime -= 1;
            gameTimer = 0;
        }

        if(shownGameTime <= 0)
        {
            endGame.GetComponent<EndGame>().ShowEndScreen();
        }

        UpdateText();
    }

    void UpdateText()
    {
        playerConvertedText.text = "Player Slaves: " + playerConverted;
        enemyConvertedText.text = "Enemy Slaves: " + enemyConverted;
        gameTimerText.text = shownGameTime.ToString();
    }

    void SetText()
    {
        playerConvertedText.text = "Player Slaves: " + 0;
        enemyConvertedText.text = "Enemy Slaves: " + 0;
    }
}
