<template>
  <h1>{{dish.name}}</h1>
</template>

<script>
export default {
    data: () => ({
        dish: null,
    }),
    mounted(){
        this.$axios.get(`https://localhost:7108/api/Dishes/${this.$route.params.id}`).then(res => this.dish = res.data)
        console.log('dupa')
    }

}
</script>

<style>

</style>