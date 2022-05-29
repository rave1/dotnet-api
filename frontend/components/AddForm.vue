<template>
  <div>
    <b-form @submit="onSubmit" @reset="onReset" v-if="show">
      <b-form-group
        id="input-group-1"
        label="name"
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

      <b-form-group id="input-group-3" label="Price:" label-for="input-3">
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

          <b-form-group id="input-group-2" label="Obrazek:" label-for="input-2">
        <b-form-input
          id="input-2"
          v-model="form.picture"
          type="url"
          placeholder="Wklej URL do obrazka"
          required
        ></b-form-input>
      </b-form-group>


          <!-- Styled -->
    <!-- <b-form-file
      v-model="form.file1"
      :state="Boolean(form.file1)"
      placeholder="Choose a file or drop it here..."
      drop-placeholder="Drop file here..."
    ></b-form-file>
    <div class="mt-3">Selected file: {{ file1 ? file1.name : '' }}</div> -->

      <b-form-group id="input-group-4" v-slot="{ ariaDescribedby }">
        <b-form-checkbox-group
          v-model="form.checked"
          id="checkboxes-4"
          :aria-describedby="ariaDescribedby"
        >
          <b-form-checkbox value="me">Check me out</b-form-checkbox>
          <b-form-checkbox value="that">Check that out</b-form-checkbox>
        </b-form-checkbox-group>
      </b-form-group>

      <b-button type="submit" variant="primary">Submit</b-button>
      <b-button type="reset" variant="danger">Reset</b-button>
    </b-form>
    <b-card class="mt-3" header="Form Data Result">
      <pre class="m-0">{{ form }}</pre>
    </b-card>
  </div>
</template>

<script>
  export default {
    data() {
      return {
        form: {
          name: '',
          price: null,
          description: '',
        },
        // foods: [{ text: 'Select One', value: null }, 'Carrots', 'Beans', 'Tomatoes', 'Corn'],
        show: true
      }
    },
    methods: {
      async onSubmit(event) {
        event.preventDefault()

        await this.$axios.post('https://localhost:7108/api/Dishes', {
            'picture': this.form.picture,
            'name': this.form.name,
            'price': this.form.price
        })
        .then(response => {this.$bvToast.toast(`Danie ${response.data.name} stworzono`, {
          title: 'Sukces!',
          variant: 'success',
          autoHideDelay: 5000,
          appendToast: false
        })})


      },
      onReset(event) {
        event.preventDefault()
        // Reset our form values
        this.form.name = ''
        this.form.price = null
        this.form.description = []
        // Trick to reset/clear native browser form validation state
        this.show = false
        this.$nextTick(() => {
          this.show = true
        })
      }
    }
  }
</script>