using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public Spell spell;
    private float lifetime;
    private float spawntime;
    public ParticleSystem spellParticle;
    public ParticleSystem impactParticle;

    void OnEnable()
    {
        if(spellParticle != null)
        {
            var sParticles = Instantiate(spellParticle, this.transform.position, Quaternion.identity);
            sParticles.transform.parent = gameObject.transform;
            sParticles.Play();
        }
        lifetime = spell.range;
        spawntime = Time.time;
    }
    void Update()
    {
        if (lifetime < (Time.time - spawntime))
        {
            aoe();
            if (impactParticle != null)
            {
                Quaternion rotation = Quaternion.Euler(-90, 0, 0);
                var iParticles = Instantiate(impactParticle, this.transform.position, rotation);
            }
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
            if(impactParticle != null)
            {
                var iParticles = Instantiate(impactParticle, this.transform.position, Quaternion.identity);
            }
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