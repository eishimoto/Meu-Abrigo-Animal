using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadGameObject : MonoBehaviour
{
    [SerializeField] private int timeToReturn;
    void Start()
    {

    }
    // Update is called once per frame
    void Update()
    {
        StartCoroutine(DisableGameObject());
    }
    IEnumerator DisableGameObject()
    {
        yield return new WaitForSeconds(timeToReturn);
        gameObject.SetActive(false);
    }
}
