using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OxygenMeter : MonoBehaviour
{
    private Slider slider;
    private OxygenTank oxygenTank;

    private void Awake()
    {
        slider = GetComponent<Slider>();
    }

    private void Start()
    {
        oxygenTank = FindObjectOfType<OxygenTank>();

        oxygenTank.oxygenLevelChanged.AddListener(OnOxygenLevelChanged);

        OnOxygenLevelChanged();
    }

    private void OnOxygenLevelChanged()
    {
        UpdateOxygen(oxygenTank.OxygenLevel / oxygenTank.maxOxygenLevel * 100);
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
