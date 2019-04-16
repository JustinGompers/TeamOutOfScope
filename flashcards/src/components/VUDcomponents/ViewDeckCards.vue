<template>
    <div>
        <span v-for="card in Cards" v-bind:key="card.deck_id"> {{card.question}}:{{card.answer}}</span>
    </div>
</template>

<script>
export default {
    beforeCreate(){
        fetch("https://localhost:44337/api/Card/3", {
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