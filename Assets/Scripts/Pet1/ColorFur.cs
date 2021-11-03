using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColorFur : MonoBehaviour
{
    private Image myImage;
    [SerializeField] private List<Color> myColors;

    public static ColorFur instance;
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

    public void FurColorOne()
    {
        myImage.color = myColors[0];
    }

    public void FurColorTwo()
    {
        myImage.color = myColors[1];
    }

    public void FurColorThree()
    {
        myImage.color = myColors[2];
    }
}
