<template>
    <div>
        <button id="ViewUserCreatedDecks" @click.prevent="ViewAll()" v-if="showUserDecks === false">View UserDecks</button>
        <div id="Decks" v-if="showUserDecks === true">
            <button v-for="deck in UserDecks" @click="DeckDecided(deck.deck_id)" v-bind:key="deck.deck_id" :value="deck.deck_id"> {{deck.deckName}}</button>
        </div>
        <span>{{ChosenDeck}}</span>
    </div>
</template>

<script>
//import ViewDeckCards from './components/VUDcomponents/ViewDeckCards.vue'

export default {
    name: 'ViewUserDecks',
    components:{
        //ViewDeckCards
    },
    props: {
        ID: {
            type: Number,
            required: true,
            default: 0
        }
    },
    data(){
        return{
            apiURL: "https://localhost:44337/api/deck/user/",
            UserDecks: [],
            showUserDecks: false,
            ChosenDeck: 0
        }
    },
    methods: {
        ViewAll(){
            this.showUserDecks = true;
            this.apiURL = this.apiURL +this.ID ;
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
        DeckDecided(id){
            this.ChosenDeck = id
        }
    }
}
</script>



<style>
</style>