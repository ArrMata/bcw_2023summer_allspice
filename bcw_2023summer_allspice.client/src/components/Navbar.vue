<template>
  <nav style="background-image: url(https://images.unsplash.com/photo-1507048331197-7d4ac70811cf?ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D&auto=format&fit=crop&w=1074&q=80);" class="navbar navbar-expand-md">
    <div class="container-fluid h-100">
      <button class="navbar-toggler" type="button" data-bs-toggle="collapse" data-bs-target="#navbarToggler">
        <span class="navbar-toggler-icon"></span>
      </button>
      <div class="collapse navbar-collapse h-100" id="navbarToggler">
        <div class="d-flex ms-auto">
          <form @submit.prevent="" class="d-flex my-2 me-2" role="search">
            <input class="form-control" type="search" placeholder="Search Recipes...">
            <button class="btn btn-primary" type="submit"><i class="mdi mdi-magnify"></i></button>
          </form>
          <Login />
        </div>
        <div class="mt-5 text-center hero-text">
          <h1>All-Spice</h1>
          <h4>Cherish Your Family</h4>
          <h4>And Their Cooking</h4>
        </div>
      </div>
    </div>
    <div class="d-flex nav-links">
      <button type="button" class="nav-button rounded-start">Home</button>
      <button type="button" class="nav-button">My Recipes</button>
      <button type="button" class="nav-button rounded-end">Favorites</button>
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

nav{
  height: 350px;
  background-size: cover;
  background-repeat: no-repeat;
  background-position: center;
  margin: 1.5rem;
  border-radius: 1rem;
  box-shadow: 0px 5px 15px black;
  position: relative;
}

#navbarToggler {
  flex-direction: column;
}

.nav-links{
  position: absolute;
  bottom: -30px;
  left: 50%;
  transform: translateX(-50%);
  height: 75px;
  border-radius: 1rem;
  box-shadow: 0 5px 15px rgba(0, 0, 0, 0.459);
}

.nav-button {
  font-family: 'Crimson Text', serif;
  height: 100%;
  background-color: white;
  color: #219653;
  border: none;
  padding: 0 3.5rem;
  transition: all ease-in-out 0.25s;
  font-size: 1.5rem;
}

.rounded-start {
  border-top-left-radius: 1rem;
  border-bottom-left-radius: 1rem;
}
.rounded-end {
  border-top-right-radius: 1rem;
  border-bottom-right-radius: 1rem;
}

.nav-button:hover{
  color: white;
  background-color: #219653;
}

.hero-text{
  font-family: 'Crimson Text', serif;
  color: white;
  text-shadow: 0 0 7px black;
}

</style>
