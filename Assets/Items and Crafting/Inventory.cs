using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/Inventory", fileName = "Inventory", order = 0)]
public class Inventory : ScriptableObject {
    public List<ItemSlot> itemSlots;

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

    public ItemSlot RemoveItem(Item item, uint quantity) {
        ItemSlot returnValue = null;
        foreach (ItemSlot slot in itemSlots) {
            if (slot.item == item == slot.count >= quantity) {
                returnValue = slot;
                slot.count -= quantity;
            }
        }
        return returnValue;
    }

    public ItemSlot RemoveItem(ItemSlot itemSlot) {
        ItemSlot returnValue = RemoveItem(itemSlot.item, itemSlot.count);
        return returnValue;
    }
}
