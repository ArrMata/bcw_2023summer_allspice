import { AppState } from "../AppState"
import { Ingredient } from "../models/Ingredient"
import { logger } from "../utils/Logger"
import { api } from "./AxiosService"

class IngredientsService {

  async getIngredientsById(recipeId) {
    const res = await api.get(`api/recipes/${recipeId}/ingredients`)
    AppState.activeIngredients = res.data.map(ingredientPojo => new Ingredient(ingredientPojo))
  }
}

export const ingredientsService = new IngredientsService()