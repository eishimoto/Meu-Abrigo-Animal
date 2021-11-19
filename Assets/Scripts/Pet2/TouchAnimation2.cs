using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchAnimation2 : MonoBehaviour
{
    private bool _moveAllowed;
    private Collider2D myCollider;
    private Animator animator;

    private Camera maincamera;

    [System.Obsolete]
    private void Start()
    {
        myCollider = GetComponent<Collider2D>();
        animator = GetComponent<Animator>();
        maincamera = Camera.main;
        Random.seed = (int)System.DateTime.Now.Ticks;
    }

    private void Update()
    {
        MoveTool();
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
                    animator.SetInteger("TouchIndex",Random.Range(0,4));
                    animator.SetTrigger("Touch");
                }
            }
        }
    }

    private void OnMouseDown()
    {
        animator.SetInteger("TouchIndex", Random.Range(0, 4));
        animator.SetTrigger("Touch");
    }
}
