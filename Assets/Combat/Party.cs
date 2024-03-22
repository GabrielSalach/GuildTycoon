using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Party : List<CharacterBase> {
    private float totalSpeed { get; set; }
    public float averageSpeed { get; private set; }

    public new void Add(CharacterBase character) {
       base.Add(character);
       totalSpeed += character.CurrentCombatStats.speed;
       averageSpeed = totalSpeed / Count;
    }

}
