using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingWall : Wall {

    public bool turn;
    private float turnTime;
    public float moveSpeed;
    public float moveTime;

	// Update is called once per frame
	void FixedUpdate () {
        Recoil();
        position = transform.position;
        if (turn)
        {
            transform.position += transform.up * moveSpeed * Time.deltaTime;
        }
        else
        {
            transform.position -= transform.up * moveSpeed * Time.deltaTime;
        }

        if(Time.time > moveTime + turnTime)
        {
            turnTime = Time.time;
            turn = !turn;
        }
	}
}
