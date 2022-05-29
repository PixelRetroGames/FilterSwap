using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    private Vector3 moveVelocity;
    public float speed;
    void Start()
    {

    }

    void Update() 
    {

        moveVelocity = new Vector3(0, 0, 0);

        //Left Right Movement
        if (Input.GetKey (KeyCode.LeftArrow) || Input.GetKey (KeyCode.A)) 
        {
            moveVelocity = new Vector3(-speed, 0, 0);
            
        }
        if (Input.GetKey (KeyCode.RightArrow) || Input.GetKey (KeyCode.D)) 
        {
            moveVelocity = new Vector3(speed, 0, 0);
        }

        if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W))
        {
            moveVelocity = new Vector3(0, speed, 0);
        }


        if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S))
        {
            moveVelocity = new Vector3(0, -speed, 0);
        }
        
        transform.Translate(moveVelocity * Time.deltaTime);

    }


}