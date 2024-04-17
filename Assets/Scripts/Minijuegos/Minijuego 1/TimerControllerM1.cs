using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerControllerM1 : MonoBehaviour
{
    public enum CountdownFormatting { MinutesSeconds, Seconds };
    public CountdownFormatting countdownFormatting = CountdownFormatting.MinutesSeconds;
    public bool showMilliseconds = false;
    public float countdownTime = 120f;

    Text countdownText;
    float countdownInternal;
    bool countdownOver = false;

    // Start is called before the first frame update
    void Start()
    {
        countdownText = GetComponent<Text>();
        countdownInternal = countdownTime; //Inicializa el temporizador
    }

    void FixedUpdate()
    {
        if (countdownInternal > 0)
        {
            countdownInternal -= Time.deltaTime;

            //Crea un límite en el valor del temporizador para que nunca sea inferior a 0
            if (countdownInternal < 0)
            {
                countdownInternal = 0;
            }

            countdownText.text = FormatTime(countdownInternal, countdownFormatting, showMilliseconds);
        }
        else
        {
            if (!countdownOver)
            {
                countdownOver = true;

                Debug.Log("El tiempo ha terminado");

                //Añade tu código aquí...
            }
        }
    }

    string FormatTime(float time, CountdownFormatting formatting, bool includeMilliseconds)
    {
        string timeText = "";

        int intTime = (int)time;
        int minutesTotal = intTime / 60;
        int minutesFormatted = minutesTotal % 60;
        int secondsTotal = intTime;
        int secondsFormatted = intTime % 60;
        int milliseconds = (int)(time * 100);
        milliseconds = milliseconds % 100;

        if (includeMilliseconds)
        {
            if (formatting == CountdownFormatting.MinutesSeconds)
            {
                timeText = string.Format("{0:00}:{1:00}:{2:00}", minutesFormatted, secondsFormatted, milliseconds);
            }
            else if (formatting == CountdownFormatting.Seconds)
            {
                timeText = string.Format("{0:00}:{1:00}", secondsFormatted, milliseconds);
            }
        }
        else
        {
            if (formatting == CountdownFormatting.MinutesSeconds)
            {
                timeText = string.Format("{0:00}:{1:00}", minutesFormatted, secondsFormatted);
            }
            else if (formatting == CountdownFormatting.Seconds)
            {
                timeText = string.Format("{0:00}", secondsFormatted);
            }
        }

        return timeText;
    }
}
