<template>
    <div>
        <h2>My Decks</h2>
        <div id="Decks">
            <span v-for="deck in UserDecks" v-bind:key="deck.deck_id" :value="deck">
                <span class="decklist">
                <img src="../assets/cards.png">
                <button @click="DeckDecided(deck)" :class="{'active': deck.deck_id == ChosenDeck.deck_id}"> {{deck.deckName}}</button>
                </span>
            </span>
        </div>
    </div>
</template>

<script>
export default {
    created(){
            this.apiURL = "https://localhost:44337/api/deck/user/" + this.ID ;
            fetch(this.apiURL,{
                    method: 'GET'
                    })
                    .then(response => {
                        return response.json();
                    })
                    .then(data => {
                     this.UserDecks = data;
                    })
                    .catch(e => console.log(e));
    },
    name: 'ViewUserDecks',
    props: {
        ID: {
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
        ID: function(newVal, oldVal){
            if(newVal !== oldVal){
                this.apiURL = "https://localhost:44337/api/deck/user/" + this.ID ;
                fetch(this.apiURL,{
                    method: 'GET'
                    })
                    .then(response => {
                        return response.json();
                    })
                    .then(data => {
                     this.UserDecks = data;
                    })
                    .catch(e => console.log(e));
            }
        },
        ADD: function(newVal, oldVal){
            if(newVal !== oldVal){
                this.apiURL = "https://localhost:44337/api/deck/user/" + this.ID ;
                fetch(this.apiURL,{
                    method: 'GET'
                    })
                    .then(response => {
                        return response.json();
                    })
                    .then(data => {
                     this.UserDecks = data;
                    })
                    .catch(e => console.log(e));
            }
        }
    },
    data(){
        return{
            apiURL: "https://localhost:44337/api/deck/user/",
            UserDecks: [],
            showUserDecks: false,
            ChosenDeck: {},
            activeIndex: null
        }
    },
    methods: {
        DeckDecided(id){
            console.log(id.deck_id);
            this.ChosenDeck = id
            this.$emit('chosenDeck', this.ChosenDeck);
        }
    }
}
</script>



<style>
.decklist .active{
    background-color: red;
}
img{
    width: 100%;
}
.decklist{
    display: inline-flex;
    flex-flow: column nowrap;
    width: 10%;
    background: #800020;
    border: solid black;    
}
.decklist button{
    background: black;
    border-color: white;
    color: white;
    cursor: pointer;
    font-size: 12pt;
}
</style>