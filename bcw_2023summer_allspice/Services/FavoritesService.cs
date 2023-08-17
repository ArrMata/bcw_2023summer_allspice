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

        internal Favorite GetFavoriteById(int favoriteId)
        {
            Favorite foundFavorite = _favoritesRepository.GetFavoriteById(favoriteId);
            return foundFavorite;
        }
    }
}