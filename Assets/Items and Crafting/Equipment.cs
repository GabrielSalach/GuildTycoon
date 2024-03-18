using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "ScriptableObjects/Items/Equipment", fileName = "Equipment", order = 0)]
public class Equipment : Item
{
    public enum EquipmentType {
        Hands, Helmet, Chest, Gloves, Legs, Talisman
    }

    public EquipmentType equipmentType;
    public float bonusHealth, bonusArmor, bonusMagicResist, bonusAttack, bonusMagicAttack;
    [HideInInspector]
    public CombatStats bonusStats;

    [ExecuteInEditMode]
    private void OnValidate() {
        bonusStats = CreateInstance<CombatStats>();
        bonusStats.health = bonusHealth;
        bonusStats.armor = bonusArmor;
        bonusStats.magicResist = bonusMagicResist;
        bonusStats.attack = bonusAttack;
        bonusStats.magicAttack = bonusMagicAttack;
    }
}
