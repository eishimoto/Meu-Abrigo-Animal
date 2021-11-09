using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Stats4 : MonoBehaviour
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

    //float
    private float hungerStats, affectionStats, hygineStats;

    //bool
    private bool canClean;

    //static
    public static int count = 0;
    public static Stats4 instance;

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
        if (UICanvas.on4 == true)
        {
            IsClean();
        }
    }

    public void Diminish()
    {
        hungerBar.fillAmount = hungerStats / maxHunger;
        hungerStats -= hungerPorcentage * Time.deltaTime;

        if (hungerStats > 50)
        {
            ColorFood4.instance.FoodColorOne();
        }
        if (hungerStats < 50)
        {
            ColorFood4.instance.FoodColorTwo();
        }
        if (hungerStats < 25)
        {
            ColorFood4.instance.FoodColorThree();
        }

        affectionBar.fillAmount = affectionStats / maxAffection;
        affectionStats -= affectionPorcentage * Time.deltaTime;

        if (affectionStats > 50)
        {
            ColorLove4.instance.LoveColorOne();
        }
        if (affectionStats < 50)
        {
            ColorLove4.instance.LoveColorTwo();
        }
        if (affectionStats < 25)
        {
            ColorLove4.instance.LoveColorThree();
        }

        hygineBar.fillAmount = hygineStats / maxHygine;
        hygineStats -= hyginePorcentage * Time.deltaTime;

        if (hygineStats > 50)
        {
            ColorClean4.instance.CleanColorOne();
        }
        if (hygineStats < 50)
        {
            ColorClean4.instance.CleanColorTwo();
        }
        if (hygineStats < 25)
        {
            ColorClean4.instance.CleanColorThree();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Food"))
        {
            hungerStats = hungerStats + 20;
            if (hungerStats >= 100)
            {
                hungerStats = 100;
            }

            FoodTool.instance.UseInStats();
        }

        if (collision.CompareTag("Food2"))
        {
            hungerStats = hungerStats + 50;
            if (hungerStats >= 100)
            {
                hungerStats = 100;
            }

            FoodToolTwo.instance.UseInStats();
        }
        if (collision.CompareTag("Food3"))
        {
            hungerStats = hungerStats + 100;
            if (hungerStats >= 100)
            {
                hungerStats = 100;
            }

            FoodToolThree.instance.UseInStats();
        }

        if (collision.CompareTag("RedPill"))
        {
            if (MixPills.inMix == false)
            {
                MedicineTool.instance.UseInStats();
            }
        }

        if (collision.CompareTag("GreenPill"))
        {
            if (MixPills.inMix == false)
            {
                MedicineTool2.instance.UseInStats();
            }
        }

        if (collision.CompareTag("BluePill"))
        {
            if (MixPills.inMix == false)
            {
                MedicineTool3.instance.UseInStats();
            }
        }

        if (collision.CompareTag("PurplePill"))
        {
            MixPills.instance.PurplePill();
        }

        if (collision.CompareTag("YellowPill"))
        {
            MixPills.instance.YellowPill();
        }

        if (collision.CompareTag("CyanPill"))
        {
            MixPills.instance.CyanPill();
        }

    }

    public void AddAffection(int value)
    {
        affectionStats = affectionStats + value;
        if (affectionStats >= 100)
        {
            affectionStats = 100;
        }
    }

    private void IsClean()
    {
        if (CleaningTool.squareClean == true || CleaningTool.triangleClean == true || CleaningTool.circleClean == true)
        {
            hygineStats = hygineStats + 50;
            if (hygineStats >= 100)
            {
                hygineStats = 100;
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
            ColorFur4.instance.FurColorOne();
        }
        if (count == 2)
        {
            ColorFur4.instance.FurColorTwo();
        }
        if (count > 2)
        {
            ColorFur4.instance.FurColorThree();
        }
    }
}
