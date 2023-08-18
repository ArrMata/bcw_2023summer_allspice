namespace bcw_2023summer_allspice.Repositories
{
    public class FavoritesRepository
    {
        private readonly IDbConnection _db;
        public FavoritesRepository(IDbConnection db)
        {
            _db = db;
        }

        internal int CreateFavorite(Favorite favoriteData)
        {
            string sql = @"
            INSERT INTO favorites (accountId, recipeId)
            VALUES (@AccountId, @RecipeId);
            SELECT LAST_INSERT_ID();
            ;";
            int favoriteId = _db.ExecuteScalar<int>(sql, favoriteData);
            return favoriteId;
        }

        internal void DeleteFavorite(int favoriteId)
        {
            string sql = "DELETE FROM favorites WHERE id = @FavoriteId;";
            _db.Execute(sql, new { favoriteId });
        }

        internal List<FavoriteRecipe> GetAccountFavorites(string userId)
        {
            string sql = @"
            SELECT
            fav.*,
            recipe.*,
            acc.*
            FROM favorites fav
            JOIN recipes recipe ON fav.recipeId = recipe.id
            JOIN accounts acc ON acc.id = recipe.creatorId
            WHERE fav.accountId = @UserId
            ;";
            List<FavoriteRecipe> favoriteRecipes = _db.Query<Favorite, FavoriteRecipe, Profile, FavoriteRecipe>(sql, 
            (favorite, favRecipe, profile) => {
                favRecipe.FavoriteId = favorite.Id;
                favRecipe.Creator = profile;
                return favRecipe;
            }, new { userId }).ToList();
            return favoriteRecipes;
        }

        internal Favorite GetFavoriteById(int favoriteId)
        {
            string sql = "SELECT * FROM favorites WHERE id = @FavoriteId;";
            Favorite favorite = _db.QueryFirstOrDefault<Favorite>(sql, new { favoriteId });
            return favorite;
        }
    }
}