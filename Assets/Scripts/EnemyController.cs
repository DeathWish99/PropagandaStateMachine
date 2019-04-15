using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public GameObject[] neutrals;
    public GameObject neutral;

    public float speed;
    
    // Start is called before the first frame update
    void Start()
    {
        neutrals = GameObject.FindGameObjectsWithTag("Neutral");
        speed = 5f;
        FindClosest(true);
    }

    // Update is called once per frame
    void Update()
    {
        MoveToNearest();
    }

    public void FindClosest(bool isFind)
    {
        if(isFind)
        {
            neutrals = GameObject.FindGameObjectsWithTag("Neutral");
            float distance = Vector2.Distance(transform.position, neutrals[0].transform.position);
            neutral = neutrals[0];
            for (int i = 0; i < neutrals.Length; i++)
            {
                if (Vector2.Distance(transform.position, neutrals[i].transform.position) < distance)
                {
                    distance = Vector2.Distance(transform.position, neutrals[i].transform.position);
                    neutral = neutrals[i];
                }
            }
        }
    }

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
