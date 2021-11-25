using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchAnimation4 : MonoBehaviour
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
        if (UICanvas.touchInteraction == true)
        {
            MoveTool();
        }
        if (Stats4.action)
        {
            PlayAction();
            Stats4.action = false;
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

    private void PlayAction()
    {
        animator.SetTrigger("touch");
        StartCoroutine(gameObject.GetComponent<PetSounds4>().CatMeow());
    }
}
