using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialPinch : MonoBehaviour {

    public Animator animator;
    private Camera cam;
    bool showPinch = false;
    bool finished = false;

	// Use this for initialization
	void Start () {
        cam = FindObjectOfType<Camera>();
        animator = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		if(!finished && !showPinch && cam.transform.position.y > 0)
        {
            showPinch = true;
            animator.SetTrigger("scrolled");
        }
        if(!finished && showPinch && cam.orthographicSize > 6){
            animator.StopPlayback();
            Destroy(this.gameObject);
            finished = true;
        }
	}
}
