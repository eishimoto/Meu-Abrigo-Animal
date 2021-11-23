using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchAndDrag : MonoBehaviour
{
    private bool _moveAllowed;
    private Collider2D myCollider;
    private Vector2 _startPosition;

    private Camera maincamera;

    //animation
    private Animator myAnimator;
    public bool cyan, purple, yellow;

    private void Start()
    {
        myAnimator = GetComponent<Animator>();
        myCollider = GetComponent<Collider2D>();
        _startPosition = transform.position;
        maincamera = Camera.main;
    }

    private void Update()
    {
        if(UICanvas.canUseTool == true) 
        {
            if (UseOfTool.cantMove == false)
            {
                MoveTool();
            }
        }
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
                    AnimationCheck();
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
                    StopAnimationCheck();
                }
            }
        }
    }
    
    // Mouse as touch control
    private void OnMouseDrag()
    {
        if (UICanvas.canUseTool == true)
        {
            if (UseOfTool.cantMove == false)
            {
                Vector3 mouseP = new Vector3(Input.mousePosition.x, Input.mousePosition.y, Input.mousePosition.z + 10f);
                Vector3 worldP = maincamera.ScreenToWorldPoint(mouseP);
                transform.position = worldP;
                AnimationCheck();
            }
        }
    }

    private void OnMouseUp()
    {
        transform.position = _startPosition;
        StopAnimationCheck();
    }

    private void AnimationCheck()
    {
        if(cyan)
        {
            myAnimator.SetBool("cyan", true);
        }
        if(purple)
        {
            myAnimator.SetBool("purple", true);
        }
        if(yellow)
        {
            myAnimator.SetBool("yellow", true);
        }
    }

    private void StopAnimationCheck()
    {
        if(cyan)
        {
            myAnimator.SetBool("cyan", false);
        }
        if(purple)
        {
            myAnimator.SetBool("purple", false);
        }
        if(yellow)
        {
            myAnimator.SetBool("yellow", false);
        }
    }

}
