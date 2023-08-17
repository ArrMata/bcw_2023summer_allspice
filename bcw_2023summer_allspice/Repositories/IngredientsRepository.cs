namespace bcw_2023summer_allspice.Repositories
{
    public class IngredientsRepository
    {
        private readonly IDbConnection _db;
        public IngredientsRepository(IDbConnection db)
        {
            _db = db;
        }

        public Ingredient GetIngredientById(int ingredientId)
        {
            string sql = "SELECT * FROM ingredients WHERE id = @IngredientId;";
            Ingredient foundIngredient = _db.QueryFirstOrDefault<Ingredient>(sql, new { ingredientId });
            return foundIngredient;
        }

        public int CreateIngredient(Ingredient ingredientData)
        {
            string sql = @"
            INSERT INTO
            ingredients(name, quantity, recipeId)
            VALUES(@Name, @Quantity, @RecipeId);
            SELECT LAST_INSERT_ID()
            ;";
            int ingredientId = _db.ExecuteScalar<int>(sql, ingredientData);
            return ingredientId;
        }

        internal List<Ingredient> GetIngredientsByRecipeId(int recipeId)
        {
            string sql = @"
            SELECT *
            FROM ingredients
            WHERE recipeId = @RecipeId
            ;";
            List<Ingredient> ingredients = _db.Query<Ingredient>(sql, new { recipeId} ).ToList();
            return ingredients;
        }

        internal void DeleteIngredient(int ingredientId)
        {
            string sql = "DELETE FROM ingredients WHERE id = @IngredientId LIMIT 1;";
            _db.Execute(sql, new { ingredientId });
        }
    }
}