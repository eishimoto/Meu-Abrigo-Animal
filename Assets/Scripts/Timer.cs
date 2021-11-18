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

    public static int day;
    public static bool resetPhotoValue = false;
    private void start()
    {
        day = 0;
        DayChange();
    }

    private void Update()
    {
        if (_timeValue > 0)
        {
            _timeValue += 2 * Time.deltaTime;
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
    private void DisplayTime(float timeToDisplay)
    {
        if (timeToDisplay >= 1020f)
        {
            _timeValue = _timeValueReset;
            day++;
            resetPhotoValue = true;
            loadForDayChange.SetActive(true);
            Money.instance.AddMoneyPhoto(100);
        }

        float hour = Mathf.FloorToInt(timeToDisplay / 60);
        float minute = Mathf.FloorToInt(timeToDisplay % 60);

        timerText.text = string.Format("{0:00}:{1:00}", hour, minute);
    }
    private void DayChange()
    {
        if (day == 0)
        {
            Circle.transform.SetParent(dayPos[1], false);
        }
        if (day == 1)
        {
            Circle.transform.SetParent(dayPos[2], false);
        }
        if (day == 2)
        {
            Circle.transform.SetParent(dayPos[3], false);
        }
        if (day == 3)
        {
            Circle.transform.SetParent(dayPos[4], false);
        }
        if (day == 4)
        {
            Circle.transform.SetParent(dayPos[5], false);
        }
        if (day == 5)
        {
            Circle.transform.SetParent(dayPos[6], false);
        }
        if (day == 6)
        {
            Circle.transform.SetParent(dayPos[0], false);
            AdopitionCanvas.SetActive(true);
        }
    }

    public void SkipTime()
    {
        day++;
        _timeValue = _timeValueReset;
        resetPhotoValue = true;
        Money.instance.AddMoneyPhoto(100);
        loadForDayChange.SetActive(true);
        if (day > 6)
        {
            day = 0;
        }
    }
}
