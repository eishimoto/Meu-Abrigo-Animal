using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BookButton : MonoBehaviour
{
    //animation
    private Animator animator;

    public static BookButton instance;
    private void OnEnable()
    {
        if (instance = null)
        {
            instance = this;
        }
        animator.SetBool("Shake", false);
    }
    private void Start()
    {
        animator = GetComponent<Animator>();
    }
    private void Update()
    {
        ButtonAnim();
    }

    private void ButtonAnim()
    {
        if (Stats.sick || Stats2.sick || Stats3.sick || Stats4.sick)
        {
            animator.SetBool("Shake", true);
        }
        else if (!Stats.sick || !Stats2.sick || !Stats3.sick || !Stats4.sick)
        {
            animator.SetBool("Shake", false);
        }
    }
}
