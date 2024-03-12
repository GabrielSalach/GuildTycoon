using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/WorkerClass", fileName = "WorkerClass", order = 0)]
public class WorkerClass : ScriptableObject {
    public string className;
    public List<LeveledRecipe> recipeLevelList;
}
