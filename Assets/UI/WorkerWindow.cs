using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorkerWindow : Window {
   // UI Elements 
   [SerializeField] private GameObject recipeUI;
   [SerializeField] private Transform recipeRoot;
   [SerializeField] private Worker worker;
   private List<RecipeUI> recipeUIs;
   

   // TODO: Clear the display when reloading window 
   /// <summary>
   /// Sets the worker and loads its known recipes into the window
   /// </summary>
   /// <param name="newWorker">Worker to be loaded</param>
   public void SetWorker(Worker newWorker) {
      worker = newWorker;
      SetTitle(worker.CharacterName);
      // Clears the recipes from the window
      if (recipeUIs == null)
         recipeUIs = new List<RecipeUI>();
      else {
         foreach(RecipeUI rUI in recipeUIs) 
            Destroy(rUI.gameObject);
         recipeUIs.Clear();
      }
      // Instantiates all the recipe UI elements
      foreach (Recipe recipe in worker.KnownRecipes) {
         // Instantiates a RecipeUI and loads the recipe
         RecipeUI ui = Instantiate(recipeUI, recipeRoot).GetComponent<RecipeUI>();
         recipeUIs.Add(ui);
         ui.LoadRecipe(recipe);
         ui.button.onClick.AddListener(() => {
            CloseWindow();
            worker.Work(recipe);
         });
      }
   }
}
