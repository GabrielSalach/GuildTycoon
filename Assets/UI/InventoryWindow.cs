using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InventoryWindow : Window
{

    // All item cells UI Components
    private List<ItemCell> itemCells;
    // Item cells container transform
    [SerializeField] private GameObject inventoryContainer;
    // Default Inventory to be loaded by the window
    [SerializeField] private Inventory defaultInventory;

    protected override void Init() {
        base.Init();

        // Gets all item cells UI components
        itemCells = new List<ItemCell>(inventoryContainer.GetComponentsInChildren<ItemCell>());
        LoadInventory(defaultInventory);        
    }
    
    /// <summary>
    /// Refreshes the inventory and opens the window. Called when pressing the 'i' key for now 
    /// </summary>
    public void OpenWindow(InputAction.CallbackContext context) {
        LoadInventory(defaultInventory);
        OpenWindow();
    }
    
    /// <summary>
    /// Loads an inventory and displays it in the window. 
    /// </summary>
    /// <param name="inventory">Inventory to load</param>
    public void LoadInventory(Inventory inventory) {
        if (inventory.itemSlots.Count > itemCells.Count)
            return;
        for (int i = 0; i < inventory.itemSlots.Count; i++) {
            itemCells[i].SetItem(inventory.itemSlots[i].item, inventory.itemSlots[i].count);
        }
    }
}
