using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColorLove2 : MonoBehaviour
{
    private Image myImage;
    [SerializeField] private List<Color> myColors;

    public static ColorLove2 instance;
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

    public void LoveColorOne()
    {
        myImage.color = myColors[0];
    }

    public void LoveColorTwo()
    {
        myImage.color = myColors[1];
    }
    public void LoveColorThree()
    {
        myImage.color = myColors[2];
    }
}
