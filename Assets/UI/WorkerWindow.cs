using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorkerWindow : Window {
   // UI Elements 
   [SerializeField] private GameObject recipeUI;
   [SerializeField] private Transform recipeRoot;
   [SerializeField] private Worker worker;

   // TODO: Clear the display when reloading window 
   /// <summary>
   /// Sets the worker and loads its known recipes into the window
   /// </summary>
   /// <param name="newWorker">Worker to be loaded</param>
   public void SetWorker(Worker newWorker) {
      worker = newWorker;
      foreach (Recipe recipe in worker.KnownRecipes) {
         // Instantiates a RecipeUI and loads the recipe
         RecipeUI ui = Instantiate(recipeUI, recipeRoot).GetComponent<RecipeUI>();
         ui.LoadRecipe(recipe);
         ui.button.onClick.AddListener(() => {
            CloseWindow();
            worker.Work(recipe);
         });
      }
   }
}
