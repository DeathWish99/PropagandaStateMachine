using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Script used to control Neutral spawning.
/// </summary>
public class SpawnNeutrals : MonoBehaviour
{
    public GameObject neutral;
    public GameObject group;

    private Vector3 spawnPos;

    public int neutralCount;
    private int neutralLimit;
    // Start is called before the first frame update
    private void Awake()
    {
        neutralLimit = 30;
        SpawnerControl();
    }
    // Update is called once per frame
    void Update()
    {
        SpawnWhenEmpty();
    }

    void SpawnerControl()
    {
        for(int i = 0; i < neutralLimit; i++)
        {
            spawnPos = new Vector3(Random.Range(-20f, 20f), Random.Range(-20f, 20f), 0);
            Instantiate(neutral, spawnPos, Quaternion.identity, group.transform);
            neutralCount++;
        }
    }

    void SpawnWhenEmpty()
    {
        if (neutralCount <= 10)
        {
            SpawnerControl();
        }
    }
}
