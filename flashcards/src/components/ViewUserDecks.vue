<template>
    <div>
        <a id="ViewUserCreatedDecks" @click.prevent="showUserDecks === true">View UserDecks</a>
        <div id="Decks>">
            <span v-for="deck in UserDecks" v-bind:key="deck.deck_id"> {{deck.deckName}}</span>
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
            apiURL = "https://localhost:44337/api/deck/user/",
            UserDecks = [],
            showUserDecks = false
        }
    },
    methods: {
        ViewAll(){
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
        }
    }
}
</script>



<style>
</style>