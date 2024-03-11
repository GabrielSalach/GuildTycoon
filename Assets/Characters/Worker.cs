using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Worker : CharacterBase {
    [SerializeField] private Transform workstation;
    [SerializeField] private List<Recipe> knownRecipes;
    public List<Recipe> KnownRecipes => knownRecipes;
    [SerializeField] private Chest chest;
    [SerializeField] private float craftingSpeed;

    protected override void Awake() {
        base.Awake();
        interactable.onClick.AddListener(() => {
            WindowsManager.instance.WorkerWindow.SetWorker(this);
            WindowsManager.instance.WorkerWindow.OpenWindow();
        });
    }
    
    public void Work(Recipe selectedRecipe) {
        foreach (ItemSlot item in selectedRecipe.requiredItems) {
            ItemSlot removedItem = chest.Inventory.RemoveItem(item);
            if (removedItem == null) {
                Debug.Log("Not enough materials to craft " + selectedRecipe.result.itemName);
                return;
            }
        }

        GoToDestination(workstation);
        onArrivalAtDestination.AddListener(() => {Craft(selectedRecipe);});
    }

    private void Craft(Recipe selectedRecipe) {
        Timer timer = new Timer(craftingSpeed, () => {
            Debug.Log("Finished Crafting " + selectedRecipe.result.itemName);
            chest.Inventory.AddItem(selectedRecipe.result, 1);
        });
    }
}
