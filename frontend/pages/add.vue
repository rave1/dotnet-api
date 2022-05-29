<template>
  <div>
  <nav-bar/>
  <b-container fluid class="m-0 p-3">
    <add-form />
  </b-container>
  </div>
</template>

<script>
import AddForm from '../components/AddForm.vue'
import NavBar from '../components/NavBar.vue'
export default {
  components: { AddForm, NavBar },

}
</script>

<style>

</style>