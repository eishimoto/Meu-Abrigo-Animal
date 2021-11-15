using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToyTool : MonoBehaviour
{
    private bool _moveAllowed;
    private Collider2D myCollider;
    private Vector2 _startPosition;
    private Rigidbody2D myRigidbody;
    //whichBall
    public bool tenisBall;
    public bool beachBall;
    int value;
    //Sound
    private AudioSource audioSource;
    [SerializeField] private AudioClip ball;


    //movement
    private Vector3 lastVelocity;

    private Camera maincamera;

    [SerializeField] private int stopBall;
    private void Start()
    {
        myCollider = GetComponent<Collider2D>();
        myRigidbody = GetComponent<Rigidbody2D>();
        _startPosition = transform.position;
        maincamera = Camera.main;
        audioSource = GetComponent<AudioSource>();
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


                }
            }
            if (touch.phase == TouchPhase.Moved)
            {
                if (_moveAllowed)
                {
                    MoveBall();
                }
            }

            if (touch.phase == TouchPhase.Ended)
            {
                if (touch.phase == TouchPhase.Ended)
                {
                    _moveAllowed = false;
                }
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        var speed = lastVelocity.magnitude;
        var direction = Vector3.Reflect(lastVelocity.normalized, collision.contacts[0].normal);

        myRigidbody.velocity = direction * Mathf.Max(speed, 0f);
        if (collision.gameObject.CompareTag("Wall"))
        {
            audioSource.PlayOneShot(ball);
        }
    }
    private void MoveBall()
    {
        myRigidbody.bodyType = RigidbodyType2D.Dynamic;
        Vector2 direction = new Vector2((float)Random.Range(-500, 500), (float)Random.Range(-500, 500));
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
            value = 50;
        }
        if(tenisBall)
        {
            value = 25;
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
            MoveBall();
        }
    }

    private void OnMouseUp()
    {
        Invoke("SlowBall", stopBall);
    }
}
