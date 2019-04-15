<template>
  <div class= "deck"> 
      <a id="createDeck" v-on:click.prevent="show()">Create a Deck</a>
      <modal id="Form" name="createDeck" :width="600" :height="400">
        <div id="modal-header">
            <h2>Create a Deck Form</h2>
        </div>
            <div id="modal-body">    
                <form id="formCreateDeck" @submit.prevent="Button">

                    <div>
                        <label>Question: </label>         
                    <input type="text" id="deck-name" placeholder="Enter name of deck" v-model="name"/>
                    </div>
                    <div>
                        <p>Choose the category of your deck:</p>
                        <select id="deck-category" v-model="categoryName">
                            <option v-for="category in categories" v-bind:key="category.Category_id"> {{category.Name}}</option>"
                        </select>
                    </div>
                    <br>
                    <div>
                        <form id="ShareDeckField">
                            Would you like to publicly share your deck?<br>
                            <input type="radio" id="share-deck-yes" name="yes-or-no" value="yes" v-on:click="share_deck=true" v-model="share_deck"/>Yes<br>
                            <input type="radio" id="share-deck-no" name="yes-or-no" value="no" v-on:click="share_deck=false" v-model="share_deck"/>No<br>
                        </form>
                    </div>
                        <button id="submitLoginButton">Submit</button>
                        <button id="cancelLoginButton" v-on:click.prevent="hide()">Cancel</button>     
                </form>
            </div>
        </modal>

        <br>
        <div>
        <button id="seeAllSharedDecks" v-on:click.prevent="getAllDecks">View All Decks</button>
        </div>

        <!--placeholder to make sure something is showing up for decks once API call is finished-->
        <p v-for="deck in decks" v-bind:key="deck.Deck_id"> {{deck.Name}}</p>
        

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
            // showCreateDeckForm: false, 
            // showSuccessMsg: false,
            // showFailMsg: false,
            categories: [],
            decks: [],
            deck: {},
            apiURL: "https://localhost:44337/api/deck"   

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

        createDeck() {
            this.$validator.validateAll().then((result) => {
                if (result) {  
            

            let deckInfo = document.getElementById("formCreateDeck");
            let deck = new FormData(deckInfo);

            fetch(this.apiURL, {
                    method: "POST",                    
                    mode: 'no-cors',                    
                    headers: {
                    "Content-Type": "application/json; charset=utf-8"
                    },
                    //body: JSON.stringify(deck)   
                    body: deck               
                })
                    .then(response => {
                    if (response.ok) {
                        // if our post was successful add the deck to our decks array so the user can see it
                        // the next time this page is refreshed the new deck will be pulled from the server.
                        //if we set up additional code to do that
                        this.decks.push(deck);
                        // this.showSuccessMsg = true;
                        // console.log("This worked.");
                    // } else {
                    //     this.showFailMsg = true;
                    //     console.log("This DID NOT work!");
                    }
                    })
                    .catch(err => console.error(err));

            
            this.name = '';
            this.share_deck = false;
            this.categoryName = '';
            this.showCreateDeckForm = false;
               alert('Your Deck has been submitted!');
        }else{ 
            alert('Your Deck has missing fields!');
        }})


        },

        getAllDecks(){
            fetch(this.apiURL,{
                mode: 'no-cors'
                })
                .then(response => {
                    return response.json();
                })
            //assign the deck objects from the DB to the decks array defined in this component
                .then(decks => {
                    this.decks = decks;
                });   
        },

        show(){
            this.$modal.show('createDeck');
        },
        hide(){
            this.$modal.hide('createDeck');
        }
}

</script>

<style>
#modal-header{
    text-align: center;
}
</style>


