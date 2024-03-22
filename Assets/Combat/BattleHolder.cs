using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class BattleHolder : MonoBehaviour {
    public List<Adventurer> adventurers;
    public List<Enemy> enemies;
    private Battle battle;
    void Start() {
        battle = new Battle(adventurers, enemies);
    }

    
}
