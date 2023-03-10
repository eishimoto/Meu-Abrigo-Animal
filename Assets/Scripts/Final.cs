using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Final : MonoBehaviour
{
    [SerializeField] private int sceneNumber;
    [SerializeField] private int timeToWait;
    [SerializeField] private GameObject finalText;
    private void OnEnable()
    {
        StartCoroutine(LoadFinal());
    }

    IEnumerator LoadFinal()
    {
        yield return new WaitForSeconds(timeToWait);
        finalText.SetActive(true);
    }
}
