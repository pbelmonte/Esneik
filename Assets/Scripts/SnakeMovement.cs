using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeMovement : MonoBehaviour
{

    public float speed = 3.5f;

    private float turn = 0.0f;
    private int timeout = 0;
    public int timeoutValue = 10;

    private Vector3 currentRotation, targetRotation;


    void Start()
    {

    }

    void FixedUpdate()
    {
        timeout--;
        turn = Input.GetAxisRaw("Horizontal");
        if (turn != 0)
        {
            if (timeout <= 0)
            {
                timeout = timeoutValue;
                Turn();
            }
        }
        MoveForward();
    }

    void MoveForward()
    {
        transform.position += transform.forward * speed * Time.deltaTime;
    }

    void Turn()
    {
        currentRotation = transform.eulerAngles;
        targetRotation.y = (currentRotation.y + (90 * turn));
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
