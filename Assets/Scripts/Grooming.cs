using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grooming : MonoBehaviour
{
    private bool canTrim;

    public GameObject fur;
    void Start()
    {

    }

    // Update is called once per frame
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
            Invoke("DesableFur", 2f);
        }
        else
        {
            CancelInvoke("DesableFur");
        }
    }
}
