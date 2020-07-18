using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Character.CharacterProperties;
using Character.CharacterModifiers;
using GameConfig;
using Character;

public class CharacterPropertiesController : MonoBehaviour
{
    public CharacterProperty healthAmount = new CharacterProperty(
        type: CharacterPropertyType.HealthAmount,
        baseAmount: 100
    );

    public CharacterProperty healthMaximumAmount = new CharacterProperty(
        type: CharacterPropertyType.HealthMaximumAmount,
        baseAmount: 100
    );

    public CharacterProperty healthRegenerationAmount = new CharacterProperty(
        type: CharacterPropertyType.HealthRegeneratonAmount,
        baseAmount: 1
    );

    public CharacterProperty healthRegenerationRate = new CharacterProperty(
        type: CharacterPropertyType.HealthRegenerationRate,
        baseAmount: 1
    );

    public CharacterProperty energyAmount = new CharacterProperty(
        type: CharacterPropertyType.EnergyAmount,
        baseAmount: 100
    );

    public CharacterProperty energyRechargeAmount = new CharacterProperty(
        type: CharacterPropertyType.EnergyRechargeAmount,
        baseAmount: 1
    );

    public CharacterProperty energyRechargeRate = new CharacterProperty(
        type: CharacterPropertyType.EnergyRechargeRate,
        baseAmount: 2
    );

    public CharacterProperty energyDecayAmount = new CharacterProperty(
        type: CharacterPropertyType.EnergyDecayAmount,
        baseAmount: 1
    );

    public CharacterProperty energyDecayRate = new CharacterProperty(
        type: CharacterPropertyType.EnergyDecayRate,
        baseAmount: 1
    );

    public CharacterProperty energyRetentionAmount = new CharacterProperty(
        type: CharacterPropertyType.EnergyRetentionAmount,
        baseAmount: 50
    );

    public CharacterProperty staminaAmount = new CharacterProperty(
        type: CharacterPropertyType.StaminaAmount,
        baseAmount: 0
    );

    public CharacterProperty staminaMaximumAmount = new CharacterProperty(
        type: CharacterPropertyType.StaminaMaximumAmount,
        baseAmount: 3
    );

    public CharacterProperty staminaRegenerationAmount = new CharacterProperty(
        type: CharacterPropertyType.StaminaRegenerationAmount,
        baseAmount: 0.25f
    );

    public CharacterProperty staminaRegenerationRate = new CharacterProperty(
        type: CharacterPropertyType.StaminaRegenerationRate,
        baseAmount: 1
    );

    public CharacterProperty armourAmount = new CharacterProperty(
        type: CharacterPropertyType.ArmourAmount,
        baseAmount: 0
    );

    public CharacterProperty fireResistance = new CharacterProperty(
        type: CharacterPropertyType.FireResistance,
        baseAmount: 0
    );

    public CharacterProperty coldResistance = new CharacterProperty(
        type: CharacterPropertyType.ColdResistance,
        baseAmount: 0
    );

    public CharacterProperty lightingResistance = new CharacterProperty(
        type: CharacterPropertyType.LightingResistance,
        baseAmount: 0
    );

    public CharacterProperty deliriumResistance = new CharacterProperty(
        type: CharacterPropertyType.DeliriumResistance,
        baseAmount: 0
    );

    void Start()
    {
        List<IEnumerator> coroutines = new List<IEnumerator>()
        {
            HealthCoroutine(),
            EnergyCoroutine(),
            StaminaCoroutine()
        };

        foreach(var item in coroutines)
        {
            StartCoroutine(item);
        }
    }

    IEnumerator HealthCoroutine()
    {
        while (true)
        {
            if (healthAmount.Amount <= healthMaximumAmount.Amount)
            {
                healthAmount.Amount += (healthRegenerationAmount.Amount * healthRegenerationRate.Amount) * CoroutineConfig.COROUTINE_TICK_RATE;
            }
            yield return new WaitForSeconds(CoroutineConfig.COROUTINE_TICK_RATE);
        }
    }

    IEnumerator EnergyCoroutine()
    {
        while (true)
        {
            float calculatedEnergyDecay = 0;
            
            energyAmount.Amount += energyRechargeAmount.Amount * energyRechargeRate.Amount * CoroutineConfig.COROUTINE_TICK_RATE;

            if (energyAmount.Amount <= energyRetentionAmount.Amount)
            {
                calculatedEnergyDecay = (energyDecayAmount.Amount * energyDecayRate.Amount);
            } else
            {
                calculatedEnergyDecay = ((0.05f * 
                    (energyAmount.Amount - energyRetentionAmount.Amount) + energyDecayAmount.Amount) * energyDecayRate.Amount);
            }

            energyAmount.Amount += -calculatedEnergyDecay * CoroutineConfig.COROUTINE_TICK_RATE;

            yield return new WaitForSeconds(CoroutineConfig.COROUTINE_TICK_RATE);
        }
    }

    IEnumerator StaminaCoroutine()
    {
        while (true)
        {
            Debug.Log("Stamina: " + staminaAmount.Amount.ToString());
            if (staminaAmount.Amount <= staminaMaximumAmount.Amount)
            {
                staminaAmount.Amount += (staminaRegenerationAmount.Amount * staminaRegenerationRate.Amount) * CoroutineConfig.COROUTINE_TICK_RATE;
            }
            yield return new WaitForSeconds(CoroutineConfig.COROUTINE_TICK_RATE);
        }
    }
}
