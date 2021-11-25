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
    [SerializeField] private int medicine1;

    //List
    [SerializeField] private List<GameObject> foodUnlock;
    [SerializeField] private List<GameObject> balls;
    [SerializeField] private List<GameObject> cutTool;
    [SerializeField] private List<GameObject> cleaningTools;
    [SerializeField] private List<GameObject> accessorysToAdoption;

    [SerializeField] private List<Image> toolsImage;
    [SerializeField] private List<Button> toolsButtons;
    [SerializeField] private List<Sprite> toolsSprites;

    [SerializeField] private List<Image> AccessoryImage;
    [SerializeField] private List<Button> AccessoryButtons;
    [SerializeField] private List<Sprite> AccessorySprites;
    //bool
    private bool foodBowl = false;
    private bool foodBag = false;
    private bool beachBall = false;
    private bool trimmer = false;
    private bool shampoo = false;
    private bool dryer = false;

    //bool acessory
    private bool ballon = false;
    private bool hat = false;
    private bool yellowTie = false;
    private bool blueTie = false;
    private bool redTie = false;
    private bool purpleTie = false;
    private bool tie = false;
    private bool monacle = false;
    private bool teeth = false;
    private bool eyePatch = false;
    private bool collar = false;
    private bool walker = false;

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
        StartCoroutine(CheckHowMuchMoney());
    }

    IEnumerator CheckHowMuchMoney()
    {
        yield return new WaitForSeconds(1);
        textDisplay.text = null;
        textDisplay.text = money.ToString();
    }

    public void UpdateMoney()
    {
        textDisplay.text = null;
        textDisplay.text = money.ToString();
    }

    public void AddMoneyPhoto(int valueToAddInMoney)
    {
        textDisplay.text = null;
        money += valueToAddInMoney;
        textDisplay.text = money.ToString();
    }

    public void BuyFoodOne()
    {
        if(money >= food1)
        {
            money -= food1;
            FoodTool.instance.AddFood();
            FoodTool.instance.UpdateTextMeshPro();
            textDisplay.text = money.ToString();
        }
    }
    public void UnlockFoodBowl()
    {
        if(money >= 20 && foodBowl == false)
        {
            money -= 20;
            foodUnlock[0].SetActive(true);
            foodBowl = true;
            UpdateMoney();
        }

        else if (money >= food2)
        {
            money -= food2;
            FoodToolTwo.instance.AddFood();
            FoodToolTwo.instance.UpdateTextMeshPro();
            textDisplay.text = money.ToString();
        }
    }
    public void UnlockFoodBag()
    {
        if (money >= 30 && foodBag == false)
        {
            money -= 30;
            foodUnlock[1].SetActive(true);
            foodBag = true;
            UpdateMoney();
        }
        else if (money >= food3)
        {
            money -= food3;
            FoodToolThree.instance.AddFood();
            FoodToolThree.instance.UpdateTextMeshPro();
            textDisplay.text = money.ToString();
        }
    }

    public void UnlockBeachBall()
    {
        if (money >= 30 && beachBall == false)
        {
            money -= 30;
            balls[0].SetActive(false);
            balls[1].SetActive(true);
            beachBall = true;
            UpdateMoney();
            toolsImage[0].sprite = toolsSprites[0];
            toolsButtons[0].interactable = false;
        }
    }

    public void UnlockTrimmer()
    {
        if(money >= 50 && trimmer == false)
        {
            money -= 50;
            cutTool[0].SetActive(false);
            cutTool[1].SetActive(true);
            trimmer = true;
            UpdateMoney();
            toolsImage[1].sprite = toolsSprites[1];
            toolsButtons[1].interactable = false;
        }
    }

    public void UnlockShampoo()
    {
        if (money >= 20 && shampoo == false)
        {
            money -= 20;
            cleaningTools[0].SetActive(false);
            cleaningTools[2].SetActive(true);
            shampoo = true;
            UpdateMoney();
            toolsImage[2].sprite = toolsSprites[2];
            toolsButtons[2].interactable = false;
        }
    }

    public void UnlockDryer()
    {
        if (money >= 100 && dryer == false)
        {
            money -= 100;
            cleaningTools[1].SetActive(false);
            cleaningTools[3].SetActive(true);
            dryer = true;
            UpdateMoney();
            toolsImage[3].sprite = toolsSprites[3];
            toolsButtons[3].interactable = false;
        }
    }

    public void BuyMedicineOne()
    {
        if (money >= medicine1)
        {
            money -= medicine1;
            MedicineTool.instance.AddMedicine();
            UpdateMoney();
        }
    }
    public void BuyMedicineTwo()
    {
        if (money >= medicine1)
        {
            money -= medicine1;
            MedicineTool2.instance.AddMedicine();
            UpdateMoney();
        }
    }
    public void BuyMedicineThree()
    {
        if (money >= medicine1)
        {
            money -= medicine1;
            MedicineTool3.instance.AddMedicine();
            UpdateMoney();
        }
    }
    public void ActivateBallon()
    {
        if(money >= 10 && !ballon)
        {
            money -= 10;
            accessorysToAdoption[0].SetActive(true);
            textDisplay.text = money.ToString();
            ballon = true;
        }
    }
    public void ActivateHat()
    {
        if (money >= 10 && !hat)
        {
            money -= 10;
            accessorysToAdoption[1].SetActive(true);
            textDisplay.text = money.ToString();
            hat = true;
            AccessoryImage[0].sprite = AccessorySprites[0];
            AccessoryButtons[0].interactable = false;
        }
    }
    public void ActivateYellowTie()
    {
        if (money >= 10 && !yellowTie)
        {
            money -= 10;
            accessorysToAdoption[2].SetActive(true);
            textDisplay.text = money.ToString();
            yellowTie = true;
            AccessoryImage[4].sprite = AccessorySprites[4];
            AccessoryButtons[4].interactable = false;
        }
    }
    public void ActivateBlueTie()
    {
        if (money >= 10 && !blueTie)
        {
            money -= 10;
            accessorysToAdoption[3].SetActive(true);
            textDisplay.text = money.ToString();
            blueTie = true;
            AccessoryImage[6].sprite = AccessorySprites[6];
            AccessoryButtons[6].interactable = false;
        }
    }
    public void ActivateRedTie()
    {
        if (money >= 10 && !redTie)
        {
            money -= 10;
            accessorysToAdoption[4].SetActive(true);
            textDisplay.text = money.ToString();
            redTie = true;
            AccessoryImage[3].sprite = AccessorySprites[3];
            AccessoryButtons[3].interactable = false;
        }
    }
    public void ActivatePurpleTie()
    {
        if (money >= 10 && !purpleTie)
        {
            money -= 10;
            accessorysToAdoption[5].SetActive(true);
            textDisplay.text = money.ToString();
            purpleTie = true;
            AccessoryImage[5].sprite = AccessorySprites[5];
            AccessoryButtons[5].interactable = false;
        }
    }
    public void ActivateTie()
    {
        if (money >= 10 && !tie)
        {
            money -= 10;
            accessorysToAdoption[6].SetActive(true);
            textDisplay.text = money.ToString();
            tie = true;
            AccessoryImage[7].sprite = AccessorySprites[7];
            AccessoryButtons[7].interactable = false;
        }
    }
    public void ActivateMonacle()
    {
        if (money >= 10 && !monacle)
        {
            money -= 10;
            accessorysToAdoption[7].SetActive(true);
            textDisplay.text = money.ToString();
            monacle = true;
            AccessoryImage[2].sprite = AccessorySprites[2];
            AccessoryButtons[2].interactable = false;
        }
    }
    public void ActivateTeeth()
    {
        if (money >= 10 && !teeth)
        {
            money -= 10;
            accessorysToAdoption[8].SetActive(true);
            textDisplay.text = money.ToString();
            teeth = true;
            AccessoryImage[1].sprite = AccessorySprites[1];
            AccessoryButtons[1].interactable = false;
        }
    }
    public void ActivateEyePatch()
    {
        if (money >= 10 && !eyePatch)
        {
            money -= 10;
            accessorysToAdoption[9].SetActive(true);
            textDisplay.text = money.ToString();
            eyePatch = true;
            AccessoryImage[8].sprite = AccessorySprites[8];
            AccessoryButtons[8].interactable = false;
        }
    }
    public void ActivateCollar()
    {
        if (money >= 10 && !collar)
        {
            money -= 10;
            accessorysToAdoption[10].SetActive(true);
            textDisplay.text = money.ToString();
            collar = true;
        }
    }
    public void ActivateWalker()
    {
        if (money >= 10 && !walker)
        {
            money -= 10;
            accessorysToAdoption[11].SetActive(true);
            textDisplay.text = money.ToString();
            walker = true;
        }
    }
}
