using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Adventurer : CharacterBase {
    [SerializeField] private AdventurerClass adventurerClass;
    [SerializeField] private uint level;
    [SerializeField] private uint currentXP;
    
    
    protected override void Awake() {
        characterClass = (CharacterClass) adventurerClass;
        base.Awake();
    }
    
    private void AddXP(uint amount) {
        currentXP += amount;
        if (currentXP >= adventurerClass.XPCurve(level + 1))
            LevelUp();
    }
    
    private void LevelUp() {
        level++;
        UpdateLevel();
    }
    
    private void UpdateLevel() {
        characterClass.baseStats += adventurerClass.scalingStats;
    }
}
