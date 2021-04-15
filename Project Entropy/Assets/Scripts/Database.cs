using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Database : MonoBehaviour
{
    public SpellDatabase spells;
    private static Database instance;
    void awake()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        } else
        {
            Destroy(gameObject);
        }
    }

    public static Spell getSpellByID(int id)
    {
        foreach(Spell spell in instance.spells.allSpells)
        {
            if(spell.id == id)
            {
                return spell;
            }
        }
        return null;
    }
}
