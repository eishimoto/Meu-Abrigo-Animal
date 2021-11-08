using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Money : MonoBehaviour
{
    [SerializeField] private int money;
    [SerializeField] private TextMeshProUGUI textDisplay;

    //int
    [SerializeField] private int food1, food2, food3;
    [SerializeField] private int medicine1, medicine2, medicine3;

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
        if(money > food1)
        {
            money -= food1;
            FoodTool.instance.AddFood();
            FoodTool.instance.UpdateTextMeshPro();
            textDisplay.text = money.ToString() + " " + "Reais";
        }
    }

    public void BuyFoodTwo()
    {
        if(money > food2)
        {
            money -= food2;
            FoodToolTwo.instance.AddFood();
            FoodToolTwo.instance.UpdateTextMeshPro();
            textDisplay.text = money.ToString() + " " + "Reais";
        }
    }
    public void BuyFoodThree()
    {
        if (money > food3)
        {
            money -= food3;
            FoodToolThree.instance.AddFood();
            FoodToolThree.instance.UpdateTextMeshPro();
            textDisplay.text = money.ToString() + " " + "Reais";
        }
    }

    public void BuyMedicineOne()
    {
        if (money > medicine1)
        {
            money -= medicine1;
            MedicineTool.instance.AddMedicine();
            MedicineTool.instance.UpdateTextMeshPro();
            textDisplay.text = money.ToString() + " " + "Reais";
        }
    }
    public void BuyMedicineTwo()
    {
        if (money > medicine1)
        {
            money -= medicine1;
            MedicineTool2.instance.AddMedicine();
            MedicineTool2.instance.UpdateTextMeshPro();
            textDisplay.text = money.ToString() + " " + "Reais";
        }
    }
    public void BuyMedicineThree()
    {
        if (money > medicine1)
        {
            money -= medicine1;
            MedicineTool3.instance.AddMedicine();
            MedicineTool3.instance.UpdateTextMeshPro();
            textDisplay.text = money.ToString() + " " + "Reais";
        }
    }
}
