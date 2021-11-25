using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchAnimation2 : MonoBehaviour
{
    private bool _moveAllowed;
    private Collider2D myCollider;
    private Animator animator;

    private Camera maincamera;

    private int random;

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
        if(Stats2.action)
        {
            PlayAction();
            Stats2.action = false;
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
        //RandomAction();
    }

    private void RandomAction()
    {
        random = Random.Range(0, 4);
        animator.SetInteger("TouchIndex", random);
        animator.SetTrigger("Touch");

        if (random == 0)
        {
            StartCoroutine(gameObject.GetComponent<PetSounds2>().CatMeow());
        }
        if(random == 2)
        {
            StartCoroutine(gameObject.GetComponent<PetSounds2>().CatAngry());
        }
    }    

    private void PlayAction()
    {
        animator.SetInteger("TouchIndex", 0);
        animator.SetTrigger("Touch");
        StartCoroutine(gameObject.GetComponent<PetSounds2>().CatMeow());
    }
}
