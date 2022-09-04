using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirectionArrow : MonoBehaviour
{

    Ball ball;

    // Start is called before the first frame update
    void Start()
    {
        ball = GetComponentInParent<Ball>();
        transform.localPosition = ball.force/1.5f;
        transform.right = -(ball.transform.position - transform.position);
    }

    // Update is called once per frame
    void Update()
    {
        if (ball.started)
        {
            Destroy(gameObject);
        }
        
    }
}
