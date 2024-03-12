using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Scriptable Object for inventories, need to rework that in a proper class soon
[CreateAssetMenu(menuName = "ScriptableObjects/Inventory", fileName = "Inventory", order = 0)]
public class Inventory : ScriptableObject {
    // List of item slots (Item + Count)
    public List<ItemSlot> itemSlots;

    /// <summary>
    /// Adds an item to the Inventory, if the item already exists, only increases the count value.
    /// </summary>
    /// <param name="item">Item to add</param>
    /// <param name="quantity">Amount of items to add</param>
    public void AddItem(Item item, uint quantity) {
        bool found = false;
        int i = 0;
        while (found == false && i < itemSlots.Count) {
            if (itemSlots[i].item == item) {
                itemSlots[i].count += quantity;
                found = true;
            }
            i++;
        }

        if (found == true)
            return;
        itemSlots.Add(new ItemSlot(item, quantity));
    }

    /// <summary>
    /// Removes an item from the inventory
    /// </summary>
    /// <param name="item">Item to remove</param>
    /// <param name="quantity">Amount of items to remove</param>
    /// <returns>The item and amount removed, or null if there's not enough items</returns>
    public ItemSlot RemoveItem(Item item, uint quantity) {
        ItemSlot returnValue = null;
        foreach (ItemSlot slot in itemSlots) {
            if (slot.item == item && slot.count >= quantity) {
                returnValue = slot;
                slot.count -= quantity;
            }
        }
        return returnValue;
    }

    /// <summary>
    /// Removes an item from the inventory
    /// </summary>
    /// <param name="itemSlot">Items to remove in the form of an ItemSlot instance</param>
    /// <returns>The item and amount removed, or null if there's not enough items</returns>
    public ItemSlot RemoveItem(ItemSlot itemSlot) {
        ItemSlot returnValue = RemoveItem(itemSlot.item, itemSlot.count);
        return returnValue;
    }
}
