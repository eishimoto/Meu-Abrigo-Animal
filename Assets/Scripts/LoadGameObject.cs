using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadGameObject : MonoBehaviour
{
    [SerializeField] private int timeToReturn;
    void Update()
    {
        StartCoroutine(LoadScreenOFF());
    }
    IEnumerator LoadScreenOFF()
    {
        yield return new WaitForSeconds(timeToReturn);
        gameObject.SetActive(false);
    }
}
