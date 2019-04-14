using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NeutralController : MonoBehaviour
{
    public GameObject Player;
    public GameObject Enemy;

    public float faith;
    public float speed;
    [SerializeField] private float timer;
    private float distance;
    
    Vector2 direction;
    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindWithTag("Player");
        Enemy = GameObject.FindWithTag("Enemy");

        direction = new Vector2(Random.Range(-1, 2), Random.Range(-1, 2));

        faith = 100;
        speed = 3.5f;
    }

    // Update is called once per frame
    void Update()
    {
        if(gameObject.tag == "Neutral")
        {
            RandomMove();
        }
        else if(gameObject.tag == "PlayerConverted")
        {
            FollowPlayer();
        }
        else if (gameObject.tag == "EnemyConverted")
        {
            FollowEnemy();
        }
    }

    void RandomMove()
    {
        timer += Time.deltaTime;

        if(timer > 2f)
        {
            direction = new Vector2(Random.Range(-1, 2), Random.Range(-1, 2));
            timer = 0f;
        }

        transform.Translate(direction * speed * Time.deltaTime);
    }

    void FollowPlayer()
    {
        distance = Vector2.Distance(transform.position, Player.transform.position);

        if(distance > 2f)
        {
            transform.position = Vector2.MoveTowards(transform.position, Player.transform.position, speed * Time.deltaTime);
        }
    }

    void FollowEnemy()
    {
        distance = Vector2.Distance(transform.position, Enemy.transform.position);

        if (distance > 2f)
        {
            transform.position = Vector2.MoveTowards(transform.position, Enemy.transform.position, speed * Time.deltaTime);
        }
    }
}
