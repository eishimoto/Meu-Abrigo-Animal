using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    [SerializeField] private float _timeValue;
    [SerializeField] private float _timeValueReset;
    [SerializeField] private TextMeshProUGUI timerText;
    [SerializeField] private GameObject Circle;
    [SerializeField] private List<Transform> dayPos;
    [SerializeField] private GameObject loadForDayChange;
    [SerializeField] private GameObject AdopitionCanvas;
    [SerializeField] private GameObject LosePanel;
    [SerializeField] private GameObject skipButton;

    public static int day;
    public static int value;
    public static bool resetPhotoValue = false;
    public static bool stopAll;
    private void OnEnable()
    {
        day = 0;
        value = 5;
        stopAll = false;
    }
    private void start()
    {
        day = 0;
        value = 5;
        stopAll = false;
        DayChange();
    }

    private void Update()
    {
        if(UICanvas.runTime)
        {
            if (_timeValue > 0)
            {
                _timeValue += 3.9f * Time.deltaTime;
            }
            else
            {
                _timeValue = 540;
            }

            if (day < 6)
            {
                DisplayTime(_timeValue);
            }
            DayChange();
        }
    }
    private void DisplayTime(float timeToDisplay)
    {
        if(timeToDisplay >= 840)
        {
            skipButton.SetActive(true);
        }

        if (timeToDisplay >= 1020f)
        {
            NewDay();
        }

        float hour = Mathf.FloorToInt(timeToDisplay / 60);
        float minute = Mathf.FloorToInt(timeToDisplay % 60);

        timerText.text = string.Format("{0:00}:{1:00}", hour, minute);
    }
    private void DayChange()
    {
        if (day == 0)
        {
            Circle.transform.SetParent(dayPos[0], false);
        }
        if (day == 1)
        {
            Circle.transform.SetParent(dayPos[1], false);
        }
        if (day == 2)
        {
            Circle.transform.SetParent(dayPos[2], false);
        }
        if (day == 3)
        {
            Circle.transform.SetParent(dayPos[3], false);
        }
        if (day == 4)
        {
            Circle.transform.SetParent(dayPos[4], false);
        }
        if (day == 5)
        {
            Circle.transform.SetParent(dayPos[5], false);
        }
        if (day == 6)
        {
            Circle.transform.SetParent(dayPos[6], false);
            FinalScene();
        }
    }

    public void SkipTime()
    {
        NewDay();
    }

    private void FinalScene()
    {
        if(!Stats.sick || !Stats2.sick || !Stats3.sick || !Stats4.sick)
        {
            AdopitionCanvas.SetActive(true);
        }
        if(Stats.sick && Stats2.sick && Stats3.sick && Stats4.sick )
        {
            LosePanel.SetActive(true);
        }
    }

    public void NewDay()
    {
        day++;
        _timeValue = _timeValueReset;
        resetPhotoValue = true;
        Money.instance.AddMoneyPhoto(value);
        loadForDayChange.SetActive(true);
        skipButton.SetActive(false);

        if (day > 6)
        {
            day = 0;
        }
    }

    public void SetStopAllToTrue()
    {
        stopAll = true;
    }

}
