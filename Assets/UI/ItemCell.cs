using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

// Item Cell UI 
public class ItemCell : MonoBehaviour {
    private Item item;
    private uint count;

    // UI Elements
    [SerializeField] private Image itemSprite;
    [SerializeField] private TextMeshProUGUI itemCount;

    /// <summary>
    /// Sets the item displayed, if the item count == 0, disables the item and count rendering.
    /// </summary>
    /// <param name="newItem">Item to be displayed</param>
    /// <param name="newCount">Amount of items</param>
    public void SetItem(Item newItem, uint newCount) {
        item = newItem;
        count = newCount;
        if (newCount == 0) {
            itemSprite.enabled = false;
            itemCount.enabled = false;
            item = null;
            return;
        }
        itemSprite.enabled = true;
        itemCount.enabled = true;
        itemSprite.sprite = newItem.itemSprite;
        itemCount.SetText(newCount.ToString());
    }

    /// <summary>
    /// Sets the item displayed, if the item count == 0, disables the item and count rendering.
    /// </summary>
    /// <param name="newItemSlot">Items to be displayed in form of ItemSlot instance</param>
    public void SetItem(ItemSlot newItemSlot) {
        SetItem(newItemSlot.item, newItemSlot.count);
    }

    // Getters
    public Item GetItem() {
        return item;
    }

    public uint GetCount() {
        return count;
    }
}   
