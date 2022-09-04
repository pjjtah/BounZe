using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawWall : MonoBehaviour
{
    public Vector2 startPoint;
    public Vector2 endPoint;
    public GameObject wall;
    public Renderer wallRenderer;
    public BoxCollider2D col;
    public bool started;
    public GameObject[] points;
    public Material standard;
    public Material transparent;
    public bool drawn;
    // Start is called before the first frame update
    void Start()
    {
        started = false;
        drawn = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit2D rcHit = Physics2D.Raycast(ray.origin, ray.direction);
            if (rcHit)
            {
                if (rcHit.transform != null)
                {
                    if (rcHit.transform.gameObject.tag == "DrawPoint")
                    {
                        if (rcHit.transform.IsChildOf(transform))
                        {
                            drawn = false;
                            startPoint = rcHit.transform.position;
                            started = true;
                            wall.SetActive(true);
                            col.enabled = false;
                            wallRenderer.material = transparent;
                        }

                    }
                }
            }

        }
        if (Input.GetMouseButtonUp(0))
        {
            if (started)
            {
                started = false;
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit2D rcHit = Physics2D.Raycast(ray.origin, ray.direction);
                if (rcHit)
                {
                    if (rcHit.transform != null)
                    {
                        if (rcHit.transform.gameObject.tag == "DrawPoint")
                        {
                            if (rcHit.transform.IsChildOf(transform))
                            {
                                drawn = true;
                                wallRenderer.material = standard;
                                col.enabled = true;
                                endPoint = rcHit.transform.position;
                                Vector3 centerPoint = new Vector3(startPoint.x + endPoint.x, startPoint.y + endPoint.y, 2f) / 2f;
                                float scaleY = Vector2.Distance(startPoint, endPoint);
                                wall.transform.position = centerPoint;
                                wall.transform.rotation = Quaternion.Euler(new Vector3(0f, 0f, (Mathf.Atan2(startPoint.y - endPoint.y, startPoint.x - endPoint.x) * Mathf.Rad2Deg) - 90));
                                wall.transform.localScale = new Vector3(wall.transform.localScale.x, scaleY, wall.transform.localScale.z);
                            }
                            else
                            {
                                wall.SetActive(false);
                            }

                        }
                        else
                        {
                            wall.SetActive(false);
                        }
                    }
                    else
                    {
                        wall.SetActive(false);
                    }
                }
                else
                {
                    wall.SetActive(false);
                }
            }

        }
        if (started)
        {
            endPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector3 centerPoint = new Vector3(startPoint.x + endPoint.x, startPoint.y + endPoint.y, 2f) / 2f;
            float scaleY = Vector2.Distance(startPoint, endPoint);
            wall.transform.position = centerPoint;
            wall.transform.rotation = Quaternion.Euler(new Vector3(0f, 0f, (Mathf.Atan2(startPoint.y - endPoint.y, startPoint.x - endPoint.x) * Mathf.Rad2Deg)-90));
            wall.transform.localScale = new Vector3(wall.transform.localScale.x, scaleY, wall.transform.localScale.z);
        }

    }

    private void OnMouseDown()
    {

    }

}
