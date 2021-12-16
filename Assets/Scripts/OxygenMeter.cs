using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OxygenMeter : MonoBehaviour
{
    private Slider slider;

    private void Awake()
    {
        slider = GetComponent<Slider>();
    }

    public void UpdateOxygen(float value)
    {
        //TODO: Lerp the change 
        slider.value = value;
    }

    [ContextMenu("UpdateTest")]
    public void TestOxy()
    {
        UpdateOxygen(80f);
    }
}
