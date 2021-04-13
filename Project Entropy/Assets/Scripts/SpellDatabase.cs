using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New SpellDatabase", menuName = "SpellDatabase")]
public class SpellDatabase : ScriptableObject
{
    public List<Spell> allSpells;
}