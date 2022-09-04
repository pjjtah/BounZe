using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallStart : MonoBehaviour
{
    public Ball ball;

    private void OnMouseDown()
    {
        ball.StartMoving();
    }
}
