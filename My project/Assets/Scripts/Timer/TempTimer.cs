using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
    public TextMeshProUGUI display;
    public float maxTemperature = 0f; // Starting temperature
    public float minTemperature = -55f; // Minimum temperature the thermometer can show
    public float temperatureDropRate = 2f; // Degrees to drop every interval
    public float dropInterval = 60f; // Interval in seconds (1 minute)
    public PlayerMovement Speed;
    public PlayerHealth HP;

    private float currentTemperature;
    private float elapsedTime = 0f;
    private int count;

    void Start()
    {
        currentTemperature = maxTemperature;
        UpdateThermometer();

    }

    void Update()
    {
        elapsedTime += Time.deltaTime;
        if (elapsedTime >= dropInterval)
        {
            elapsedTime = 0f;
            DecreaseTemperature();
            count++;
            Debuff();
        }
    }

    void DecreaseTemperature()
    {
        currentTemperature -= temperatureDropRate;
        if (currentTemperature < minTemperature)
        {
            currentTemperature = minTemperature;
        }
        UpdateThermometer();
    }

    void UpdateThermometer()
    {
        // Assuming the thermometerImage fillAmount is used to show the temperature level
        display.text = currentTemperature+" C";
    }
    void Debuff()
    {
        if(count >= 7)
        {
           HP.currentHealth -= 5f;

        }
        if (count >= 10)
        {
           Speed.moveSpeed -= 0.2f;
        }
    }
}