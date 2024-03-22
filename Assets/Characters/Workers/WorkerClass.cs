using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/Characters/WorkerClass", fileName = "WorkerClass", order = 0)]
public class WorkerClass : CharacterClass {
    public List<LeveledRecipe> recipeLevelList;
    
    /// <summary>
    /// Used to check which amount of XP the worker needs to have to reach the specified level
    /// </summary>
    /// <param name="level">Level to reach</param>
    /// <returns>Total amount of XP for that level</returns>
    public uint XPCurve(uint level) {
        uint XP = level * 10;
        return XP;
    }
}
