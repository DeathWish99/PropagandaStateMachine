using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Script that contains all enemy behaviour.
/// </summary>
public class EnemyController : MonoBehaviour
{
    public GameObject[] neutralsInWorld;
    public GameObject neutral;

    public float speed;
    
    // Start is called before the first frame update
    void Start()
    {
        neutralsInWorld = GameObject.FindGameObjectsWithTag("Neutral");
        speed = 5f;
        FindClosest(true);
    }

    // Update is called once per frame
    void Update()
    {
        MoveToNearest();
    }

    //Searches all Neutrals that are in the field, and locks in to the nearest one.
    public void FindClosest(bool isFind)
    {
        if(isFind)
        {
            neutralsInWorld = GameObject.FindGameObjectsWithTag("Neutral");
            float distance = Vector2.Distance(transform.position, neutralsInWorld[0].transform.position);
            neutral = neutralsInWorld[0];
            for (int i = 0; i < neutralsInWorld.Length; i++)
            {
                if (Vector2.Distance(transform.position, neutralsInWorld[i].transform.position) < distance)
                {
                    distance = Vector2.Distance(transform.position, neutralsInWorld[i].transform.position);
                    neutral = neutralsInWorld[i];
                }
            }
        }
    }

    //Moves to the neutral that has been locked in by FindClosest.
    public void MoveToNearest()
    {
        float angle = Mathf.Atan2(neutral.transform.position.y, neutral.transform.position.x) * Mathf.Rad2Deg;
        float distance = Vector2.Distance(transform.position, neutral.transform.position);
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
        if(distance > 1f)
        {
            transform.position = Vector2.MoveTowards(transform.position, neutral.transform.position, speed * Time.deltaTime);
        }
    }
}
