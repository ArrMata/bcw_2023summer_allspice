<template>
  <!-- Modal -->
  <div class="modal fade" id="createRecipeModal" tabindex="-1" role="dialog" aria-labelledby="modalTitleId" aria-hidden="true">
    <div class="modal-dialog modal-lg" role="document">
      <div class="modal-content">
          <div class="modal-header">
            <h5 class="modal-title" id="modalTitleId">New Recipe</h5>
            <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
          </div>
        <div class="modal-body">
          <div class="container-fluid">
            <form @submit.prevent="">
              <div class="d-flex">
                <div class="mb-3 flex-grow-1 px-2">
                  <label for="title" class="form-label">Title</label>
                  <input type="text" class="form-control" id="title" aria-describedby="helpId" placeholder="Title...">
                </div>
                <div class="mb-3 flex-grow-1 px-2">
                  <label for="category" class="form-label">Category</label>
                  <input type="text" class="form-control" id="category" aria-describedby="helpId" placeholder="Title...">
                </div>
              </div>
            </form>
          </div>
        </div>
        <div class="modal-footer">
          <button type="button" class="btn btn-secondary" data-bs-dismiss="modal">Close</button>
          <button type="submit" class="btn btn-primary">Submit</button>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
export default {
  setup() {
    

    return {}
  }
}
</script>

<style lang="scss" scoped>

</style>