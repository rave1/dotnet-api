<template>
  <b-container fluid class="p-4">
    <!-- <b-row>
            <b-col>
                <b-img thumbnail fluid :src="dish.picture" alt="Image 1"></b-img>
            </b-col>
            <b-col>
                <h1>{{dish.name}}</h1>
                <p>{{dish.description}}</p>
            </b-col>
            
    </b-row> -->
    <b-card
      :img-src="dish.picture"
      img-alt="Card image"
      img-left
      class="mb-3"
      :title="dish.name"
    >
      <b-card-text>
        <b-row>
          <b-col cols="12">
            {{ dish.description }}
          </b-col>
          <b-col> Cena: {{ dish.price }} </b-col>
        </b-row>
        <b-button v-b-modal.modal-1 variant="success">Zmień</b-button>
        <b-button @click="deleteDish" variant="danger">Usuń</b-button>
      </b-card-text>
    </b-card>
    <b-modal id="modal-1" title="Edytuj" hide-footer ref="edit-modal">
      <b-form @submit="onSubmit" @reset="onReset" v-if="show">
        <b-form-group
          id="input-group-1"
          label="Nazwa"
          label-for="input-1"
          description="Nazwa potrawy"
        >
          <b-form-input
            id="input-1"
            v-model="form.name"
            placeholder="Podaj nazwe"
            required
          ></b-form-input>
        </b-form-group>
        <b-form-group
          id="input-group-4"
          label="Opis"
          label-for="input-4"
          description="Opis Potrawy"
        >
          <b-form-input
            id="input-4"
            v-model="form.description"
            placeholder="Podaj Opis"
            required
          ></b-form-input>
        </b-form-group>

        <b-form-group id="input-group-3" label="Cena" label-for="input-3">
          <b-form-input
            id="input-3"
            v-model="form.price"
            type="number"
            placeholder="Podaj cenę"
            step="0.01"
            min="0.00"
            max="1000.00"
            required
          ></b-form-input>
        </b-form-group>

        <b-form-group id="input-group-2" label="Obrazek" label-for="input-2">
          <b-form-input
            id="input-2"
            v-model="form.picture"
            type="url"
            placeholder="Wklej URL do obrazka"
            required
          ></b-form-input>
        </b-form-group>
        <b-button type="submit" variant="primary">Zmień</b-button>
        <b-button type="reset" variant="danger">Reset</b-button>
      </b-form>
    </b-modal>
  </b-container>
</template>

<script>
export default {
  data: () => ({
    dish: {},
    form: {
      name: '',
      price: null,
      description: '',
      picture: '',
    },
    show: true,
  }),
  async fetch() {
    this.dish = await this.$axios
      .get(`https://localhost:7108/api/Dishes/${this.$route.params.id}`)
      .then((res) => (this.dish = res.data))
  },
  fetchOnServer: false,
  fetchKey: 'site-sidebar',
  fetchKey(getCounter) {
    // getCounter is a method that can be called to get the next number in a sequence
    // as part of generating a unique fetchKey.
    return this.someOtherData + getCounter('sidebar')
  },
  async mounted() {
    await this.$axios
      .get(`https://localhost:7108/api/Dishes/${this.$route.params.id}`)
      .then((res) => (this.dish = res.data))
    this.form.name = this.dish.name
    this.form.price = this.dish.price
    this.form.picture = this.dish.picture
    this.form.description = this.dish.description
  },
  methods: {
    async onSubmit(event) {
      event.preventDefault()
      await this.$axios.put(
        `https://localhost:7108/api/Dishes/${this.dish.id}`,
        {
          picture: this.form.picture,
          name: this.form.name,
          price: this.form.price,
          description: this.form.description,
          id: this.dish.id,
        }
      )
      await this.$fetch()
      await this.$refs['edit-modal'].hide()
    },
    onReset(event) {
      event.preventDefault()
      // Reset our form values
      this.form.name = this.dish.name
      this.form.price = this.dish.price
      this.form.picture = this.dish.picture
      this.form.description = this.dish.description
      // Trick to reset/clear native browser form validation state
      this.show = false
      this.$nextTick(() => {
        this.show = true
      })
    },
    deleteDish(event) {
      this.$axios.delete(`https://localhost:7108/api/Dishes/${this.dish.id}`)
      this.$router.push('/')

    }
  },
}
</script>

<style></style>
