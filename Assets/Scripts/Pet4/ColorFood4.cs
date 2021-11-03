using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColorFood4 : MonoBehaviour
{
    private Image myImage;
    [SerializeField] private List<Color> myColors;

    public static ColorFood4 instance;
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

    public void FoodColorOne()
    {
        myImage.color = myColors[0];
    }

    public void FoodColorTwo()
    {
        myImage.color = myColors[1];
    }
    public void FoodColorThree()
    {
        myImage.color = myColors[2];
    }
}
