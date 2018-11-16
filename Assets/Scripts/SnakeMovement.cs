using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeMovement : MonoBehaviour
{

    private float turn = 0.0f;
    private float turnTrigger = 0.0f;
    private bool canTurn = true;
    private int timeout;
    public int speed;
    public float step;

    private Vector3 currentRotation, targetRotation;


    void Start()
    {
        timeout = 30 - speed;
    }

    void Update ()
    {
        turn = Input.GetAxisRaw("Horizontal");

        if (turnTrigger == 0.0f && turn != 0)
        {
            turnTrigger = turn;
        }

        if (Input.GetButtonUp("Horizontal")) {
            canTurn = true;
        }
    }

    void FixedUpdate()
    {
        timeout--;
        if (timeout == 0)
        {
            timeout = 30 - speed;
            if (turnTrigger != 0 && canTurn)
            {
                Turn();
                turnTrigger = 0.0f;
                canTurn = false;
            }
            MoveForward();
        }
    }

    void MoveForward()
    {
        transform.position += transform.forward * step;
    }

    void Turn()
    {
        currentRotation = transform.eulerAngles;
        targetRotation.y = (currentRotation.y + (90 * turnTrigger));
        transform.eulerAngles = targetRotation;
    }

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Orb")
        {
            Destroy(col.gameObject);
        }
    }

}
