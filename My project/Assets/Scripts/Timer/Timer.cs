using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
    public TextMeshProUGUI  timer;
    public float maxTemperature = 100f; // Starting temperature
    public float minTemperature = 0f; // Minimum temperature the thermometer can show
    public float temperatureDropRate = 2f; // Degrees to drop every interval
    public float dropInterval = 60f; // Interval in seconds (1 minute)

    private float currentTemperature;
    private float elapsedTime = 0f;

    // Update is called once per frame
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
        timer.text = currentTemperature.ToString()+"C";
    }
}
