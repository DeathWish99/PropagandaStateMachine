using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Script that contains all the behaviours of the Neutral gameobject.
/// </summary>
public class NeutralController : MonoBehaviour
{
    public GameObject player;
    public GameObject enemy;
    public GameObject spawner;
    public GameObject ui;

    public float faith; //Basically health
    public float speed;
    [SerializeField] private float timer; //Timer used to control when the gameobject changes directions.
    private float distance;

    public bool tagChange;

    Vector2 direction;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        enemy = GameObject.FindWithTag("Enemy");
        spawner = GameObject.FindWithTag("Spawner");
        ui = GameObject.FindWithTag("UI");

        direction = new Vector2(Random.Range(-1, 2), Random.Range(-1, 2));

        faith = 100;
        speed = 3.5f;

        tagChange = false;
    }

    // Update is called once per frame
    void Update()
    {
        OnTagChange();
        if (gameObject.tag == "Neutral")
        {
            RandomMove();
        }
        else if (gameObject.tag == "PlayerConverted")
        {
            FollowPlayer();
        }
        else if (gameObject.tag == "EnemyConverted")
        {
            FollowEnemy();
        }
    }

    //Moves randomly in all directions. Default state.
    void RandomMove()
    {
        timer += Time.deltaTime;

        if (timer > 2f)
        {
            direction = new Vector2(Random.Range(-1, 2), Random.Range(-1, 2));
            timer = 0f;
        }

        transform.Translate(direction * speed * Time.deltaTime);
    }

    //Follows the player if converted by the player
    void FollowPlayer()
    {
        distance = Vector2.Distance(transform.position, player.transform.position);
        speed = player.GetComponent<PlayerMovement>().speed;
        if (distance > 2f)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
        }
    }

    //Follows the enemy if converted by the enemy
    void FollowEnemy()
    {
        distance = Vector2.Distance(transform.position, enemy.transform.position);
        speed = enemy.GetComponent<EnemyController>().speed;
        if (distance > 2f)
        {
            transform.position = Vector2.MoveTowards(transform.position, enemy.transform.position, speed * Time.deltaTime);
        }
    }

    //Ups conversion value when the tag is changed in order to update text.
    public void OnTagChange()
    {
        if(tagChange)
        {
            if (gameObject.tag == "PlayerConverted")
            {
                ui.GetComponent<TextControl>().playerConverted += 1;
            }
            else if (gameObject.tag == "EnemyConverted")
            {
                ui.GetComponent<TextControl>().enemyConverted += 1;
            }
            spawner.GetComponent<SpawnNeutrals>().neutralCount--;
            //Debug.Log(spawner.GetComponent<SpawnNeutrals>().neutralCount);
            tagChange = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Wall") //So the gameobject doesn't stick to the wall, but bounces off of it.
        {
            Vector2 tempDirection = direction;
            direction = new Vector2(tempDirection.x * -1, tempDirection.y * -1);
        }
    }
}