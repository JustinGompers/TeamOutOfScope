<template>
    <div>
        <span v-for="card in Cards" v-bind:key="card.cardID" :value="card">
            <span class="cardlist">
                <img src="../assets/cardlogo.png">
                <button @click="CardDecided(card)" :class="{'active': card.cardID == ChosenCard.cardID}"> {{card.question.slice(0,25)}}...</button>
            </span>
        </span>
    </div>
</template>

<script>
export default {
    created(){
        this.ID2 = this.ID
        this.apiURL = "https://localhost:44337/api/Card/" + this.DID;
        fetch(this.apiURL, {
            method: 'GET'
        })
        .then(response => {
            return response.json();
        })
        .then(data => {
            this.Cards = data;
            this.$emit('cardData', this.Cards);
        })
    },
    name: 'ViewDeckCards',
    props: {
        DID: {
            type: Number,
            required: true,
            default: 0
        },
        ADD: {
            type: Boolean,
            required: true,
            default: false
        }
    },
    watch:{
        DID: function(newVal, oldVal) {
            if(newVal !== oldVal){
            this.apiURL = "https://localhost:44337/api/Card/" + this.DID;
        fetch(this.apiURL, {
            method: 'GET'
        })
        .then(response => {
            return response.json();
        })
        .then(data => {
            this.Cards = data;
            this.$emit('cardData', this.Cards);
        })
            }
        },
        ADD: function(newVal, oldVal){
            if(newVal !== oldVal){
                this.apiURL = "https://localhost:44337/api/Card/" + this.DID;
        fetch(this.apiURL, {
            method: 'GET'
        })
        .then(response => {
            return response.json();
        })
        .then(data => {
            this.Cards = data;
            this.$emit('cardData', this.Cards);
        })
            }

        }
    },
    data() {
        return {
            Cards: [],
            apiURL: "https://localhost:44337/api/Card/",
            ChosenCard: {}
        }
    },
    methods:{
        CardDecided(chosen){
            this.ChosenCard = chosen;
            this.$emit('chosenCard', this.ChosenCard);
        }
    }
}
</script>

<style>
.cardlist .active{
    background-color: red;
}
.cardlist{
    display: inline-flex;
    flex-flow: column nowrap;
    width: 10%;
    background: #800020;
    border: solid black;
}
.cardlist button{
    background: black;
    border-color: white;
    color: white;
    cursor: pointer;
    font-size: 12pt;
    height: 50px;
}
</style>