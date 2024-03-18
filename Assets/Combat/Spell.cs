using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spell : ScriptableObject {
    public string spellName;
    public string spellDescription;
    public uint turnCooldown;

    public virtual void Perform(ref CombatStats caster, ref CombatStats target) {
        
    }
}
