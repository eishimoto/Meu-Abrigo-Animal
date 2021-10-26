using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToyTool : MonoBehaviour
{
    private bool _moveAllowed;
    private Collider2D myCollider;
    private Vector2 _startPosition;
    private Rigidbody2D myRigidbody;

    private Vector3 lastVelocity;

    private Camera maincamera;

    private void Start()
    {
        myCollider = GetComponent<Collider2D>();
        myRigidbody = GetComponent<Rigidbody2D>();
        _startPosition = transform.position;
        maincamera = Camera.main;
    }

    private void Update()
    {
        if (UICanvas.canUseTool == true)
        {
            MoveTool();
        }

        lastVelocity = myRigidbody.velocity;
    }

    private void MoveTool()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            Vector2 touchPosition = Camera.main.ScreenToWorldPoint(touch.position);

            if (touch.phase == TouchPhase.Began)
            {
                Collider2D touchedCollider = Physics2D.OverlapPoint(touchPosition);
                if (myCollider == touchedCollider)
                {
                    _moveAllowed = true;
                    MoveBall();
                }
            }
            if (touch.phase == TouchPhase.Moved)
            {
                if (_moveAllowed)
                {
                    transform.position = new Vector2(touchPosition.x, touchPosition.y);
                }
            }

            if (touch.phase == TouchPhase.Ended)
            {
                if (touch.phase == TouchPhase.Ended)
                {
                    _moveAllowed = false;
                    Invoke("SlowBall", 4f);
                    // transform.position = _startPosition;
                }
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        var speed = lastVelocity.magnitude;
        var direction = Vector3.Reflect(lastVelocity.normalized, collision.contacts[0].normal);

        myRigidbody.velocity = direction * Mathf.Max(speed, 0f);
    }

    // Mouse as touch control
    private void OnMouseDrag()
    {
        if (UICanvas.canUseTool == true)
        {
            Vector3 mouseP = new Vector3(Input.mousePosition.x, Input.mousePosition.y, Input.mousePosition.z + 10f);
            Vector3 worldP = maincamera.ScreenToWorldPoint(mouseP);
            transform.position = worldP;
            MoveBall();
        }
    }

    private void MoveBall()
    {
        myRigidbody.bodyType = RigidbodyType2D.Dynamic;
        int random = Random.Range(20, 40);
        int randomtwo = Random.Range(20, 40);
        myRigidbody.AddForce(new Vector2(random, randomtwo));
    }

    private void SlowBall()
    {
        myRigidbody.velocity = Vector2.zero;
        myRigidbody.bodyType = RigidbodyType2D.Kinematic;
        transform.position = _startPosition;
        Stats.instance.AddAffection();
    }


    private void OnMouseUp()
    {
        Invoke("SlowBall", 4f); 
    }
}
