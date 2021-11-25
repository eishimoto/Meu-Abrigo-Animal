using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MixButton : MonoBehaviour
{
    //animation
    private Animator animator;

    public static MixButton instance;
    private void OnEnable()
    {
        if (instance = null)
        {
            instance = this;
        }
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
