<template>
  <div data-bs-toggle="modal" data-bs-target="#recipeDetailsModal" @click="selectActiveRecipe" class="recipe-card" :style="{backgroundImage:`url(${recipe.img})`}">
    <div class="category-label">
      <p class="mb-0">{{ recipe.category }}</p>
    </div>
    <div class="mt-auto title-label">
      <p class="mb-0">{{ recipe.title }}</p>
    </div>
  </div>
</template>

<script>
import { Recipe } from '../models/Recipe';
import { recipeService } from '../services/RecipeService';
import { ingredientsService } from '../services/IngredientsService';
import { logger } from '../utils/Logger';
import Pop from '../utils/Pop';

export default {
  props: {
    recipe: {type: Recipe, required: true}
  },
  setup(props) {
    return {
      selectActiveRecipe: async() => {
        try {
          recipeService.selectActiveRecipe(props.recipe.id)
          await ingredientsService.getIngredientsById(props.recipe.id)
        } catch (error) {
          logger.error(error)
          Pop.error(error.message)
        }
      }
    }
  }
}
</script>

<style lang="scss" scoped>
@import "../assets/scss/main.scss";

.recipe-card{
  margin: 0 auto;
  width: 100%;
  aspect-ratio: 1 / 1;
  background-position: center;
  background-repeat: no-repeat;
  background-size: cover;

  display: flex;
  flex-direction: column;
  padding: 1rem;
  border-radius: 1rem;
  box-shadow: 0 5px 15px rgba(0, 0, 0, 0.322);
  transition: all ease-in-out .2s;
  &:hover{
    cursor: pointer;
    filter: brightness(135%);
    transform: translateY(-10px);
  }
}

.category-label {
  @include label;
  margin-right: auto;
  padding: .5rem 1rem;
  border-radius: 5rem;
}

.title-label {
  @include label;
  padding: .25rem .5rem;
  border-radius: .3rem;
}

</style>