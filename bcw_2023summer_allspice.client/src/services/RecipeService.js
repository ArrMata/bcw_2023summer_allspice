import { AppState } from "../AppState"
import { Recipe } from "../models/Recipe"
import { logger } from "../utils/Logger"
import { api } from "./AxiosService"

class RecipeService {
  async getRecipes() {
    const res = await api.get('api/recipes')
    AppState.recipes = res.data.map(recipePojo => new Recipe(recipePojo))
  }

  selectActiveRecipe(recipeId) {
    AppState.activeRecipe = AppState.recipes.find(recipe => recipe.id == recipeId);
  }
}

export const recipeService = new RecipeService()