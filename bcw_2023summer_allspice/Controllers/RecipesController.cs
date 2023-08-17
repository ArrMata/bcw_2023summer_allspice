namespace bcw_2023summer_allspice.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RecipesController : ControllerBase
    {
        private readonly RecipesService _recipesService;
        private readonly IngredientsService _ingredientsService;
        private readonly Auth0Provider _auth0Provider;

        public RecipesController(
            RecipesService recipesService, 
            Auth0Provider auth0Provider,
            IngredientsService ingredientsService)
        {
            _recipesService = recipesService;
            _ingredientsService = ingredientsService;
            _auth0Provider = auth0Provider;
        }

        [Authorize]
        [HttpPost]
        public async Task<ActionResult<Recipe>> CreateRecipe([FromBody] Recipe recipeData)
        {
            try
            {
                Account userInfo = await _auth0Provider.GetUserInfoAsync<Account>(HttpContext);
                recipeData.CreatorId = userInfo.Id;
                Recipe createdRecipe = _recipesService.CreateRecipe(recipeData);
                return Ok(createdRecipe);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet]
        public ActionResult<List<Recipe>> GetRecipes()
        {
            try
            {
                List<Recipe> recipes = _recipesService.GetRecipes();
                return Ok(recipes);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("{recipeId}")]
        public ActionResult<Recipe> GetRecipeById(int recipeId)
        {
            try
            {
                Recipe recipe = _recipesService.GetRecipeById(recipeId);
                return Ok(recipe);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [Authorize]
        [HttpPut("{recipeId}")]
        public async Task<ActionResult<Recipe>> EditRecipe ([FromBody] Recipe recipeData, int recipeId)
        {
            try
            {
                Account userInfo = await _auth0Provider.GetUserInfoAsync<Account>(HttpContext);
                Recipe editedRecipe = _recipesService.EditRecipe(recipeData, recipeId, userInfo.Id);
                return Ok(editedRecipe);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [Authorize]
        [HttpDelete("{recipeId}")]
        public async Task<ActionResult<Recipe>> DeleteRecipe (int recipeId)
        {
            try
            {
                Account userInfo = await _auth0Provider.GetUserInfoAsync<Account>(HttpContext);
                _recipesService.DeleteRecipe(recipeId, userInfo.Id);
                return Ok("Recipe Deleted");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("{recipeId}/ingredients")]
        public ActionResult<List<Ingredient>> GetIngredientsByRecipeId (int recipeId)
        {
            try
            {
                List<Ingredient> ingredients = _ingredientsService.GetIngredientsByRecipeId(recipeId);
                return Ok(ingredients);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}