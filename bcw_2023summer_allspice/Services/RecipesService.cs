using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bcw_2023summer_allspice.Services
{
    public class RecipesService
    {
        private readonly RecipesRepository _recipesRepository;

        public RecipesService(RecipesRepository recipesRepository)
        {
            _recipesRepository = recipesRepository;
        }

        public Recipe CreateRecipe(Recipe recipeData)
        {
            int recipeId = _recipesRepository.CreateRecipe(recipeData);
            Recipe createdRecipe = GetRecipeById(recipeId);
            return createdRecipe;
        }

        public Recipe GetRecipeById(int recipeId)
        {
            Recipe foundRecipe = _recipesRepository.GetRecipeById(recipeId);
            if (foundRecipe == null)
            {
                throw new Exception($"No recipe found with id: {recipeId}");
            }
            return foundRecipe;
        }

        internal void DeleteRecipe(int recipeId, string userId)
        {
            Recipe foundRecipe = _recipesRepository.GetRecipeById(recipeId);
            if (foundRecipe.CreatorId != userId)
            {
                throw new Exception("You can't delete data that isn't yours.");
            }
            _recipesRepository.DeleteRecipe(recipeId);
        }

        internal Recipe EditRecipe(Recipe recipeData, int recipeId, string userId)
        {
            Recipe originalRecipe = GetRecipeById(recipeId);
            if (originalRecipe.CreatorId != userId)
            {
                throw new Exception("You can't edit data that isn't yours.");
            }
            originalRecipe.Category = recipeData.Category ?? originalRecipe.Category;
            originalRecipe.Title = recipeData.Title ?? originalRecipe.Title;
            originalRecipe.Instructions = recipeData.Instructions ?? originalRecipe.Instructions;
            originalRecipe.Img = recipeData.Img ?? originalRecipe.Img;
            _recipesRepository.EditRecipe(originalRecipe);
            Recipe updatedRecipe = GetRecipeById(recipeId);
            return updatedRecipe;
        }

        internal List<Recipe> GetRecipes()
        {
            List<Recipe> recipes = _recipesRepository.GetRecipes();
            return recipes;
        }
    }
}