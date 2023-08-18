namespace bcw_2023summer_allspice.Services
{
    public class FavoritesService
    {
        private readonly FavoritesRepository _favoritesRepository;

        public FavoritesService(FavoritesRepository favoritesRepository)
        {
            _favoritesRepository = favoritesRepository;
        }

        internal Favorite CreateFavorite(Favorite favoriteData)
        {
            int favoriteId = _favoritesRepository.CreateFavorite(favoriteData);
            Favorite createdFavorite = GetFavoriteById(favoriteId);
            return createdFavorite;
        }

        internal void DeleteFavorite(string userId, int favoriteId)
        {
            Favorite foundFavorite = GetFavoriteById(favoriteId);
            if (foundFavorite.AccountId != userId)
            {
                throw new Exception($"You can't delete data that isn't yours.");
            }
            _favoritesRepository.DeleteFavorite(favoriteId);
        }

        internal List<FavoriteRecipe> GetAccountFavorites(string userId)
        {
            List<FavoriteRecipe> favorites = _favoritesRepository.GetAccountFavorites(userId);
            return favorites;
        }

        internal Favorite GetFavoriteById(int favoriteId)
        {
            Favorite foundFavorite = _favoritesRepository.GetFavoriteById(favoriteId);
            if (foundFavorite == null)
            {
                throw new Exception($"No favorite found with id of {favoriteId}");
            }
            return foundFavorite;
        }
    }
}