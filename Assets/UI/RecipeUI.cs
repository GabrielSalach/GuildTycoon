using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RecipeUI : MonoBehaviour {
    [SerializeField] private List<ItemCell> ingredientsCells;
    [SerializeField] private ItemCell resultCell;
    public Button button;
    
    public void LoadRecipe(Recipe recipe) {
        if (recipe.requiredItems.Count > 4)
            return;
        for (int i = 0; i < recipe.requiredItems.Count; i++) {
            ingredientsCells[i].SetItem(recipe.requiredItems[i].item, recipe.requiredItems[i].count);
        }

        resultCell.SetItem(recipe.result, 1);
    }
}
