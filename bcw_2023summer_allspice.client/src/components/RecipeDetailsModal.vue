<template>
  <div class="modal fade" id="recipeDetailsModal" tabindex="-1" role="dialog" aria-labelledby="modalTitleId" aria-hidden="true">
    <div class="modal-dialog modal-xl" role="document">
      <div class="modal-content">
        <div v-if="recipe" class="modal-body">
          <div class="container-fluid">
            <section class="row">
              <div class="col-5 ps-0">
                <img class="rounded-start" :src="recipe.img" alt="Recipe Picture">
              </div>
              <div class="col-7">
                <div class="d-flex align-items-center py-4 px-2">
                  <h2 class="fs-4 recipe-title mb-0">{{ recipe.title }}</h2>
                  <h3 class="fs-5 ms-2 mb-0 category-label">{{ recipe.category }}</h3>
                  <button type="button" class="btn-close ms-auto" data-bs-dismiss="modal" aria-label="Close"></button>
                </div>
                <section class="row px-2 info-row">
                  <div class="col-6">
                    <div class="info-card">
                      <h3 class="mb-0 green-header">Recipe Instructions</h3>
                      <p class="info-content">{{ recipe.instructions }}</p>
                    </div>
                  </div>
                  <div class="col-6">
                    <div class="info-card">
                      <h3 class="mb-0 green-header">Ingredients</h3>
                      <ul class="info-content">
                        <li :key="ingredient.id" v-for="ingredient in ingredients">
                          {{ ingredient.quantity }} {{ ingredient.name }}
                        </li>
                      </ul>
                    </div>
                  </div>
                </section>
                <div class="d-flex mt-3 px-3">
                  <p class="mb-0 ms-auto">Published by {{ recipe.creator.name }}</p>
                </div>
              </div>
            </section>
          </div>
        </div>
      </div>
    </div>
  </div>  
</template>

<script>
import { computed } from 'vue';
import { AppState } from '../AppState';

export default {
  setup() {
    return {
      recipe: computed(() => AppState.activeRecipe),
      ingredients: computed(() => AppState.activeIngredients)
    }
  }
}
</script>

<style lang="scss" scoped>
@import "../assets/scss/main.scss";

img {
  min-height: 90dvh;
  width: 100%;
  object-fit: cover;
  object-position: center;
}

.category-label {
  @include label;
  margin-right: auto;
  padding: .5rem 1rem;
  border-radius: 5rem;
}

.modal-body {
  padding: 0;
}

.rounded-start {
  border-top-left-radius: 1rem;
  border-bottom-left-radius: 1rem;
}

.recipe-title{
  font-weight: 700;
  color: #219653;
}

.green-header{
  background-color: #219653;
  color: white;
  text-align: center;
  border-top-left-radius: .5rem;
  border-top-right-radius: .5rem;
  padding: .75rem 0;
}

.info-row {
  height: 80%;
}

.info-content {
  flex-grow: 1;
  overflow-y: scroll;
  padding: .5rem;
}

.info-card {
  display: flex;
  flex-direction: column;
  height: 100%;
  box-shadow: 0px 5px 20px rgba(0, 0, 0, 0.296);
  border-radius: 1rem;
}

</style>