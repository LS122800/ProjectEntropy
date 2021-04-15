using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerVitals : MonoBehaviour
{
    public float maxHealth = 100f;
    public float health;
    public float maxStamina = 100f;
    public float stamina;
    public float maxTemperature = 98.6f;
    public float temperature;

    public VitalBar healthbar;
    public VitalBar staminabar;
    public VitalBar tempbar;

    public Temperature ambientTemperature;

    private float ambientTimer;
    private float staminaRechargeTimer;
    private float tempDamageTimer;
    private float tempDamage;

    void Start()
    {
        health = maxHealth;
        stamina = maxStamina;
        temperature = maxTemperature;
        healthbar.setMaxMinFill(maxHealth, 0);
        staminabar.setMaxMinFill(maxStamina, 0);
        tempbar.setMaxMinFill(maxTemperature, 55);
        staminaRechargeTimer = Time.time;
        tempDamageTimer = Time.time;
        ambientTimer = Time.time;
    }

    void Update()
    {
        if (Time.time - staminaRechargeTimer > 2 && stamina < maxStamina)
        {
            changeStamina(-1);
            staminaRechargeTimer = Time.time;
        }

        if(Time.time - tempDamageTimer > 2 && temperature < 78)
        {
            if(temperature <= 55)
            {
                die();
            } else
            {
                tempDamage = (10 / (temperature - 55));
                takeDamage(tempDamage);
                tempDamageTimer = Time.time;
            }
        }

        if(Time.time - ambientTimer > 2)
        {
            ambientTimer = Time.time;
            testAmbientTempFormula(ambientTemperature.currentTemperature);   
        }
    }

    public void takeDamage(float damage)
    {
        health -= damage;
        healthbar.setFill(health);
        if (health < 0)
        {
            die();
        }
    }

    public void changeTemp(float tempChange)
    {
        temperature -= tempChange;
        tempbar.setFill(temperature);
    }
    
    public void changeStamina(float staminaChange)
    {
        stamina -= staminaChange;
        if (stamina < 0)
        {
            stamina = 0;
        }
        staminabar.setFill(stamina);
    }

    void die()
    {
        Destroy(gameObject);
    }

    void testAmbientTempFormula(double testTemperature)
    {
        float change = (float)(0.009 * (temperature - testTemperature));
        changeTemp(change);

    }
}