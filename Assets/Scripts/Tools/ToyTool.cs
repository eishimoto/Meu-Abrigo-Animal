using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToyTool : MonoBehaviour
{
    private bool _moveAllowed;
    private Collider2D myCollider;
    private Vector2 _startPosition;
    private Rigidbody2D myRigidbody;

    public bool tenisBall;
    public bool beachBall;
    int value;

    //movement
    private Vector3 lastVelocity;
    private Vector2 startPos, endPos, direction;
    private Vector3 startMousePos, endMousePos,mouseDirection;
    private float touchTimeStart, touchTimeFinish, timeInterval;
    [Range(0.05f, 1f)]
    public float throwFoser = 0.3f;

    private Camera maincamera;

    [SerializeField] private int stopBall;
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
                    touchTimeStart = Time.time;
                    startPos = Input.GetTouch(0).position;

                }
            }
            if (touch.phase == TouchPhase.Moved)
            {
                if (_moveAllowed)
                {
                    transform.position = new Vector2(touchPosition.x, touchPosition.y);
                    MoveBallTemp();
                }
            }

            if (touch.phase == TouchPhase.Ended)
            {
                if (touch.phase == TouchPhase.Ended)
                {
                    _moveAllowed = false;
                    touchTimeFinish = Time.time;
                    timeInterval = touchTimeFinish - touchTimeStart;
                    endPos = Input.GetTouch(0).position;
                    direction = startPos - endPos;
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

    private void MoveBall()
    {
        myRigidbody.bodyType = RigidbodyType2D.Dynamic;
        myRigidbody.AddForce(-direction/timeInterval * throwFoser/10);
        Invoke("SlowBall", stopBall);
    }
    private void MoveBallTemp()
    {
        myRigidbody.bodyType = RigidbodyType2D.Dynamic;
        Vector2 direction = new Vector2((float)Random.Range(-1000, 1000), (float)Random.Range(-1000, 1000));
        myRigidbody.AddForce(direction);
        Invoke("SlowBall", stopBall);
    }

    private void SlowBall()
    {
        myRigidbody.velocity = Vector2.zero;
        myRigidbody.bodyType = RigidbodyType2D.Kinematic;
        transform.position = _startPosition;

        if(beachBall)
        {
            value = 100;
        }
        if(tenisBall)
        {
            value = 50;
        }
        if (UICanvas.on == true)
        {
            Stats.instance.AddAffection(value);
        }
        if (UICanvas.on2 == true)
        {
            Stats2.instance.AddAffection(value);
        }
        if (UICanvas.on3 == true)
        {
            Stats3.instance.AddAffection(value);
        }
        if (UICanvas.on4 == true)
        {
            Stats4.instance.AddAffection(value);
        }
    }

    // Mouse as touch control
    private void OnMouseDrag()
    {
        if (UICanvas.canUseTool == true)
        {
            Vector3 mouseP = new Vector3(Input.mousePosition.x, Input.mousePosition.y, Input.mousePosition.z + 10f);
            Vector3 worldP = maincamera.ScreenToWorldPoint(mouseP);
            transform.position = worldP;
            touchTimeStart = Time.time;
            startMousePos = Input.mousePosition;
            MoveBallTemp();
        }
    }

    private void OnMouseUp()
    {
        touchTimeFinish = Time.time;
        timeInterval = touchTimeFinish - touchTimeStart;
        endMousePos = Input.mousePosition;
        mouseDirection = startMousePos - endMousePos;
    }
    private void MoveBallMouse()
    {
        myRigidbody.bodyType = RigidbodyType2D.Dynamic;
        myRigidbody.AddForce(-mouseDirection / timeInterval * throwFoser);
        Invoke("SlowBall", stopBall);
    }
}
