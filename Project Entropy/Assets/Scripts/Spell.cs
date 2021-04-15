using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Spell", menuName = "Spell")]
public class Spell : ScriptableObject {
    public new string name;
    public string description;
    public string dmgType;

    public int id;

    public float damage;
    public float staminaCost;
    public float tempCost;
    public float healthCost;
    public float range;
    public float castTime;
    public float cooldown;
    public float AOE;

    public Object projectile;
}