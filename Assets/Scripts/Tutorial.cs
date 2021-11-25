using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Tutorial : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI textBox;
    [SerializeField] private List<string> textToWrite;
    private int index;
    [SerializeField] private float typingSpeed;
    [SerializeField] private GameObject continueButton;
    [SerializeField] private Image panelImage;
    [SerializeField] private GameObject finalButton;
    private void OnEnable()
    {
        index = 0;
        panelImage.enabled = true;
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
            StartCoroutine(CloseTextBox());
            panelImage.enabled = false;
        }
    }

    IEnumerator CloseTextBox()
    {
        yield return new WaitForSeconds(0.02f);
        gameObject.SetActive(false);
    }
    public void NextSentenceIntro()
    {
        continueButton.SetActive(false);

        if (index < textToWrite.Count - 1)
        {
            index++;
            textBox.text = null;
            StartCoroutine(Type());
        }
        else
        {
            textBox.text = null;
            StartCoroutine(CloseTextBox());
            panelImage.enabled = false;
            UICanvas.runTime = true;
        }
    }

    public void FinalTextPanel()
    {
        continueButton.SetActive(false);

        if (index < textToWrite.Count - 1)
        {
            index++;
            textBox.text = null;
            StartCoroutine(Type());
        }
        else
        {
            finalButton.SetActive(true);
            Destroy(gameObject);
        }
    }
}
