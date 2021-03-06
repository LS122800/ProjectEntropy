using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float health = 20;
    private float dmgMessage;
    public bool fireResistant = false;
    public bool coldResistant = false;
    public bool lightningResistant = false;
    public bool invulnerable = false;

    private float dmgColorTimer;
    SpriteRenderer enemySprite;

    void Start()
    {
        dmgColorTimer = Time.time;
        enemySprite = this.GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        invulnerable = false;
        if(Time.time - dmgColorTimer > 0.3)
        {
            enemySprite.color = Color.yellow;
        }
    }

    public void takeDamage(float dmg, string dmgType)
    {
        dmgMessage = dmg;
        if (!invulnerable)
        {
            switch (dmgType)
            {
                case "Fire":
                    if (fireResistant)
                    {
                        health -= (dmg / 2);
                        dmgMessage = dmg / 2;
                    }
                    else
                    {
                        health -= dmg;
                    }
                    break;
                case "Cold":
                    if (coldResistant)
                    {
                        health -= (dmg / 2);
                        dmgMessage = dmg / 2;
                    }
                    else
                    {
                        health -= dmg;
                    }
                    break;
                case "Lightning":
                    if (lightningResistant)
                    {
                        health -= (dmg / 2);
                        dmgMessage = dmg / 2;
                    }
                    else
                    {
                        health -= dmg;
                    }
                    break;
                default:
                    health -= dmg;
                    break;
            }
            invulnerable = true;
        }
        
        if(health <= 0)
        {
            die();
        }
        Debug.Log("Target took " + dmgMessage + " " +  dmgType + " damage");
        dmgColorTimer = Time.time;
        enemySprite.color = Color.red;
    }

    void die()
    {
        Destroy(gameObject);
    }
}
