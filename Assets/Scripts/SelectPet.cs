using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectPet : MonoBehaviour
{
    //animation
    private Animator animator;

    //public bool
    public bool dog1, dog2, cat1, cat2;

    public static SelectPet instance;
    private void OnEnable()
    {
        if(instance = null)
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
        if (Stats.petNecessity)
        {
            animator.SetBool("Shake", true);
        }
        else if (!Stats.petNecessity)
        {
            animator.SetBool("Shake", false);
        }
    }
}
