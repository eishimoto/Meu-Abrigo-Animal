using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CleaningTool : MonoBehaviour
{
    private bool _moveAllowed;
    private Collider2D myCollider;
    private Vector2 _startPosition;

    private Camera maincamera;

    [SerializeField] private GameObject areaToDraw;

    public  bool square1, square2, square3, square4;
    public bool circle1, circle2, circle3, circle4;
    public bool triangle1, triangle2, triangle3;

    public static bool squareClean, circleClean, triangleClean;

    private void Start()
    {
        myCollider = GetComponent<Collider2D>();
        _startPosition = transform.position;
        maincamera = Camera.main;
    }

    private void Update()
    {
        if (UICanvas.canUseTool == true)
        {
            MoveTool();
        }
        CheckCollisions();
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
                    areaToDraw.SetActive(true);
                    
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
                    transform.position = _startPosition;
                    areaToDraw.SetActive(false);
                    SetSquarestoFalse();
                    SetCirclesToFalse();
                    SetTrianglesToFalse();
                }
            }
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
            areaToDraw.SetActive(true);
        }
    }

    private void OnMouseUp()
    {
        areaToDraw.SetActive(false);
        transform.position = _startPosition;
        SetSquarestoFalse();
        SetCirclesToFalse();
        SetTrianglesToFalse();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Square1"))
        {
            square1 = true;
        }
        if (collision.CompareTag("Square2"))
        {
            square2 = true;
        }
        if (collision.CompareTag("Square3"))
        {
            square3 = true;
        }
        if (collision.CompareTag("Square4"))
        {
            square4 = true;
        }

        if(collision.CompareTag("Circle1"))
        {
            circle1 = true;
        }
        if (collision.CompareTag("Circle2"))
        {
            circle2 = true;
        }
        if (collision.CompareTag("Circle3"))
        {
            circle3 = true;
        }
        if (collision.CompareTag("Circle4"))
        {
            circle4 = true;
        }

        if(collision.CompareTag("Triangle1"))
        {
            triangle1 = true;
        }
        if (collision.CompareTag("Triangle2"))
        {
            triangle2 = true;
        }
        if (collision.CompareTag("Triangle3"))
        {
            triangle3 = true;
        }

    }



    private void CheckCollisions()
    {
        if(square1 == true && square2 == true && square3 == true && square4 == true)
        {
            squareClean = true;
        }

        if(circle1 == true && circle2 == true && circle3 == true && circle4 == true)
        {
            circleClean = true;
        }

        if (triangle1 == true && triangle2 == true && triangle3 == true)
        {
            triangleClean = true;
        }
    }

    private void SetSquarestoFalse()
    {
        square1 = false;
        square2 = false;
        square3 = false;
        square4 = false;
    }

    private void SetCirclesToFalse()
    {
        circle1 = false;
        circle2 = false;
        circle3 = false;
        circle4 = false;
    }

    private void SetTrianglesToFalse()
    {
        triangle1 = false;
        triangle2 = false;
        triangle3 = false;
    }
}
