using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(menuName = "ScriptableObjects/Item", fileName = "Item", order = 0)]
public class Item : ScriptableObject {
    public string itemName;
    public Sprite itemSprite;
}
