using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MixPills : MonoBehaviour
{
    [SerializeField] private GameObject purplePillUse;
    [SerializeField] private GameObject yellowPillUse;
    [SerializeField] private GameObject cyanPillUse;
    [SerializeField] private GameObject purplePillAsset;
    [SerializeField] private GameObject yellowPillUseAsset;
    [SerializeField] private GameObject cyanPillUseAsset;

    public bool redPill, bluePill, greenPill;

    private Vector2 purpleStarPosition;
    private Vector2 yellowStarPosition;
    private Vector2 cyanStarPosition;

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

        purpleStarPosition= purplePillUse.transform.position;
        yellowStarPosition = yellowPillUse.transform.position;
        cyanStarPosition = cyanPillUse.transform.position;
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
            purplePillUse.SetActive(true);
            purplePillAsset.SetActive(true);
            redPill = false;
            bluePill = false;
        }

        if (redPill == true && greenPill == true)
        {
            yellowPillUse.SetActive(true);
            yellowPillUseAsset.SetActive(true);
            redPill = false;
            greenPill = false;
        }

        if(greenPill == true && bluePill == true)
        {
            cyanPillUse.SetActive(true);
            cyanPillUseAsset.SetActive(true);
            greenPill = false;
            bluePill = false;
        }
    }

    public void PurplePill()
    {
        purplePillUse.transform.position = purpleStarPosition;
        purplePillUse.SetActive(false);
    }

    public void YellowPill()
    {
        yellowPillUse.transform.position = yellowStarPosition;
        yellowPillUse.SetActive(false);
    }

    public void CyanPill()
    {
        cyanPillUse.transform.position = cyanStarPosition;
        cyanPillUse.SetActive(false);
    }

    public void PillAsset()
    {
        purplePillAsset.SetActive(false);
        yellowPillUseAsset.SetActive(false);
        cyanPillUseAsset.SetActive(false);
    }
}
