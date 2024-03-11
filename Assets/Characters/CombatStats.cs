using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName="ScriptableObjects/CombatStats", fileName = "Combat Stats", order = 0)]
public class CombatStats : ScriptableObject {
    public float health, armor, magicResist, attack, magicAttack;

    public CombatStats CloneStats() {
        CombatStats returnValue = (CombatStats) CreateInstance(typeof(CombatStats));
        returnValue.health = health;
        returnValue.armor = armor;
        returnValue.magicResist = magicResist;
        returnValue.attack = attack;
        returnValue.magicAttack = magicAttack;
        
        return returnValue;
    }
}
