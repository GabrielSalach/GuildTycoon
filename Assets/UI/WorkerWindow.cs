using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorkerWindow : Window {
   [SerializeField] private GameObject recipeUI;
   [SerializeField] private Transform recipeRoot;
   [SerializeField] private Worker worker;

   public void SetWorker(Worker newWorker) {
      worker = newWorker;
      foreach (Recipe recipe in worker.KnownRecipes) {
         RecipeUI ui = Instantiate(recipeUI, recipeRoot).GetComponent<RecipeUI>();
         ui.LoadRecipe(recipe);
         ui.button.onClick.AddListener(() => {
            CloseWindow();
            worker.Work(recipe);
         });
      }
   }
}
