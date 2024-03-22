using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/Characters/AdventurerClass", order = 0)]
public class AdventurerClass : CharacterClass {
    public CombatStats scalingStats;
    public List<Spell> spells;
    
    public uint XPCurve(uint level) {
        uint XP = level * 10;
        return XP;
    }
}

