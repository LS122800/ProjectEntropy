using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
    
public class VitalBar : MonoBehaviour
{
    public Slider slider;

    public void setMaxMinFill(float max, float min)
    {
        slider.maxValue = max;
        slider.minValue = min;
        slider.value = max;
    }
    public void setFill(float val)
    {
        slider.value = val;
    }
}