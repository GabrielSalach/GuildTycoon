using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InventoryWindow : Window
{

    private List<ItemCell> itemCells;
    [SerializeField] private GameObject inventoryContainer;
    [SerializeField] private Inventory defaultInventory;

    protected override void Init() {
        base.Init();

        itemCells = new List<ItemCell>(inventoryContainer.GetComponentsInChildren<ItemCell>());
        LoadInventory(defaultInventory);
        
        
    }
    
    public void OpenWindow(InputAction.CallbackContext context) {
        LoadInventory(defaultInventory);
        OpenWindow();
    }
    
    public void LoadInventory(Inventory inventory) {
        if (inventory.itemSlots.Count > itemCells.Count)
            return;
        for (int i = 0; i < inventory.itemSlots.Count; i++) {
            itemCells[i].SetItem(inventory.itemSlots[i].item, inventory.itemSlots[i].count);
        }
    }
}
