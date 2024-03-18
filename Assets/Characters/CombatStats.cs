using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName="ScriptableObjects/CombatStats", fileName = "Combat Stats", order = 0)]
[System.Serializable]
public class CombatStats : ScriptableObject {
    public float health, armor, magicResist, attack, magicAttack;

    /// <summary>
    /// Creates a new CombatStats instance and clones the values from this one.
    /// </summary>
    /// <returns>The cloned CombatStats instance</returns>
    public CombatStats CloneStats() {
        CombatStats returnValue = (CombatStats) CreateInstance(typeof(CombatStats));
        returnValue.health = health;
        returnValue.armor = armor;
        returnValue.magicResist = magicResist;
        returnValue.attack = attack;
        returnValue.magicAttack = magicAttack;
        
        return returnValue;
    }
    
    public static CombatStats operator +(CombatStats a, CombatStats b) {
        CombatStats newStats = CreateInstance<CombatStats>();
        newStats.health = a.health + b.health;
        newStats.armor = a.armor + b.armor;
        newStats.magicResist = a.magicResist + b.magicResist;
        newStats.attack = a.attack + b.attack;
        newStats.magicAttack = a.magicAttack + b.magicAttack;
        return newStats;
    }

    public override string ToString() {
        return "Health : " + health + ", Armor : " + armor + ", Magic Resist : " + magicResist + ", Attack : " + attack +
               ", Magic Attack : " + magicAttack;
    }
}
