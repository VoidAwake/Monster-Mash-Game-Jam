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
    public UnityEvent playerDeath;

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

        if (OxygenLevel <= 0)
        {
            playerDeath.Invoke();
        }
    }

    public void ReduceOxygenLevel (float amount)
    {
        OxygenLevel -= amount;

        if (OxygenLevel < 0)
        {
            OxygenLevel = 0;
        }

        oxygenLevelChanged.Invoke();
    }

    public void RenewOxygenLevel(float amount)
    {
        OxygenLevel += amount;

        if (OxygenLevel > maxOxygenLevel)
        {
            OxygenLevel = maxOxygenLevel;
        }

        oxygenLevelChanged.Invoke();
    }
}
