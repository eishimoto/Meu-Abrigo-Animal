using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatsColor2 : MonoBehaviour
{
    private Image myImage;
    [SerializeField] private List<Color> myColors;

    public static StatsColor2 instance;
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

    public void ColorChangeOne()
    {
        myImage.color = myColors[0];
    }

    public void ColorChangeTwo()
    {
        myImage.color = myColors[1];
    }
}
