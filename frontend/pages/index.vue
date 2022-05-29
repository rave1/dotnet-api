<template>
  <b-container fluid class="m-0 p-0">
    <nav-bar />
    <carousel />
    <b-container>
    <b-row class="px-4" align-v="center" align-h="center">
      <b-col cols="3" class="e" v-for="dish in dishes" :key="dish.id">
      <food-card
        :dish="dish"
      />
      </b-col>
    </b-row>
    </b-container>
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
      console.log(this.dishes)
  },
}
</script>
