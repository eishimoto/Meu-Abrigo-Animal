using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Stats2 : MonoBehaviour
{
    [Header("Hunger")]
    [SerializeField] private Image hungerBar;
    [SerializeField] private float maxHunger = 100f;
    [SerializeField] private float hungerPorcentage;
    [Header("Affection")]
    [SerializeField] private Image affectionBar;
    [SerializeField] private float maxAffection = 100f;
    [SerializeField] private float affectionPorcentage;
    [Header("Hygine")]
    [SerializeField] private Image hygineBar;
    [SerializeField] private float maxHygine = 100f;
    [SerializeField] private float hyginePorcentage;

    [Header("Fur")]
    [SerializeField] private GameObject[] fur;

    [Header("Disease")]
    [SerializeField] private TextMeshProUGUI diseaseText;
    private bool disease1;
    private bool disease2;
    private bool disease3;
    private bool medecine1;
    private bool medecine2;
    private bool medecine3;
    public static bool sick;
    [SerializeField] private List<Color> medecineColor;
    [SerializeField] private Image diseaseIndicator;
    [SerializeField] private Image diseaseIcon;
    [SerializeField] private List<Sprite> diseaseIconList;

    //animation
    private Animator myAnimator;

    //float
    private float hungerStats, affectionStats, hygineStats;


    //static
    public static int count = 0;
    public static Stats2 instance;
    public static bool petNecessity;
    public static bool action;

    public void OnEnable()
    {
        if (instance == null)
        {
            instance = this;
        }
    }


    private void Start()
    {
        myAnimator = GetComponent<Animator>();
        hungerStats = maxHunger;
        affectionStats = maxAffection;
        hygineStats = maxHygine;
        //hungerStats = 50;
        //affectionStats = 70;
        //hygineStats = 70;
        
    }

    private void Update()
    {
        if (!Timer.stopAll)
        {
            if (UICanvas.runTime)
            {
                Diminish();
                GrowFur();
                CheckIfSick();
                Animations();
                PlayButtonAnimation();
            }
        }
        if (UICanvas.on2 == true)
        {
            IsClean();
        }
    }

    public void Diminish()
    {
        hungerBar.fillAmount = hungerStats / maxHunger;
        hungerStats -= hungerPorcentage * Time.deltaTime;
        if (hungerStats <= 0) hungerStats = 0;

        if (hungerStats > 50)
        {
            ColorFood2.instance.FoodColorOne();
        }
        if (hungerStats < 50)
        {
            ColorFood2.instance.FoodColorTwo();
        }
        if (hungerStats < 25)
        {
            ColorFood2.instance.FoodColorThree();
        }

        affectionBar.fillAmount = affectionStats / maxAffection;
        affectionStats -= affectionPorcentage * Time.deltaTime;
        if (affectionStats <= 0) affectionStats = 0;

        if (affectionStats > 50)
        {
            ColorLove2.instance.LoveColorOne();
        }
        if (affectionStats < 50)
        {
            ColorLove2.instance.LoveColorTwo();
        }
        if (affectionStats < 25)
        {
            ColorLove2.instance.LoveColorThree();
        }

        hygineBar.fillAmount = hygineStats / maxHygine;
        hygineStats -= hyginePorcentage * Time.deltaTime;
        if (hygineStats <= 0) hygineStats = 0;

        if (hygineStats > 50)
        {
            ColorClean2.instance.CleanColorOne();
        }
        if (hygineStats < 50)
        {
            ColorClean2.instance.CleanColorTwo();
        }
        if (hygineStats < 25)
        {
            ColorClean2.instance.CleanColorThree();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Food"))
        {
            hungerStats = hungerStats + 20;
            if (hungerStats >= maxHunger)
            {
                hungerStats = maxHunger;
            }
            Money.instance.AddMoneyPhoto(10);
            FoodTool.instance.UseInStats();
            action = true;
        }

        if (collision.CompareTag("Food2"))
        {
            hungerStats = hungerStats + 50;
            if (hungerStats >= maxHunger)
            {
                hungerStats = maxHunger;
            }
            Money.instance.AddMoneyPhoto(10);
            FoodToolTwo.instance.UseInStats();
            action = true;
        }
        if (collision.CompareTag("Food3"))
        {
            hungerStats = hungerStats + 100;
            if (hungerStats >= maxHunger)
            {
                hungerStats = maxHunger;
            }
            Money.instance.AddMoneyPhoto(10);
            FoodToolThree.instance.UseInStats();
            action = true;
        }
        if (collision.CompareTag("RedPill"))
        {
            if (MixPills.inMix == false)
            {
                MedicineTool.instance.UseInStats();
                maxAffection += 5;
                Money.instance.AddMoneyPhoto(20);
            }
            action = true;
        }

        if (collision.CompareTag("GreenPill"))
        {
            if (MixPills.inMix == false)
            {
                MedicineTool2.instance.UseInStats();
                maxHunger += 5;
                Money.instance.AddMoneyPhoto(10);
            }
            action = true;
        }

        if (collision.CompareTag("BluePill"))
        {
            if (MixPills.inMix == false)
            {
                MedicineTool3.instance.UseInStats();
                maxHygine += 5;
                Money.instance.AddMoneyPhoto(20);
            }
            action = true;
        }
        if (collision.CompareTag("PurplePill"))
        {
            MixPills.instance.PurplePill();
            MedicineTool.instance.PlayMedecineSound();
            medecine3 = true;
            Money.instance.AddMoneyPhoto(20);
            action = true;
        }

        if (collision.CompareTag("YellowPill"))
        {
            MixPills.instance.YellowPill();
            MedicineTool.instance.PlayMedecineSound();
            medecine1 = true;
            Money.instance.AddMoneyPhoto(20);
            action = true;
        }

        if (collision.CompareTag("CyanPill"))
        {
            MixPills.instance.CyanPill();
            MedicineTool.instance.PlayMedecineSound();
            medecine2 = true;
            Money.instance.AddMoneyPhoto(20);
            action = true;
        }
    }
    public void AddAffection(int value)
    {
        affectionStats = affectionStats + value;
        if (affectionStats >= maxAffection)
        {
            affectionStats = maxAffection;
            action = true;
        }
    }
    private void IsClean()
    {
        int valueToadd = 0;
        if (CleaningTool2.squareClean == true || CleaningTool2.triangleClean == true || CleaningTool2.circleClean == true)
        {
            if (CleaningTool.soapOn && CleaningTool2.towlOn)
            {
                valueToadd = 20;
            }
            if (CleaningTool.soapOn && CleaningTool2.dryerOn)
            {
                valueToadd = 30;
            }
            if (CleaningTool.shampooOn && CleaningTool2.towlOn)
            {
                valueToadd = 30;
            }
            if (CleaningTool.shampooOn && CleaningTool2.dryerOn && !CleaningTool.soapOn && !CleaningTool2.towlOn)
            {
                valueToadd = 50;
            }
            action = true;

            hygineStats = hygineStats + valueToadd;
            if (hygineStats >= maxHygine)
            {
                hygineStats = maxHygine;
            }
            CleaningTool2.squareClean = false;
            CleaningTool2.triangleClean = false;
            CleaningTool2.circleClean = false;
            CleaningTool.firtstToolUsed = false;
            Money.instance.AddMoneyPhoto(10);
        }
    }
    private void GrowFur()
    {
        float randomTime = Random.Range(0, 6000);
        if (randomTime == 10)
        {
            fur[0].SetActive(true);

        }
        if (randomTime == 20)
        {
            fur[1].SetActive(true);

        }
        if (randomTime == 30)
        {
            fur[2].SetActive(true);

        }
        if (randomTime == 40)
        {
            fur[3].SetActive(true);

        }

        if (count > 4) count = 4;

        if (count == 0)
        {
            ColorFur2.instance.FurColorOne();
        }
        if (count == 2)
        {
            ColorFur2.instance.FurColorTwo();
        }
        if (count > 2)
        {
            ColorFur2.instance.FurColorThree();
        }
    }
    private void CheckIfSick()
    {
        if (hungerStats <= 0 && !disease2 && !disease3)
        {
            disease1 = true;
            diseaseIndicator.color = medecineColor[1];
            diseaseIcon.sprite = diseaseIconList[1];
            if (disease1 == true)
            {
                diseaseText.text = ("Dor" + " de " + "barriga");
                StatsColor2.instance.ColorChangeTwo();
            }
        }
        else if (hungerStats > 0 && medecine1 == true)
        {
            disease1 = false;
            diseaseIndicator.color = medecineColor[3];
            diseaseIcon.sprite = null;
            if (disease1 == false)
            {
                diseaseText.text = ("Saudável");
                StatsColor2.instance.ColorChangeOne();
            }
            medecine1 = false;
        }

        if (hygineStats <= 0 && !disease1 && !disease3)
        {
            disease2 = true;
            diseaseIndicator.color = medecineColor[2];
            diseaseIcon.sprite = diseaseIconList[2];
            if (disease2 == true)
            {
                diseaseText.text = ("Dermatite");
                StatsColor2.instance.ColorChangeTwo();
            }
        }
        else if (hygineStats > 0 && medecine2 == true)
        {
            disease2 = false;
            diseaseIndicator.color = medecineColor[3];
            diseaseIcon.sprite = null;
            diseaseIcon.sprite = null;
            if (disease2 == false)
            {
                diseaseText.text = ("Saudável");
                StatsColor2.instance.ColorChangeOne();
            }
            medecine2 = false;
        }

        if (count == 4 && !disease1 && !disease2)
        {
            disease3 = true;
            diseaseIndicator.color = medecineColor[0];
            diseaseIcon.sprite = diseaseIconList[0];
            if (disease3 == true)
            {
                diseaseText.text = ("Queda" + " de " + "pelo");
                StatsColor2.instance.ColorChangeTwo();
            }
        }
        else if (count == 0 && medecine3 == true)
        {
            disease3 = false;
            diseaseIndicator.color = medecineColor[3];
            diseaseIcon.sprite = null;
            if (disease3 == false)
            {
                diseaseText.text = ("Saudável");
                StatsColor2.instance.ColorChangeOne();
            }
            medecine3 = false;
        }

        if (disease1 || disease2 || disease3)
        {
            sick = true;
        }
        else
        {
            sick = false;
        }
    }
    private void Animations()
    {
        if(hungerStats < 50)
        {
            myAnimator.SetBool("isHungry", true);
        }
        else if(hungerStats > 50)
        {
            myAnimator.SetBool("isHungry", false);
        }

        if (affectionStats < 50)
        {
            myAnimator.SetBool("isSad", true);
        }
        else if (affectionStats > 50)
        {
            myAnimator.SetBool("isSad", false);
        }

        if (hygineStats < 50)
        {
            myAnimator.SetBool("isDirty", true);
        }
        else if (hygineStats > 50)
        {
            myAnimator.SetBool("isDirty", false);
        }

        if (sick)
        {
            myAnimator.SetBool("isSick", true);
        }
        else if(!sick)
        {
            myAnimator.SetBool("isSick", false);
        }
    }
    public void PlayButtonAnimation()
    {
        if (hungerStats < 50 || hygineStats < 50 || affectionStats < 50 || count >= 2 || sick)
        {
            petNecessity = true;
        }
        else if (hungerStats > 50 || hygineStats > 50 || affectionStats > 50 || count < 2 || !sick)
        {
            petNecessity = false;
        }
    }
}
