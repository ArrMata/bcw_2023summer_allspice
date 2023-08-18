<template>
  <nav class="navbar navbar-expand-md">
    <div class="container-fluid">
      <button class="navbar-toggler" type="button" data-bs-toggle="collapse" data-bs-target="#navbarToggler">
        <span class="navbar-toggler-icon"></span>
      </button>
      <div class="collapse navbar-collapse" id="navbarToggler">
        <form class="d-flex" role="search">
          <input class="form-control me-2" type="search" placeholder="Search Recipes...">
          <button class="btn btn-outline-primary" type="submit"><i class="mdi mdi-magnify"></i></button>
        </form>
        <Login />
      </div>
    </div>
  </nav>
</template>

<script>
import Login from './Login.vue';
export default {
  setup() {
    return {}
  },
  components: { Login }
}
</script>

<style scoped>

</style>
