using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Stats : MonoBehaviour
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

    private float hungerStats, affectionStats, hygineStats;

    private void Start()
    {
        hungerStats = maxHunger;
        affectionStats = maxAffection;
        hygineStats = maxHygine;
    }

    private void Update()
    {
        Diminish();
    }

    private void Diminish()
    {
        hungerBar.fillAmount = hungerStats / maxHunger;
        hungerStats -= hungerPorcentage * Time.deltaTime;

        affectionBar.fillAmount = affectionStats / maxAffection;
        affectionStats -= affectionPorcentage * Time.deltaTime;

        hygineBar.fillAmount = hygineStats / maxHygine;
        hygineStats -= hyginePorcentage * Time.deltaTime;
        // Debug.Log(affectionStats); Debug.Log(hungerStats); Debug.Log(hygineStats);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Food"))
        {
            hungerStats = hungerStats + 50;
            if (hungerStats >= 100)
            {
                hungerStats = 100;
            }
        }

        if (collision.CompareTag("Fun"))
        {
            affectionStats = affectionStats + 50;
            if (affectionStats >= 100)
            {
                affectionStats = 100;
            }
        }

        if (collision.CompareTag("Clean"))
        {
            Invoke("IsClean", 3f);
        }

        if(collision.CompareTag("Pills"))
        {
            MixPills.instance.UsedPill();
        }
    }

    // funcions to Invoke
    private void IsClean()
    {
        hygineStats = hygineStats + 50;
        if (hygineStats >= 100)
        {
            hygineStats = 100;
        }
    }
}
