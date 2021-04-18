using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public Spell spell;
    private float lifetime;
    private float spawntime;

    void OnEnable()
    {
        lifetime = spell.range;
        spawntime = Time.time;
    }
    void Update()
    {
        if (lifetime < (Time.time - spawntime))
        {
            aoe();
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        Enemy enemy = hitInfo.GetComponent<Enemy>();
        if(hitInfo.GetComponent<PlayerVitals>() != true)
        {
            if (enemy != null)
            {
                enemy.takeDamage(spell.damage, spell.dmgType);
                aoe();
            }
            Debug.Log(hitInfo.name);
            Destroy(gameObject);
        }
    }

    void aoe()
    {
        Debug.Log("AOE METHOD");
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, spell.AOE);
        foreach (Collider2D c in colliders)
        {
             if(c.GetComponent<Enemy>() != null)
             {
                c.GetComponent<Enemy>().takeDamage(spell.damage, spell.dmgType);
             }        
             if(c.GetComponent<PlayerVitals>() != null && spell.name != "Flamewreathe")
             {
                c.GetComponent<PlayerVitals>().takeDamage(spell.damage);
             }
        }
    }

    
}
