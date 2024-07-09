using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hint : MonoBehaviour
{
    public GameObject hint; 
    public KeyCode keyToPress = KeyCode.Escape; 

    void Update()
    {
        if (gameObject.activeSelf)
        {
            Time.timeScale = 0.0f;
        }
        if (gameObject.activeSelf && Input.GetKeyDown(keyToPress))
        {
            
            hint.SetActive(false);
            Time.timeScale = 1.0f;
        }
    }
}