using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MixPills : MonoBehaviour
{
    [SerializeField] private GameObject[] pillToUse;
    [SerializeField] private GameObject[] pillAsset;

    public bool redPill, bluePill, greenPill;

    private Vector2[]starPosition;

    public static MixPills instance;
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

        starPosition[0]= pillToUse[0].transform.position;
        starPosition[1] = pillToUse[1].transform.position;
        starPosition[2] = pillToUse[2].transform.position;
    }
    private void Update()
    {
        CheckMix();
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
            pillToUse[0].SetActive(true);
            pillAsset[0].SetActive(true);
            redPill = false;
            bluePill = false;
        }

        if (redPill == true && greenPill == true)
        {
            pillToUse[1].SetActive(true);
            pillAsset[1].SetActive(true);
            redPill = false;
            greenPill = false;
        }

        if(greenPill == true && bluePill == true)
        {
            pillToUse[2].SetActive(true);
            pillAsset[2].SetActive(true);
            greenPill = false;
            bluePill = false;
        }
    }

    public void PurplePill()
    {
        pillToUse[0].transform.position = starPosition[0];
        pillToUse[0].SetActive(false);
    }

    public void YellowPill()
    {
        pillToUse[1].transform.position = starPosition[1];
        pillToUse[1].SetActive(false);
    }

    public void CyanPill()
    {
        pillToUse[2].transform.position = starPosition[2];
        pillToUse[2].SetActive(false);
    }

    public void PillAsset()
    {
        pillAsset[0].SetActive(false);
        pillAsset[1].SetActive(false);
        pillAsset[2].SetActive(false);
    }
}
