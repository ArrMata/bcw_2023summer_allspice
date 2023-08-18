<template>
  <header>
    <Navbar />
  </header>
  <main>
    <router-view />
  </main>
  <RecipeDetailsModal/>
  <RecipeCreateModal />
</template>

<script>
import { computed } from 'vue'
import { AppState } from './AppState'
import Navbar from './components/Navbar.vue'
import RecipeDetailsModal from './components/RecipeDetailsModal.vue'
import RecipeCreateModal from './components/RecipeCreateModal.vue'

export default {
  setup() {
    return {
      appState: computed(() => AppState)
    }
  },
  components: { Navbar, RecipeDetailsModal, RecipeCreateModal }
}
</script>
<style lang="scss">
@import "./assets/scss/main.scss";
@import url('https://fonts.googleapis.com/css2?family=Crimson+Text:wght@400;700&family=Raleway:wght@300;400;700&display=swap');

body{
  font-family: 'Raleway', sans-serif;
}

</style>
