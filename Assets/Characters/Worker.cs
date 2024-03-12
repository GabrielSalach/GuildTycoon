using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Worker : CharacterBase {

    // Assigned workstation position
    [SerializeField] private Transform workstation;
    // Known recipes
    [SerializeField] private List<Recipe> knownRecipes;
    public List<Recipe> KnownRecipes => knownRecipes;
    // Assigned Chest
    [SerializeField] private Chest chest;
    // Amount of seconds it takes to craft a single item
    [SerializeField] private float craftingSpeed;

    protected override void Awake() {
        base.Awake();
        interactable.onClick.AddListener(() => {
            WindowsManager.instance.WorkerWindow.SetWorker(this);
            WindowsManager.instance.WorkerWindow.OpenWindow();
        });
    }

    /// <summary>
    /// Removes the recipe's ingredients from the inventory and sends the worker to its workstation. Once there, calls the Craft() method.
    /// </summary>
    /// <param name="selectedRecipe">Recipe to craft</param>
    public void Work(Recipe selectedRecipe) {
        foreach (ItemSlot item in selectedRecipe.requiredItems) {
            ItemSlot removedItem = chest.Inventory.RemoveItem(item);
            if (removedItem == null) {
                Debug.Log("Not enough materials to craft " + selectedRecipe.result.itemName);
                return;
            }
        }

        GoToDestination(workstation.position);
        onArrivalAtDestination.AddListener(() => {Craft(selectedRecipe);});
    }

    /// <summary>
    /// Starts a timer after which the recipe's result is added to the chest's inventory.
    /// </summary>
    /// <param name="selectedRecipe">Recipe to craft</param>
    private void Craft(Recipe selectedRecipe) {
        Timer timer = new Timer(craftingSpeed, () => {
            //TODO: Replace by toast notification
            Debug.Log("Finished Crafting " + selectedRecipe.result.itemName);
            chest.Inventory.AddItem(selectedRecipe.result, 1);
        });
    }
}
