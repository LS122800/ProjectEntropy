using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellHandler : MonoBehaviour
{
    public Spell spell;
    public GameObject player;
    public Transform spawn_pos;
    private Vector2 mouse_pos;
    private float lastCastTime;

    void Update()
    {
        this.transform.position = spawn_pos.transform.position;
        mouse_pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        if (Input.GetButtonDown("Fire1") && (spell.cooldown < Time.time - lastCastTime))
        {
            Cast();
            lastCastTime = Time.time;
        }
    }

    void Cast()
    {
        bool canCast = true;
        if(spell.healthCost > 0)
        {
            if (GameObject.Find("Player").GetComponent<PlayerVitals>().health > 0)
            {
                GameObject.Find("Player").GetComponent<PlayerVitals>().takeDamage(spell.healthCost);
            }
            else
            {
                canCast = false;
            }
        }
        if(spell.tempCost > 0)
        {
            GameObject.Find("Player").GetComponent<PlayerVitals>().changeTemp(spell.tempCost);
        }
        if(spell.staminaCost > 0)
        { 
            if (GameObject.Find("Player").GetComponent<PlayerVitals>().stamina > 0)
            {
                GameObject.Find("Player").GetComponent<PlayerVitals>().changeStamina(spell.staminaCost);
            } else
            {
                canCast = false;
            }
        }
        if(canCast)
        {
            if (spell.name == "Mark")
            {
                player.GetComponent<PlayerMovement>().mark();
            } else if (spell.name == "Recall")
            {
                player.GetComponent<PlayerMovement>().recall();
            } else
            {
                Debug.Log(spell.name);
                Vector2 cast_location = (Vector2)spawn_pos.position;
                Vector2 direction = (mouse_pos - cast_location);
                direction.Normalize();
                GameObject casted = (GameObject)Instantiate(spell.projectile, cast_location, Quaternion.identity);
                casted.GetComponent<Rigidbody2D>().velocity = direction * 30;
            }
        }
    }
}
