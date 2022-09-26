using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    

    // Update is called once per frame
    void Update()
    {
        if (Input.touches != null && Input.touches.Length > 0)
        {
            foreach (Touch touch in Input.touches)
            {
                CheckClickAndDoAction(touch.position);
            }
        } else

        if(Input.GetMouseButtonDown(0))
        {
            CheckClickAndDoAction(Input.mousePosition);
        }
    }

    private void CheckClickAndDoAction(Vector2 position)
    { 
        Camera cam = Camera.main;
        Vector2 origin = Vector2.zero;
        Vector2 direction = Vector2.zero;

        if (cam.orthographic)
        {
            origin = cam.ScreenToWorldPoint(position);
        }
        else
        { 
            Ray ray = cam.ScreenPointToRay(position);
            origin = ray.origin;
            direction = ray.direction;
        }

        RaycastHit2D hit2D = Physics2D.Raycast(origin, direction);

        if(hit2D.collider && hit2D.collider.gameObject)
        {
            GameObject gameObject = hit2D.collider.gameObject;
            if (gameObject.name.StartsWith("Ball"))
            {
                ThrowBall(gameObject);
            }
        }
    }

    private void ThrowBall(GameObject ball)
    {
        ball.GetComponent<Rigidbody2D>().gravityScale = 1;
    }
}
