using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class OxygenTank : MonoBehaviour
{
    [SerializeField] public float maxOxygenLevel;
    [SerializeField] private float oxygenReductionSpeed;
    [SerializeField] private float oxygenRenewalSpeed;

    public bool IsReducing { get; set; }
    public bool IsRenewing { get; set; }

    public float OxygenLevel { get; private set; }

    public UnityEvent oxygenLevelChanged;

    void Awake()
    {
        OxygenLevel = maxOxygenLevel;
    }

    void Update()
    {
        if (IsReducing)
            ReduceOxygenLevel(oxygenReductionSpeed * Time.deltaTime);

        if (IsRenewing)
            RenewOxygenLevel(oxygenRenewalSpeed * Time.deltaTime);
    }

    public void ReduceOxygenLevel (float amount)
    {
        OxygenLevel -= amount;

        oxygenLevelChanged.Invoke();
    }

    public void RenewOxygenLevel(float amount)
    {
        OxygenLevel += amount;

        oxygenLevelChanged.Invoke();
    }
}
