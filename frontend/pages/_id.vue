<template>
    <div>
        <h1>ID: {{id}}</h1>
        <product/>
    </div>

</template>

<script>
export default {
    async asyncData({params}){
        const id = params.id
        return { id }
    }

}
</script>

<style>

</style>