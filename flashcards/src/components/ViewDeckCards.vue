<template>
    <div>
        <span v-for="card in Cards" v-bind:key="card.cardID" :value="card">
            <span class="cardlist">
                <img src="../assets/cardlogo.png">
                <button> {{card.question}}</button>
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
        })
            }

        }
    },
    data() {
        return {
            Cards: [],
            apiURL: "https://localhost:44337/api/Card/",
        }
    }
}
</script>

<style>
.cardlist{
    display: inline-flex;
    flex-flow: column nowrap;
    width:10%;
}
</style>