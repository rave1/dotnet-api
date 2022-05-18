<template>
  <b-container fluid class="m-0 p-0">
    <nav-bar />
    <carousel />
    <b-row class="px-4">
      <food-card
        v-for="{ id, name, price, description, picture } in dishes"
        :key="id"
      />
    </b-row>
  </b-container>
</template>

<script>
import Carousel from '../components/Carousel.vue'
import FoodCard from '../components/FoodCard.vue'
import NavBar from '../components/NavBar.vue'
export default {
  components: { Carousel, NavBar, FoodCard },
  name: 'IndexPage',
  data: () => ({
    dishes: [],
  }),
  mounted() {
    this.$axios
      .get('https://localhost:7108/api/Dishes/')
      .then((res) => (this.dishes = res.data))
  },
}
</script>
