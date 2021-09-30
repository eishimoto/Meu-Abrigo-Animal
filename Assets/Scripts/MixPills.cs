using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MixPills : MonoBehaviour
{
    [SerializeField] private GameObject newPill;
    [SerializeField] private GameObject pillAsset;

    public bool redPill, bluePill, greenPill;

    public static MixPills instance;

    private Vector2 starPosition;

    private void OnEnable()
    {
        if(instance == null)
        {
            instance = this;
        }
    }

    private void Start()
    {
        redPill = false;
        bluePill = false;
        greenPill = false;

        starPosition = newPill.transform.position;
    }
    private void Update()
    {
        CheckMix();
        UsedPill();
    }
       
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("RedPill"))
        {
            redPill = true;
        }
        if (collision.gameObject.CompareTag("BluePill"))
        {
            bluePill = true;
        }
        if(collision.gameObject.CompareTag("GreenPill"))
        {
            greenPill = true;
        }
    }

    private void CheckMix()
    {
        if(redPill == true && bluePill == true)
        {
            newPill.SetActive(true);
            pillAsset.SetActive(true);
            redPill = false;
            bluePill = false;
        }
    }

    public void UsedPill()
    {
        newPill.transform.position =starPosition;
        newPill.SetActive(false);
    }

    public void PillAsset()
    {
        pillAsset.SetActive(false);
    }
}
