using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OxygenOverlayController : MonoBehaviour
{
    [SerializeField] private float minScale;
    private OxygenTank oxygenTank;


    // Start is called before the first frame update
    void Start()
    {
        oxygenTank = FindObjectOfType<OxygenTank>();

        oxygenTank.oxygenLevelChanged.AddListener(OnOxygenLevelChanged);
    }

    private void OnOxygenLevelChanged()
    {
        float normalisedOxygenLevel = oxygenTank.OxygenLevel / oxygenTank.maxOxygenLevel;
        float clampedOxygenLevel = Mathf.Clamp(normalisedOxygenLevel, 1, minScale);

        transform.localScale = Vector3.one * clampedOxygenLevel;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
