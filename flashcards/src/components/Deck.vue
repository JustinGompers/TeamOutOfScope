<template>
  <div class= "deck"> 
      <h2>This is the start of the Deck section</h2> 
      <button id="createDeck" v-on:click.prevent="showCreateDeckForm = true" v-if="showCreateDeckForm== false" v-on:click="getCategories">
          Create Your Deck</button>
      
      <ul id="formCreateDeck" v-if="showCreateDeckForm === true">
        
        <input type="text" id="deck-name" placeholder="Enter name of deck" v-model.trim="name"/>
        
        <div>
            <p>Choose the category of your deck:</p>
            <select id="deck-category" v-model="categoryName">
                <option v-for="category in categories" v-bind:key="category.Category_id"> {{category.Name}}</option>"
            </select>
        </div>

        <br>
        <form id="ShareDeckField">
             Would you like to publicly share your deck?<br>
            <input type="radio" id="share-deck-yes" name="yes-or-no" value="yes" v-on:click="share_deck=true" v-model="share_deck"/>Yes<br>
            <input type="radio" id="share-deck-no" name="yes-or-no" value="no" v-on:click="share_deck=false" v-model="share_deck"/>No<br>
        </form>
        <button id="submitLoginButton" v-on:click="createDeck">Submit</button>
        <button id="cancelLoginButton" v-on:click.prevent="showCreateDeckForm = false">Cancel</button>
      </ul>

        <p id="deckCreated" v-if="showSuccessMsg===true">Your new deck has been created!</p>

    </div>
</template>

<script>
export default {
    name: 'deck',

    data() {
        return {
            name: '',
            categoryName: '',
            share_deck: false,            
            showCreateDeckForm: false, 
            categories: [],
            decks: [],
            deck: {}   

        };
    }, 

    methods: {
        getCategories() {
            fetch(this.apiURL,{
                mode: 'no-cors'
                })
                .then(response => {
                    return response.json();
                })
            //assign the user objects from the DB to the users array defined in this component
                .then(categories => {
                    this.categories = categories;
                });   
        }
    },

        createDeck(input) {
            fetch(this.apiURL, {
                    method: "POST",
                    headers: {
                    "Content-Type": "application/json; charset=utf-8"
                    },
                    body: JSON.stringify(deck)
                })
                    .then(response => {
                    if (response.ok) {
                        // if our post was successful add the deck to our decks array so the user can see it
                        // the next time this page is refreshed the new deck will be pulled from the server.
                        //if we set up additional code to do that
                        this.decks.push(deck);
                        this.showSuccessMsg = true;
                        console.log("This worked.");
                    }
                    })
                    .catch(err => console.error(err));

        }
}

</script>

<style>

</style>


