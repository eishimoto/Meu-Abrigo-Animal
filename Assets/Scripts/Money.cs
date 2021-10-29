using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Money : MonoBehaviour
{
    [SerializeField] private int money;
    [SerializeField] private TextMeshProUGUI textDisplay;

    //static for funcitons
    public static Money instance;
    private void OnEnable()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    private void Start()
    {
        UpdateMoney();
    }

    public void UpdateMoney()
    {
        textDisplay.text = null;
        textDisplay.text = money.ToString() + " " + "Reais";
    }

    public void BuyFoodOne()
    {
        if(money > 10)
        {
            money -= 10;
            FoodTool.instance.AddFood();
            FoodTool.instance.UpdateTextMeshPro();
            textDisplay.text = money.ToString() + " " + "Reais";
        }
    }

    public void BuyFoodTwo()
    {
        if(money > 20)
        {
            money -= 20;
            FoodToolTwo.instance.AddFood();
            FoodToolTwo.instance.UpdateTextMeshPro();
            textDisplay.text = money.ToString() + " " + "Reais";
        }
    }
    public void BuyFoodThree()
    {
        if (money > 30)
        {
            money -= 30;
            FoodToolThree.instance.AddFood();
            FoodToolThree.instance.UpdateTextMeshPro();
            textDisplay.text = money.ToString() + " " + "Reais";
        }
    }
}
