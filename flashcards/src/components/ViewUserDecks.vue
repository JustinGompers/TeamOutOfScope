<template>
    <div>
        <h2>{{this.ID.firstName}}'s Decks</h2>
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
            this.apiURL = "https://localhost:44337/api/deck/user/" + this.ID.userId ;
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
            type: Object,
            required: true,
        },
        ADD: {
            type: Boolean,
            required: true,
            default: false
        },
        Change:{
            type: Number,
            required: true,
            default: 0
        }
    },
    watch:{
        ID: function(newVal, oldVal){
            if(newVal !== oldVal){
                this.apiURL = "https://localhost:44337/api/deck/user/" + this.ID.userId ;
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
                this.apiURL = "https://localhost:44337/api/deck/user/" + this.ID.userId ;
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
            Change: function(newVal, oldVal){
                if(newVal !== 0){
                this.ChosenDeck = {};
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
            if(id === this.ChosenDeck){
                this.ChosenDeck = {}
                this.$emit('chosenDeck', id);
            }else{
                console.log(id.deck_id);
            this.ChosenDeck = id
            this.$emit('chosenDeck', this.ChosenDeck);
            }
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
    height: 50px;
}
</style>