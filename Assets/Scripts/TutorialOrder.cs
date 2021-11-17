using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialOrder : MonoBehaviour
{
    [SerializeField] private List<GameObject> grupText;
    [SerializeField] private List<GameObject> particles;
     
    //int
    [SerializeField] private float waitTime;

    private void OnEnable()
    {
        grupText[0].SetActive(true);
    }
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Food"))
        {
            StartCoroutine(text());
        }
    }

    IEnumerator text()
    {
        yield return new WaitForSeconds(waitTime);
        grupText[1].SetActive(true);
        particles[0].SetActive(false);
    }
}
