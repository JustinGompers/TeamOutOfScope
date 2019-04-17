<template>
    <div>
        <h2>My Decks</h2>
        <div id="Decks">
            <span v-for="deck in UserDecks" v-bind:key="deck.deck_id" :value="deck">
                <span class="decklist">
                <img src="../assets/cards.png">
                <button @click="DeckDecided(deck)"> {{deck.deckName}}</button>
                </span>
            </span>
        </div>
    </div>
</template>

<script>
export default {
    created(){
        this.showUserDecks = true;
            this.apiURL = this.apiURL + this.ID ;
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
        // ViewAll(){
        //     this.showUserDecks = true;
        //     this.apiURL = this.apiURL + this.ID ;
        //     fetch(this.apiURL,{
        //             method: 'GET'
        //             })
        //             .then(response => {
        //                 return response.json();
        //             })
        //             .then(data => {
        //              this.UserDecks = data;
        //             })
        //             .catch(e => console.log(e));
        // },
        DeckDecided(id){
            console.log(id.deck_id);
            this.ChosenDeck = id
            this.$emit('chosenDeck', this.ChosenDeck);
        }
    }
}
</script>



<style>
img{
    width: 100%;
}
.decklist{
    display: inline-flex;
    flex-flow: column nowrap;
    width: 10%;   
}
</style>