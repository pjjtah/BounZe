using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour {

    protected Vector3 position;
    Vector3 collisionPoint;
    float collisionTime;
    public float speed;
    bool moving;
    Vector3 direction;
	// Use this for initialization
	void Start () {
        moving = false;
        position = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
        Recoil();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collisionPoint = collision.contacts[0].point;
            moving = true;
            direction = -(collision.transform.position - collisionPoint);
            direction.Normalize();
            collisionTime = Time.time;
        }
    }

    protected void Recoil()
    {
        if (moving)
        {
            if (Time.time < collisionTime + 0.2f)
            {
                transform.position += direction * speed * Time.deltaTime;
            }
            else if (Time.time < collisionTime + 0.4f)
            {
                transform.position -= direction * speed * Time.deltaTime;
            }
            else
            {
                transform.position = position;
                moving = false;
            }
        }
    }

    public void UpdatePostion(Vector2 pos)
    {
        position = pos;
    }
}
