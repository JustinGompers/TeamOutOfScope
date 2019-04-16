<template>
    <div>
    </div>
</template>

<script>
export default {
    beforeCreate(){
        fetch("https://localhost:44337/api/Card/1", {
            method: 'GET'
        })
        .then(response => {
            return response.json();
        })
        .then(data => {
            this.Cards = data;
        })
    },
    name: 'ViewDeckCards',
    props: {
        DID: {
            type: Number,
            required: true,
            default:0
        }
    },
    data() {
        return {
            Cards: []
        }
    }
}
</script>

<style>
</style>