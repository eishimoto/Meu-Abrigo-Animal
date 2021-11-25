using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PetPhotoAnim : MonoBehaviour
{   //animation
    private Animator animator;
    public bool dog1, dog2, cat1, cat2;

    public static PetPhotoAnim instance;
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
        if (dog1)
        {
            if (Stats.petNecessity)
            {
                animator.SetBool("Shake", true);
            }
            else if(!Stats.petNecessity)
            {
                animator.SetBool("Shake", false);
            }
        }
        if (dog2)
        {
            if (Stats3.petNecessity)
            {
                animator.SetBool("Shake", true);
            }
            else if (!Stats3.petNecessity)
            {
                animator.SetBool("Shake", false);
            }
        }
        if (cat1)
        {
            if (Stats2.petNecessity)
            {
                animator.SetBool("Shake", true);
            }
            else if (!Stats2.petNecessity)
            {
                animator.SetBool("Shake", false);
            }
        }
        if (cat2)
        {
            if (Stats4.petNecessity)
            {
                animator.SetBool("Shake", true);
            }
            else if (!Stats4.petNecessity)
            {
                animator.SetBool("Shake", false);
            }
        }
    }
}
