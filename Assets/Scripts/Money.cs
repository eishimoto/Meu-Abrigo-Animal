using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class Money : MonoBehaviour
{
    //TMPro
    [SerializeField] private int money;
    [SerializeField] private TextMeshProUGUI textDisplay;

    //int
    [SerializeField] private int food1, food2, food3;
    [SerializeField] private int medicine1, medicine2, medicine3;

    //List
    [SerializeField] private List<GameObject> foodUnlock;
    [SerializeField] private List<GameObject> balls;
    [SerializeField] private List<GameObject> cutTool;
    [SerializeField] private List<GameObject> cleaningTools;

    //bool
    private bool foodBowl = false;
    private bool foodBag = false;
    private bool beachBall = false;
    private bool trimmer = false;
    private bool shampoo = false;
    private bool dryer = false;
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
    public void UnlockFoodBowl()
    {
        if(money > 15 && foodBowl == false)
        {
            money -= 15;
            foodUnlock[0].SetActive(true);
            foodBowl = true;
            UpdateMoney();
        }

        else if (money > food2)
        {
            money -= food2;
            FoodToolTwo.instance.AddFood();
            FoodToolTwo.instance.UpdateTextMeshPro();
            textDisplay.text = money.ToString() + " " + "Reais";
        }
    }
    public void UnlockFoodBag()
    {
        if (money > 25 && foodBag == false)
        {
            money -= 25;
            foodUnlock[1].SetActive(true);
            foodBag = true;
            UpdateMoney();
        }
        else if (money > food3)
        {
            money -= food3;
            FoodToolThree.instance.AddFood();
            FoodToolThree.instance.UpdateTextMeshPro();
            textDisplay.text = money.ToString() + " " + "Reais";
        }
    }

    public void UnlockBeachBall()
    {
        if (money > 30 && beachBall == false)
        {
            money -= 30;
            balls[0].SetActive(false);
            balls[1].SetActive(true);
            beachBall = true;
            UpdateMoney();
        }
    }

    public void UnlockTrimmer()
    {
        if(money > 50 && trimmer == false)
        {
            money -= 50;
            cutTool[0].SetActive(false);
            cutTool[1].SetActive(true);
            trimmer = true;
            UpdateMoney();
        }
    }

    public void UnlockShampoo()
    {
        if (money > 50 && shampoo == false)
        {
            money -= 50;
            cleaningTools[0].SetActive(false);
            cleaningTools[2].SetActive(true);
            shampoo = true;
            UpdateMoney();
        }
    }

    public void UnlockDryer()
    {
        if (money > 100 && dryer == false)
        {
            money -= 100;
            cleaningTools[1].SetActive(false);
            cleaningTools[3].SetActive(true);
            dryer = true;
            UpdateMoney();
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
