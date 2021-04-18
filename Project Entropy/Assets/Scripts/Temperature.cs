using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.Random;

public class Temperature : MonoBehaviour
{
    public Text timerText;
    public Text tempText;
    public Text dayText;
    private float startTime;
    public double currentTemperature;
    private double incTemperature;
    private double decTemperature;
    //private int startDay;
    private bool finished;
    private static int tempMin;
    private static int tempMax;
    private float tempTimer;
    private bool blizzard;
    private float startBlizzardTimer;
    private float currentBlizzardTimer;
    private float endingBlizzardTimer;

    void Start()
    {
        startTime = Time.time; //time starts at zero
        currentTemperature = 0; //the temperature starts at 0;
        incTemperature = .5;
        decTemperature = -.5;
        //startDay = 0;
        //day = 0;
        tempMin = -30;
        tempMax = 40;
        tempTimer = Time.time;
        blizzard = false;
        startBlizzardTimer = Time.time;
        currentBlizzardTimer = Time.time;
        endingBlizzardTimer = Time.time;
    }

    void Update()
    {
        int num = Random.Range(0, 10);
        int weatherEvent = Random.Range(0, 1000);


        if (weatherEvent == 500 )
        {
            blizzard = true;
            if (blizzard)
            {
                if (Time.time - startBlizzardTimer > 2 && currentTemperature != -30)
                {
                    currentTemperature -= 1;
                    startBlizzardTimer = Time.time;
                    Debug.Log(currentTemperature);
                }
                else if (Time.time - currentBlizzardTimer < 60 && currentTemperature == -30)
                {
                   // currentTemperature = currentTemperature;
                    currentBlizzardTimer = Time.time;
                    Debug.Log(currentTemperature);
                }

                else if (Time.time - endingBlizzardTimer > 60 && currentTemperature == -30)
                {
                    currentTemperature += 1;
                    endingBlizzardTimer = Time.time;
                    Debug.Log(currentTemperature);
                }
                else
                {
                    blizzard = false;
                }
            }
        }

        else
        {
            if (Time.time - tempTimer > 2)
            {
                /**
                * If the random number is one or two it increases the temperature
                */
                if (num == 1 || num == 2 || num == 3)
                {

                    if (currentTemperature != tempMax)
                    {



                        currentTemperature = currentTemperature + incTemperature;
                        tempTimer = Time.time;
                        Debug.Log(currentTemperature);


                    }

                }

                /**
                 *  Temperature remains constant when these random numbers are called
                 * 
                 */
                else if (num == 4 || num == 5 || num == 6)
                {
                   // currentTemperature = currentTemperature;
                    tempTimer = Time.time;
                    Debug.Log(currentTemperature);

                }


                /**
                 * Temperature decreases when these random numbers are called.
                 */
                else if (num == 7 || num == 8 || num == 9 || num == 10)
                {
                    if (currentTemperature != tempMin)
                    {

                        currentTemperature = currentTemperature + decTemperature;
                        tempTimer = Time.time;
                        Debug.Log(currentTemperature);
                    }
                }

                else
                {
                    //currentTemperature = currentTemperature;
                    Debug.Log(currentTemperature);
                }
            }
        }
    }
}