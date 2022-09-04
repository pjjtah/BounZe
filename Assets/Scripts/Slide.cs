using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slide : MonoBehaviour
{
    public Wall wall;
    public bool axisX;
    private bool activated;
    public Transform max;
    public Transform min;
    public Vector2 maxPos;
    public Vector2 minPos;

    private void Start()
    {
        maxPos = max.position - max.up * (max.localScale.y / 2f);
        minPos = min.position + min.up * (min.localScale.y / 2f);
    }

    void Update()
    {
    }

    private void OnMouseDrag()
    {

        if (axisX)
        {
            if (transform.parent.position.x + 0.15f < Camera.main.ScreenToWorldPoint(Input.mousePosition).x && transform.parent.position.x < maxPos.x)
            {

                transform.parent.position -= transform.parent.up * 3.5f * Time.deltaTime;
                wall.UpdatePostion(transform.parent.position);
            }
            else if (transform.parent.position.x - 0.15f > Camera.main.ScreenToWorldPoint(Input.mousePosition).x && transform.parent.position.x > minPos.x)
            {
                transform.parent.position += transform.parent.up * 3.5f * Time.deltaTime;
                wall.UpdatePostion(transform.parent.position);
            }
        }
        else
        {
            if (transform.parent.position.y + 0.15f < Camera.main.ScreenToWorldPoint(Input.mousePosition).y && transform.parent.position.y + 0.15f < maxPos.y)
            {
                transform.parent.position -= transform.parent.up * 3.5f * Time.deltaTime;
                wall.UpdatePostion(transform.parent.position);
            }
            else if (transform.parent.position.y - 0.15f > Camera.main.ScreenToWorldPoint(Input.mousePosition).y && transform.parent.position.y + 0.15f > minPos.y)
            {
                transform.parent.position += transform.parent.up * 3.5f * Time.deltaTime;
                wall.UpdatePostion(transform.parent.position);
            }
        }

    }
}
