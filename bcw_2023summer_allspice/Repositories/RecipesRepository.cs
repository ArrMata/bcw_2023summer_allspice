using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bcw_2023summer_allspice.Repositories
{
    public class RecipesRepository
    {
        private IDbConnection _db;
        
        public RecipesRepository(IDbConnection db)
        {
            _db = db;
        }

        internal int CreateRecipe(Recipe recipeData)
        {
            string sql = @"
            INSERT INTO 
            recipes (title, instructions, img, category, creatorId)
            VALUES (@Title, @Instructions, @Img, @Category, @CreatorId);
            SELECT LAST_INSERT_ID()
            ;";
            int recipeId = _db.ExecuteScalar<int>(sql, recipeData);
            return recipeId;
        }

        internal void DeleteRecipe(int recipeId)
        {
            string sql = @"
            DELETE FROM recipes WHERE id = @RecipeId LIMIT 1
            ;";
            _db.Execute(sql, new { recipeId });
        }

        internal void EditRecipe(Recipe editedRecipe)
        {
            string sql = @"
            UPDATE recipes
            SET
            instructions = @Instructions,
            img = @Img,
            title = @Title,
            category = @Category
            WHERE id = @Id
            LIMIT 1
            ;";
            _db.Execute(sql, editedRecipe);
        }

        internal Recipe GetRecipeById(int recipeId)
        {
            string sql = @"
            SELECT 
            recipe.*,
            acc.* 
            FROM recipes recipe 
            JOIN accounts acc ON acc.id = recipe.creatorId
            WHERE recipe.id = @RecipeId LIMIT 1
            ;";
            Recipe foundRecipe = _db.Query<Recipe, Profile, Recipe>(sql, 
            (recipe, profile) => {
                recipe.Creator = profile;
                return recipe;
            },
            new { recipeId }).FirstOrDefault();
            return foundRecipe;
        }

        internal List<Recipe> GetRecipes()
        {
            string sql = @"
            SELECT
            recipe.*,
            acc.*
            FROM recipes recipe
            JOIN accounts acc ON acc.id = recipe.creatorId
            ;";
            List<Recipe> recipes = _db.Query<Recipe, Profile, Recipe>(sql, 
            (recipe, profile) => {
                recipe.Creator = profile;
                return recipe;
            }).ToList();
            return recipes;
        }
    }
}