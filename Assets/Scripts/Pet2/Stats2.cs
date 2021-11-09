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
    private bool sick;
    [SerializeField] private List<Color> medecineColor;
    [SerializeField] private Image diseaseIndicator;

    //float
    private float hungerStats, affectionStats, hygineStats;

    //bool
    private bool canClean;

    //static
    public static int count = 0;
    public static Stats2 instance;

    public void OnEnable()
    {
        if (instance == null)
        {
            instance = this;
        }
    }


    private void Start()
    {
        hungerStats = maxHunger;
        affectionStats = maxAffection;
        hygineStats = maxHygine;
    }

    private void Update()
    {
        Diminish();
        GrowFur();
        if (UICanvas.on2 == true)
        {
            IsClean();
        }
        CheckIfSick();
    }

    public void Diminish()
    {
        hungerBar.fillAmount = hungerStats / maxHunger;
        hungerStats -= hungerPorcentage * Time.deltaTime;

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

            FoodTool.instance.UseInStats();
        }

        if (collision.CompareTag("Food2"))
        {
            hungerStats = hungerStats + 50;
            if (hungerStats >= maxHunger)
            {
                hungerStats = maxHunger;
            }

            FoodToolTwo.instance.UseInStats();
        }
        if (collision.CompareTag("Food3"))
        {
            hungerStats = hungerStats + 100;
            if (hungerStats >= maxHunger)
            {
                hungerStats = maxHunger;
            }

            FoodToolThree.instance.UseInStats();
        }
        if (collision.CompareTag("RedPill"))
        {
            if (MixPills.inMix == false)
            {
                MedicineTool.instance.UseInStats();
                maxAffection += 5;
            }
        }

        if (collision.CompareTag("GreenPill"))
        {
            if (MixPills.inMix == false)
            {
                MedicineTool2.instance.UseInStats();
                maxHunger += 5;
            }
        }

        if (collision.CompareTag("BluePill"))
        {
            if (MixPills.inMix == false)
            {
                MedicineTool3.instance.UseInStats();
                maxHygine += 5;
            }
        }

        if (collision.CompareTag("PurplePill"))
        {
            MixPills.instance.PurplePill();
            medecine1 = true;
        }

        if (collision.CompareTag("YellowPill"))
        {
            MixPills.instance.YellowPill();
            medecine2 = true;
        }

        if (collision.CompareTag("CyanPill"))
        {
            MixPills.instance.CyanPill();
            medecine3 = true;
        }

    }

    public void AddAffection(int value)
    {
        affectionStats = affectionStats + value;
        if (affectionStats >= maxAffection)
        {
            affectionStats = maxAffection;
        }
    }

    private void IsClean()
    {
        if (CleaningTool.squareClean == true || CleaningTool.triangleClean == true || CleaningTool.circleClean == true)
        {
            hygineStats = hygineStats + 50;
            if (hygineStats >= maxHygine)
            {
                hygineStats = maxHygine;
            }
            CleaningTool.squareClean = false;
            CleaningTool.triangleClean = false;
            CleaningTool.circleClean = false;
        }
    }
    private void GrowFur()
    {
        float randomTime = Random.Range(0, 60000);
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
        if (hungerStats <= 0)
        {
            disease1 = true;
            diseaseIndicator.color = medecineColor[0];
            if (disease1 == true)
            {
                diseaseText.text = ("Doença" + " 1 ");
            }
        }
        else if (hungerStats > 0 && medecine1 == true)
        {
            disease1 = false;
            diseaseIndicator.color = medecineColor[3];
            if (disease1 == false)
            {
                diseaseText.text = ("Saudável");
            }
            medecine1 = false;
        }

        if (hygineStats <= 0)
        {
            disease2 = true;
            diseaseIndicator.color = medecineColor[1];
            if (disease2 == true)
            {
                diseaseText.text = ("Doença" + " 2 ");
            }
        }
        else if (hygineStats > 0 && medecine2 == true)
        {
            disease2 = false;
            diseaseIndicator.color = medecineColor[3];
            if (disease2 == false)
            {
                diseaseText.text = ("Saudável");
            }
            medecine2 = false;
        }

        if (count == 4)
        {
            disease3 = true;
            diseaseIndicator.color = medecineColor[2];
            if (disease3 == true)
            {
                diseaseText.text = ("Doença" + " 3 ");
            }
        }
        else if (count == 0 && medecine3 == true)
        {
            disease3 = false;
            diseaseIndicator.color = medecineColor[3];
            if (disease3 == false)
            {
                diseaseText.text = ("Saudável");
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
}
