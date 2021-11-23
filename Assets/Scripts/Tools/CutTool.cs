using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutTool : MonoBehaviour
{
    private bool _moveAllowed;
    private Collider2D myCollider;
    private Vector2 _startPosition;

    private Camera maincamera;

    public bool scissorOn;
    public bool trimmerOn;
    public static bool scissor;
    public static bool trimmer;

    private AudioSource ToolSFXSource; //E

    private Animator myAnimator;

    private void Start()
    {
        myCollider = GetComponent<Collider2D>();
        ToolSFXSource = GetComponent<AudioSource>();
        myAnimator = GetComponent<Animator>();
        _startPosition = transform.position;
        maincamera = Camera.main;
        if (scissorOn)
        {
            scissor = true;
        }
        if (trimmerOn)
        {
            trimmer = true;
        }
    }

    private void Update()
    {
        if (UICanvas.canUseTool == true)
        {
          MoveTool();
        }
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
           Vector3 mouseP = new Vector3(Input.mousePosition.x, Input.mousePosition.y, Input.mousePosition.z + 10f);
           Vector3 worldP = maincamera.ScreenToWorldPoint(mouseP);
           transform.position = worldP;
           AnimationCheck();
        }
    }

    private void OnMouseUp()
    {
        transform.position = _startPosition;
        StopAnimationCheck();
    }

    private void AnimationCheck()
    {
        if (scissorOn)
        {
            myAnimator.SetBool("move", true);
        }
        if(trimmerOn)
        {
            myAnimator.SetBool("Trimmer", true);
        }
    }

    private void StopAnimationCheck()
    {
        if (scissorOn)
        {
            myAnimator.SetBool("move", false);
        }
        if (trimmerOn)
        {
            myAnimator.SetBool("Trimmer", false);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Fur")) //E
        {
            if (scissorOn)
                ToolSFXSource.Play();

            if (trimmerOn)
                ToolSFXSource.Play();

        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Fur")) //E
        {
            if (scissorOn)
                ToolSFXSource.Stop();

            if (trimmerOn)
                ToolSFXSource.Stop();
        }
    }
}
