<template>
  <div class="container-fluid">
    <section class="row pt-4 px-3">
      <div v-for="recipe in recipes" :key="recipe.id" class="col-md-3 col-12 px-3 py-3">
        <RecipeCard :recipe="recipe"/>
      </div>
    </section>
  </div>
  <button id="addRecipeButton">
    <i class="mdi mdi-plus-thick" data-bs-toggle="modal" data-bs-target="#createRecipeModal"></i>
  </button>
</template>

<script>
import { computed, onMounted } from 'vue'
import { recipeService } from '../services/RecipeService.js'
import { AppState } from '../AppState'
import { logger } from '../utils/Logger'
import Pop from '../utils/Pop'
import RecipeCard from '../components/RecipeCard.vue'
export default {
    setup() {
        const getRecipes = async() => {
            try {
                recipeService.getRecipes();
            }
            catch (error) {
                Pop.error(error.message);
                logger.log(error);
            }
        };
        onMounted(() => {
            getRecipes();
        });
        return {
            recipes: computed(() => AppState.recipes)
        };
    },
    components: { RecipeCard }
}
</script>

<style scoped lang="scss">

#addRecipeButton {
  position: fixed;
  bottom: 3rem;
  right: 3rem;
  font-size: 3rem;
  border: none;
  color: white;
  background-color: #219653;
  border-radius: 50%;
  height: 5rem;
  width: 5rem;
  text-align: center;
  box-shadow: 0 5px 20px rgba(0, 0, 0, 0.467);
  transition: all .2s ease-in-out;
  &:hover {
    background-color: #2ed476;
  }
}

</style>
