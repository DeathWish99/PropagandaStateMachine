using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Conversion ray script for Enemy. Shares a lot with PlayerConversionRay, but fine tuned
/// for the Enemy.
/// </summary>
public class EnemyConversionRay : MonoBehaviour
{
    EnemyController controller;

    public List<GameObject> neutrals;
    public GameObject ray;
    
    SpriteRenderer rayColor;

    
    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponentInParent<EnemyController>();

        rayColor = GetComponentInChildren<SpriteRenderer>();
        rayColor.color = new Color(1f, 0f, 0f, .3f);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Neutral")
        {
            neutrals.Add(collision.gameObject);
        }
    }

    //Converts Neutral to Enemy Slave.
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Neutral")
        {
            for (int i = 0; i < neutrals.Count; i++)
            {
                neutrals[i].GetComponent<NeutralController>().faith -= 0.65f;

                if (neutrals[i].GetComponent<NeutralController>().faith <= 0)
                {
                    if(neutrals[i].tag == "PlayerConverted") //This is so the enemy doesn't stick to a neutral that has been converted by the player.
                    {
                        break;
                    }
                    neutrals[i].tag = "EnemyConverted";
                    neutrals[i].GetComponent<SpriteRenderer>().material.SetColor("_Color", Color.red);
                    neutrals[i].GetComponent<NeutralController>().tagChange = true;
                    //Debug.Log(neutrals[i].tag);
                    neutrals.Remove(neutrals[i]);
                    controller.FindClosest(true);
                }
                
            }
        }
        if (collision.tag == "PlayerConverted") //Makes sure that it always searches for neutrals.
        {
            controller.FindClosest(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        neutrals.Remove(collision.gameObject);
    }
}
