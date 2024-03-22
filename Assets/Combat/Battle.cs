using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Battle {
    private float turnDuration = 5;
    private Party playerParty;
    private Party enemyParty;
    private List<CharacterBase> turnOrder;

    public Battle(List<Adventurer> playerParty, List<Enemy> enemyParty) {
        turnOrder = new List<CharacterBase>();
        this.playerParty = new Party();
        foreach (Adventurer adventurer in playerParty) {
            this.playerParty.Add(adventurer);
            turnOrder.Add(adventurer);
        }
        this.enemyParty = new Party();
        foreach (Enemy enemy in enemyParty) {
            this.enemyParty.Add(enemy);
            turnOrder.Add(enemy);
        }
        
    }
    
    private void Sort() {
        turnOrder.Sort((c1, c2) => c1.CurrentCombatStats.speed.CompareTo(c2.CurrentCombatStats.speed));
        turnOrder.Reverse();
    }
   
    
}
