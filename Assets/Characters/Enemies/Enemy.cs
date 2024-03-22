using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : CharacterBase
{
    [SerializeField] private EnemyClass enemyClass;
    
    protected override void Awake() {
        characterClass = (CharacterClass) enemyClass;
        base.Awake();
    }
}
