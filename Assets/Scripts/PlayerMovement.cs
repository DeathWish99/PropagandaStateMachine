using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed;

    private Vector3 movement;
    // Update is called once per frame
    void Update()
    {
        Movement();
    }

    void Movement()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        movement = new Vector3(horizontal, vertical, 0);

        transform.Translate(movement * speed * Time.deltaTime, Space.World);

    }
}
