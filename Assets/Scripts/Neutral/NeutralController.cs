using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NeutralController : MonoBehaviour
{
    public GameObject player;
    public GameObject enemy;

    public float faith;
    public float speed;
    [SerializeField] private float timer;
    private float distance;
    
    Vector2 direction;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        enemy = GameObject.FindWithTag("Enemy");

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
        distance = Vector2.Distance(transform.position, player.transform.position);
        speed = 8f;
        if(distance > 2f)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
        }
    }

    void FollowEnemy()
    {
        distance = Vector2.Distance(transform.position, enemy.transform.position);
        speed = 5f;
        if (distance > 2f)
        {
            transform.position = Vector2.MoveTowards(transform.position, enemy.transform.position, speed * Time.deltaTime);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Wall")
        {
            Vector2 tempDirection = direction;
            direction = new Vector2(tempDirection.x * -1, tempDirection.y * -1);
        }
    }
}
