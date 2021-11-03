using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    [SerializeField] private float _timeValue = 600;
    [SerializeField] private float _timeValueReset;
    [SerializeField] private TextMeshProUGUI timerText;
    [SerializeField] private GameObject Circle;
    [SerializeField] private List<Vector2> dayPos;
    [SerializeField] private float division;

    private int day; 

    private void start()
    {
        day = 0;
    }

   private void Update()
   {
        if(_timeValue > 0)
        {
            _timeValue -= Time.deltaTime;
        }
        else
        {
            _timeValue = 0;
        }

        DisplayTime(_timeValue);
        DayChange();
   }
    private void DisplayTime(float timeToDisplay)
    {
        if (timeToDisplay < 0)
        {
            timeToDisplay = 0;
        }
        else if(timeToDisplay == 0)
        {
            day++;
            _timeValue = _timeValueReset;
        }

        float hour = Mathf.FloorToInt(timeToDisplay / 60);
        float minute = Mathf.FloorToInt(timeToDisplay % 60);

        timerText.text = string.Format("{0:00}:{1:00}", hour, minute);
    }

    private void DayChange()
    {
        if(day == 0)
        {
            Circle.transform.position = dayPos[0] / division;
        }
        if (day == 1)
        {
            Circle.transform.position = dayPos[1] / division;
        }
        if (day == 2)
        {
            Circle.transform.position = dayPos[2] / division;
        }
        if (day == 3)
        {
            Circle.transform.position = dayPos[3] / division;
        }
        if (day == 4)
        {
            Circle.transform.position = dayPos[4] / division;
        }
        if (day == 5)
        {
            Circle.transform.position = dayPos[5] / division;
        }
        if (day == 6)
        {
            Circle.transform.position = dayPos[6] / division;
        }
    }
}
