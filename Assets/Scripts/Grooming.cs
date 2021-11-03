using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grooming : MonoBehaviour
{
    private bool canTrim;
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
    void Update()
    {
        HoldToTrim();
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.CompareTag("Grooming"))
        {
            canTrim = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.CompareTag("Grooming"))
        {
            canTrim = false;
        }
    }

    private void DesableFur()
    {
        fur.SetActive(false);
    }

    private void HoldToTrim()
    {
        if (canTrim == true)
        {
            Invoke("DesableFur", .5f);
        }
        else
        {
            CancelInvoke("DesableFur");
        }
    }
}
