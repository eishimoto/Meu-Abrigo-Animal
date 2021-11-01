using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grooming : MonoBehaviour
{
    private bool canTrim;

    public GameObject fur;

    public void OnDisable()
    {
        Stats.count--;
    }
    public void OnEnable()
    {
        Stats.count++;
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
