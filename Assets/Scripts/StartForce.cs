using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartForce : MonoBehaviour {

    public Vector3 force;
	// Use this for initialization
	void Start () {
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        rb.AddForce(force, ForceMode2D.Impulse);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
