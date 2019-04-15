using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerConversionRay : MonoBehaviour
{
    public List<GameObject> neutrals;
    public GameObject ray;

    //SpriteRenderer playerColor;
    SpriteRenderer rayColor;
    Vector3 dir;

    float angle;
    float timer;

    public int playerConverted;

    // Start is called before the first frame update
    void Start()
    {
        
        //playerColor = GetComponentInParent<SpriteRenderer>(); //Obsolete. Wanted to use this to get the player color.
        rayColor = GetComponentInChildren<SpriteRenderer>();
        rayColor.color = new Color(0f, 1f, 1f, .3f);

        playerConverted = 0;
    }

    // Update is called once per frame
    void Update()
    {
        FollowMouse();
        ConvertNeutral();
        
    }

    void FollowMouse()
    {
        dir = Input.mousePosition - Camera.main.WorldToScreenPoint(transform.position);
        angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }

    void ConvertNeutral()
    {
        if (Input.GetMouseButton(0))
        {
            timer += Time.deltaTime;
            ray.SetActive(true);
            for (int i = 0; i < neutrals.Count; i++)
            {
                neutrals[i].GetComponent<NeutralController>().faith -= 0.65f;

                if(neutrals[i].GetComponent<NeutralController>().faith <= 0)
                {
                    neutrals[i].tag = "PlayerConverted";
                    neutrals[i].GetComponent<SpriteRenderer>().material.SetColor("_Color", Color.blue);
                    if(neutrals[i].tag == "PlayerConverted")
                    {
                        playerConverted++;
                    }
                    neutrals.Remove(neutrals[i]);
                }
            }
        }
        else
        {
            ray.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Neutral")
        {
            neutrals.Add(collision.gameObject);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        neutrals.Remove(collision.gameObject);
    
    }
}
    
