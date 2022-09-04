using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatingWall : Wall {

    public float rotateSpeed;
	// Use this for initialization

	// Update is called once per frame
	void Update () {
        Recoil();
        transform.Rotate(0, 0, rotateSpeed * Time.deltaTime);
	}
}
