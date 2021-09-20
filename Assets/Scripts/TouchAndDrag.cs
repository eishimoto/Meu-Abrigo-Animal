using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchAndDrag : MonoBehaviour
{
    private bool _moveAllowed;
    private Collider2D myCollider;
    private Vector2 _startPosition;

    private void Start()
    {
        myCollider = GetComponent<Collider2D>();
        _startPosition = transform.position;
    }

    private void Update()
    {
        MoveTool();
    }

    private void MoveTool()
    {
        if(Input.touchCount > 0)
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
                    transform.position = new Vector2(touchPosition.x, touchPosition.y);
                }
            }

            if (touch.phase == TouchPhase.Ended)
            {
                if (touch.phase == TouchPhase.Ended)
                {
                    _moveAllowed = false;
                    transform.position = _startPosition;
                }
            }
        }
    }
}
