using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class OxygenTank : MonoBehaviour
{
    [SerializeField] public float maxOxygenLevel;
    [SerializeField] private float oxygenReductionSpeed;
    [SerializeField] private float oxygenRenewalSpeed;
    [SerializeField] private ParticleSystem bubbles;
    [SerializeField] private float monsterDamageAmount;

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

        if (amount > 0.5)
            bubbles.Play();
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

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Monster"))
        {
            ReduceOxygenLevel(monsterDamageAmount);
        }
    }
}
