using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanZoom : MonoBehaviour {

    Vector3 touchStart;
    Camera cam;
    bool panning;
    public float maxX, maxY, minX, minY;
    public Transform[] borders;

    public float zoomOutMin = 5;
    public float zoomOutMax = 10;
    private bool multiTouch = false;

	// Use this for initialization
	void Start () {
        cam = FindObjectOfType<Camera>();
        panning = false;
        minX = borders[0].position.x + 2f;
        minY = borders[1].position.y +4f;
        maxX = borders[2].position.x-2f;
        maxY = borders[3].position.y-4f;
        zoomOutMin = cam.orthographicSize;
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonDown(0))
        {
            touchStart = cam.ScreenToWorldPoint(Input.mousePosition);
            multiTouch = false;
            RaycastHit2D hit = Physics2D.Raycast(touchStart, Vector2.zero);
            if(hit.collider == null)
            {
                panning = true;
            }
        }
        if (Input.touchCount == 2)
        {
            multiTouch = true;
            Touch touchZero = Input.GetTouch(0);
            Touch touchOne = Input.GetTouch(1);

            Vector2 touchZeroPrevPos = touchZero.position - touchZero.deltaPosition;
            Vector2 touchOnePrevPos = touchOne.position - touchOne.deltaPosition;

            float prevMagnitude = (touchZeroPrevPos - touchOnePrevPos).magnitude;
            float currentMagnitude = (touchZero.position - touchOne.position).magnitude;

            float difference = currentMagnitude - prevMagnitude;

            Zoom(difference * 0.01f);
        }
        if (Input.GetMouseButton(0) && !multiTouch)
        {
            if (panning)
            {
                Vector3 direction = touchStart - cam.ScreenToWorldPoint(Input.mousePosition);
                direction.z = 0;
                Vector3 newPos = cam.transform.position += direction;
                cam.transform.position = newPos;
                cam.transform.position = new Vector3(Mathf.Clamp(cam.transform.position.x, minX, maxX), Mathf.Clamp(cam.transform.position.y, minY, maxY), cam.transform.position.z);

            }
        }
        if (Input.GetMouseButtonUp(0))
        {
            panning = false;
        }

        Zoom(Input.GetAxis("Mouse ScrollWheel"));
		
	}

    void Zoom(float increment)
    {
        cam.orthographicSize = Mathf.Clamp(cam.orthographicSize - increment, zoomOutMin, zoomOutMax);
    }

}
