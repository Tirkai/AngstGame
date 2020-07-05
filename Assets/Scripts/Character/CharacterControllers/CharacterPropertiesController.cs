using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Character.CharacterProperties;
using Character.CharacterModifiers;

public class CharacterPropertiesController : MonoBehaviour
{
    public bool isAlive = true;

    public CharacterProperty healthAmount = new CharacterProperty(
        type: CharacterPropertyType.HealthAmount,
        baseAmount: 25
    );

    public CharacterProperty healthMaximum = new CharacterProperty(
        type: CharacterPropertyType.HealthMaximumAmount,
        baseAmount: 100
    );

    public CharacterProperty healthRegeneration = new CharacterProperty(
        type: CharacterPropertyType.HealthRegeneratonAmount,
        baseAmount: 1
    );

    public CharacterProperty healthRegenerationRate = new CharacterProperty(
        type: CharacterPropertyType.HealthRegenerationRate,
        baseAmount: 1
    );

    void Start()
    {
        healthAmount.MaxAmount = healthMaximum.Amount;
        StartCoroutine(HealthCoroutine());       
    }

    IEnumerator HealthCoroutine()
    {
        while (true)
        {
            Debug.Log(healthAmount.Amount + "/" + healthMaximum.Amount);

            if (isAlive)
            {
                healthAmount.MaxAmount = healthMaximum.Amount;

                if (healthAmount.Amount <= healthMaximum.Amount)
                {
                    healthAmount.Amount += (healthRegeneration.Amount * healthRegenerationRate.Amount * 0.1f);

                }

                yield return new WaitForSeconds(0.1f);
            }
        }
    }

}
