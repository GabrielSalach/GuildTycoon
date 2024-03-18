using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(menuName = "ScriptableObjects/Items/Item", fileName = "Item", order = 0)]
public class Item : ScriptableObject {
    public string itemName;
    public Sprite itemSprite;
}
