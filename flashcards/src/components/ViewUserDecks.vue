<template>
    <div>
        <button id="ViewUserCreatedDecks" @click.prevent="ViewAll()" v-if="showUserDecks === false">View UserDecks</button>
        <div v-if="showUserDecks === true">
            <div id="Decks">
                <button v-for="deck in UserDecks" @click="DeckDecided(deck)" v-bind:key="deck.deck_id" :value="deck"> {{deck.deckName}}</button>
            </div>
        </div>
    </div>
</template>

<script>
export default {
    name: 'ViewUserDecks',
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
            ChosenDeck: {}
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
            console.log(id.deck_id);
            this.ChosenDeck = id
            this.$emit('chosenDeck', this.ChosenDeck);
        }
    }
}
</script>



<style>
</style>