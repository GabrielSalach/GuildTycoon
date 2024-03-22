using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/AdventurerClass", order = 0)]
public class AdventurerClass : ScriptableObject {
    public string className;
    public string classDescription;
    public CombatStats baseStats;
    
    [HideInInspector]
    public CombatStats scalingStats;
    public float scalingHealth, scalingArmor, scalingMagicResist, scalingAttack, scalingMagicAttack;
    
    private void OnValidate() {
        scalingStats = new CombatStats(scalingHealth, scalingArmor, scalingMagicResist, scalingAttack, scalingMagicAttack);
    }
}
