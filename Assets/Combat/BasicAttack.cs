using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/Combat/Spells/BasicAttack", fileName = "Basic Attack", order = 0)]
public class BasicAttack : Spell
{
    public override void Perform(ref CombatStats caster, ref CombatStats target) {
        target.health -= caster.attack;
    }
}
