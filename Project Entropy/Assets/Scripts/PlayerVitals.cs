using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerVitals : MonoBehaviour
{
    public GameObject gameOverUI;
    public float maxHealth = 100f;
    public float health;
    public float maxStamina = 100f;
    public float stamina;
    public float maxTemperature = 98.6f;
    public float temperature;

    public bool invulnerable = false;

    public VitalBar healthbar;
    public VitalBar staminabar;
    public VitalBar tempbar;

    public Temperature ambientTemperature;

    private float dmgColorTimer;
    private float ambientTimer;
    private float staminaRechargeTimer;
    private float tempDamageTimer;
    private float tempDamage;

    SpriteRenderer playerSprite;

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
        dmgColorTimer = Time.time;

        playerSprite = this.GetComponent<SpriteRenderer>();
        playerSprite.color = Color.red;
    }

    void Update()
    {
        if (Time.time - staminaRechargeTimer > 2 && stamina < maxStamina)
        {
            changeStamina(-1);
            staminaRechargeTimer = Time.time;
        }

        if(Time.time - tempDamageTimer > 20 && temperature < 78)
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

        if(Time.time - dmgColorTimer > 0.3)
        {
            playerSprite.color = Color.white;
        }
        if(Time.time - ambientTimer > 20)
        {
            ambientTimer = Time.time;
            AmbientTempFormula(ambientTemperature.currentTemperature);   
        }



    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "campfire_prefab")
        {
            changeTemp(-1);
        }
    }

    public void takeDamage(float damage)
    {
        if(!invulnerable)
        {
            playerSprite.color = Color.red;
            dmgColorTimer = Time.time;
            health -= damage;
            healthbar.setFill(health);
            if (health < 0)
            {
                die();
            }
        }
    }

    public void setVulnerable()
    {
        invulnerable = false;
    }

    public void setInvulnerable()
    {
        invulnerable = true;
    }

    public void changeTemp(float tempChange)
    {
        temperature -= tempChange;
        tempbar.setFill(temperature);
    }
    
    public float getTemp()
    {
        return temperature;
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
        gameOverUI.SetActive(true);
        Time.timeScale = 0f;
        //Destroy(gameObject);
    }

    void AmbientTempFormula(double temp)
    {
        float change = (float)(0.009 * (temperature - temp));
        changeTemp(change);
    }
}