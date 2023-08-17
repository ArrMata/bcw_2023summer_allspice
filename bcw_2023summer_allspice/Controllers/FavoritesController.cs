namespace bcw_2023summer_allspice.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FavoritesController : ControllerBase
    {
        private readonly FavoritesService _favoritesService;
        private readonly Auth0Provider _auth0Provider;

        public FavoritesController(FavoritesService favoritesService, Auth0Provider auth0Provider)
        {
            _favoritesService = favoritesService;
            _auth0Provider = auth0Provider;
        }

        [Authorize]
        [HttpPost]
        public async Task<ActionResult<Favorite>> CreateFavorite([FromBody] Favorite favoriteData)
        {
            try
            {
                Account userInfo = await _auth0Provider.GetUserInfoAsync<Account>(HttpContext);
                favoriteData.AccountId = userInfo.Id;
                Favorite createdFavorite = _favoritesService.CreateFavorite(favoriteData);
                return Ok(createdFavorite);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        } 
    }
}