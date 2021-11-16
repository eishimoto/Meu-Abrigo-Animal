using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Tutorial : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI textBox;
    [SerializeField] private List<string> textToWrite;
    private int index;
    [SerializeField] private float typingSpeed;
    [SerializeField] private GameObject continueButton;
    [SerializeField] private GameObject grup;

    private void OnEnable()
    {
        index = 0;
        StartCoroutine(Type());
    }
    private void Start()
    {
       //StartCoroutine(Type());
    }
    void Update()
    {
        if (textBox.text == textToWrite[index])
        {
            continueButton.SetActive(true);
        }
    }

    IEnumerator Type()
    {
        foreach (char letter in textToWrite[index].ToCharArray())
        {
            textBox.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }
    }

    public void NextSentence()
    {
        continueButton.SetActive(false);

        if(index < textToWrite.Count - 1)
        {
            index++;
            textBox.text = null;
            StartCoroutine(Type());
        }
        else
        {
            textBox.text = null;
            grup.SetActive(false);
        }
    }
}
