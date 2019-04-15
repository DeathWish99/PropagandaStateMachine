using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextControl : MonoBehaviour
{
    GameObject player;
    GameObject enemy;

    public Text playerConvertedText;
    public Text enemyConvertedText;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        enemy = GameObject.FindWithTag("Enemy");
        SetText();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateText();
    }

    void UpdateText()
    {
        int playerConvertedCount = player.GetComponentInChildren<PlayerConversionRay>().playerConverted;
        int enemyConvertedCount = enemy.GetComponentInChildren<EnemyConversionRay>().enemyConverted;

        playerConvertedText.text = "Player Slaves: " + playerConvertedCount;
        enemyConvertedText.text = "Enemy Slaves: " + enemyConvertedCount;
    }

    void SetText()
    {
        playerConvertedText.text = "Player Slaves: " + 0;
        enemyConvertedText.text = "Enemy Slaves: " + 0;
    }
}
