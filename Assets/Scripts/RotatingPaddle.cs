using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatingPaddle : MonoBehaviour
{
    Vector3 FirstAngle;
    Vector3 SecondAngle;
    float xAngle;
    float rot;
    float xAngleTemp;
    Quaternion rotTemp;

    void Start()
    {
    }

    void Update()
    {

    }

    private void OnMouseDrag()
    {
        Vector2 dir = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.parent.position;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        Quaternion rotation = Quaternion.AngleAxis(angle - 90, Vector3.forward);
        transform.parent.rotation = rotation;
    }
}
