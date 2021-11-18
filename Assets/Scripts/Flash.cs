using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flash : MonoBehaviour
{
    void Update()
    {
        StartCoroutine(FlashOFF());
    }
    IEnumerator FlashOFF()
    {
        yield return new WaitForSeconds(1f);
        gameObject.SetActive(false);
    }
} 
