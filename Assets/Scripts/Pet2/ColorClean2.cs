using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColorClean2 : MonoBehaviour
{
    private Image myImage;
    [SerializeField] private List<Color> myColors;

    public static ColorClean2 instance;
    public void OnEnable()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    private void Start()
    {
        myImage = GetComponent<Image>();
    }

    public void CleanColorOne()
    {
        myImage.color = myColors[0];
    }

    public void CleanColorTwo()
    {
        myImage.color = myColors[1];
    }
    public void CleanColorThree()
    {
        myImage.color = myColors[2];
    }
}
