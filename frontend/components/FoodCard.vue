<template>
  <div class="mt-3">
    <b-card
      :title="dish.name"
      :img-src="dish.picture"
      img-alt="PICGTURE"
      img-top
      tag="article"
      style="max-width: 20rem"
      class="mb-2"
    >
      <b-card-text>
        {{dish.description}}
      </b-card-text>
      <b-card-text>
        Cena: {{dish.price}}
      </b-card-text>

      <b-button variant="primary"><NuxtLink :to="`${dish.id}`">Otwórz</NuxtLink></b-button>
      <b-button @click="deleteDish" variant="danger">Usuń</b-button>
    </b-card>
  </div>
</template>

<script>
export default {
  props: ['dish'],
  mounted() {
    console.log(this.dish)
  },
  methods: {
    deleteDish(event) {
      console.log(this.dish.id)
      this.$axios.delete(`https://localhost:7108/api/Dishes/${this.dish.id}`)
      window.location.reload(true) // TODO hot reload instead of a refresh
    }
  }
}
</script>

<style></style>
