namespace bcw_2023summer_allspice.Services
{
    public class IngredientsService
    {
        private readonly IngredientsRepository _ingredientsRepository;

        public IngredientsService(IngredientsRepository ingredientsRepository)
        {
            _ingredientsRepository = ingredientsRepository;
        }

        public Ingredient CreateIngredient(Ingredient ingredientData)
        {
            int ingredientId = _ingredientsRepository.CreateIngredient(ingredientData);
            Ingredient newIngredient = GetIngredientById(ingredientId);
            return newIngredient;
        }

        public Ingredient GetIngredientById(int ingredientId)
        {
            Ingredient ingredient = _ingredientsRepository.GetIngredientById(ingredientId);
            if (ingredient == null)
            {
                throw new Exception($"Ingredient with id {ingredientId} does not exist.");
            }
            return ingredient;
        }

        internal void DeleteIngredient(int ingredientId)
        {
            _ingredientsRepository.GetIngredientById(ingredientId);
            _ingredientsRepository.DeleteIngredient(ingredientId);
        }

        internal List<Ingredient> GetIngredientsByRecipeId(int recipeId)
        {
            List<Ingredient> ingredients = _ingredientsRepository.GetIngredientsByRecipeId(recipeId);
            return ingredients;
        }
    }
}