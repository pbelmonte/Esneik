using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeMovement : MonoBehaviour {

    public float speed = 3.5f;

    private 

	void Start () {
		
	}
	
	void FixedUpdate () {
        MoveForward();
	}

    void MoveForward() {
        transform.position += transform.forward * speed * Time.deltaTime;
    }
}
