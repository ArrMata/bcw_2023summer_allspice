namespace bcw_2023summer_allspice.Repositories
{
    public class FavoritesRepository
    {
        private readonly IDbConnection _db;
        public FavoritesRepository(IDbConnection db)
        {
            _db = db;
        }

        internal Favorite GetFavoriteById(int favoriteId)
        {
            string sql = "SELECT * FROM favorites WHERE id = @FavoriteId;";
            Favorite favorite = _db.QueryFirstOrDefault<Favorite>(sql, new { favoriteId });
            return favorite;
        }
    }
}