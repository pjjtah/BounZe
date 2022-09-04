using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial : MonoBehaviour {

    public GameObject wall;
    public GameObject glove;
    private bool turn;
    private float turnTime;

	// Use this for initialization
	void Start () {
        turn = false;
        turnTime = 0f;
	}
	
	// Update is called once per frame
	void Update () {
		if(wall.transform.rotation.eulerAngles.z > 170 && wall.transform.rotation.eulerAngles.z < 190)
        {
            glove.SetActive(true);
            if(turnTime + 0.25f < Time.time)
            {
                turnTime = Time.time;
                turn = !turn;
            }
            if (turn)
            {
                glove.transform.position = new Vector3(glove.transform.position.x + Time.deltaTime * 0.25f, glove.transform.position.y, glove.transform.position.z);
            }
            else
            {
                glove.transform.position = new Vector3(glove.transform.position.x - Time.deltaTime * 0.25f, glove.transform.position.y, glove.transform.position.z);
            }

        }
	}
}
