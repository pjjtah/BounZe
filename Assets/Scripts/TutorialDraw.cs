using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialDraw : MonoBehaviour
{
    public Animator animator;
    public DrawWall drawWall;
    bool finished;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (drawWall.drawn)
        {
            animator.StopPlayback();
            Destroy(this.gameObject);
            finished = true;
        }
        
    }
}
