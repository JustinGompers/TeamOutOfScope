<template>
    <div>
        <button v-for="cards in Cards" v-bind:key="cards.cardID" :value="cards"> {{this.cards.question}} : {{this.cards.answer}}</button>
    </div>
</template>

<script>
export default {
    mounted(){
        this.apiURL = this.apiURL + this.DID;
        fetch(this.apiURL, {
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
            Cards: [],
            apiURL: "https://localhost:44337/api/Card/"
        }
    }
}
</script>

<style>
</style>