using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grooming : MonoBehaviour
{
    public GameObject fur;
    public bool pet1, pet2, pet3, pet4;

    public void OnDisable()
    {
        if(pet1)
        {
            Stats.count--;
        }
        if(pet2)
        {
            Stats2.count--;
        }
        if(pet3)
        {
            Stats3.count--;
        }
        if(pet4)
        {
            Stats4.count--;
        }
        Money.instance.AddMoneyPhoto(2);
    }
    public void OnEnable()
    {
        if (pet1)
        {
            Stats.count++;
        }
        if (pet2)
        {
            Stats2.count++;
        }
        if (pet3)
        {
            Stats3.count++;
        }
        if (pet4)
        {
            Stats4.count++;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Grooming"))
        {
            HoldToTrim();
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {

    }
    private void DesableFur()
    {
        fur.SetActive(false);
    }

    private void HoldToTrim()
    {
        if (CutTool.scissor)
        {
            Invoke("DesableFur", 2f);
        }

        else if (CutTool.trimmer)
        {
            Invoke("DesableFur", 1f);
        }
    }
}
