using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "ScriptableObjects/Recipe", order = 0)]
public class Recipe : ScriptableObject {
    public List<ItemSlot> requiredItems;
    public Item result;
    public uint rewardXP;
}
