using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour
{
    public Slider tempSlider;
    public float maxTemp;
    public float temp;
    public float tempFallRate;

    private void Start()
    {
        tempSlider.maxValue = maxTemp;
        tempSlider.value = maxTemp;
    }

    void Update()
    {
        if (tempSlider.value >= 0)
        {
            tempSlider.value -= Time.deltaTime / tempFallRate;
            temp -= Time.deltaTime / tempFallRate;
        }
    }

    
}
