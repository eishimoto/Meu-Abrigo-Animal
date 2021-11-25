using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectPet : MonoBehaviour
{
    //animation
    private Animator animator;

    public static SelectPet instance;
    private void OnEnable()
    {
        if(instance = null)
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
        if (Stats.petNecessity || Stats2.petNecessity || Stats3.petNecessity || Stats4.petNecessity)
        {
            animator.SetBool("Shake", true);
        }
        else if (!Stats.petNecessity || !Stats2.petNecessity || !Stats3.petNecessity || !Stats4.petNecessity)
        {
            animator.SetBool("Shake", false);
        }
    }
}
