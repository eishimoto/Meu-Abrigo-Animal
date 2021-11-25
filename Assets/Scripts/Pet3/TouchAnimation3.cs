using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchAnimation3 : MonoBehaviour
{
    private bool _moveAllowed;
    private Collider2D myCollider;
    private Animator animator;

    private Camera maincamera;

    private int random;

    public static TouchAnimation3 instance;
    private void OnEnable()
    {
        if (instance = null)
        {
            instance = this;
        }
    }
    private void Start()
    {
        myCollider = GetComponent<Collider2D>();
        animator = GetComponent<Animator>();
        maincamera = Camera.main;
        random = Random.Range(0, 4);
    }

    private void Update()
    {
        MoveTool();
        if (Stats3.action)
        {
            PlayAction();
            Stats3.action = false;
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
                    PlayAction();
                }
            }
        }
    }

    private void OnMouseDown()
    {
        //PlayAction();
    }

    public void PlayAction()
    {
        animator.SetTrigger("Touch");
        StartCoroutine(gameObject.GetComponent<PetSounds3>().DogBark());
    }
}
