using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Money : MonoBehaviour
{
    [SerializeField] private int money;
    [SerializeField] private TextMeshProUGUI textDisplay;

    //static
    public static int moneyUse;

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
        moneyUse = money;
    }

    public void UpdateMoney()
    {
        textDisplay.text = null;
        textDisplay.text = money.ToString() + " " + "Reais";
    }
}
