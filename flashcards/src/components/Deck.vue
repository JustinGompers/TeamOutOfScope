<template>
  <div class= "deck"> 
      <button id="createDeck" v-on:click.prevent="show()">Create a Deck</button>
      <modal id="Form" name="createDeck" :width="600" :height="400">
        <div id="modal-header">
            <h2>Create a Deck Form</h2>
        </div>
            <div id="modal-body">    
                <form id="formCreateDeck" @submit.prevent="createDeck()">
                
                    <div>
                        <label>Question: </label>         
                    <input type="text" id="deck-name" placeholder="Enter name of deck" v-model="deckName" name="deckName"/>
                    </div>
                    <input type="hidden" value=ID name="person_id"/>
                    <span> {{ID}} </span>
                    <div id="category">
                        <p>Choose the category of your deck:</p>
                        <select id="deck-category" v-model="category_id" name="category_id">
                            <option disabled value=0>Please Select a Category</option>
                            <option v-for="category in categories" v-bind:key="category.id"> {{category.id}} </option>     
                        </select>
                        <p>You chose {{category_id}} </p>
                    </div>
                    <br>
                    <div>
                            <p>Would you like to publicly share your deck?</p>
                            <input type="checkbox" id="shareDeck" true-value="true" false-value="false" v-model="isOpen" name="isOpen">
                            <span> {{isOpen}}</span>
                    </div>
                    <div id=buttons>
                        <button id="submitLoginButton">Submit</button>
                        <button id="cancelLoginButton" v-on:click.prevent="hide()">Cancel</button>
                    </div>     
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
    beforeCreate(){
        fetch("https://localhost:44337/api/deck",{
                method: 'GET'
                })
                .then(response => {
                    return response.json();
                    //return response.text();
                })
                //.then(text => console.log(text))
            //assign the user objects from the DB to the users array defined in this component
                 .then(data => {
                    this.categories = data;
                })
                .catch(e => console.log(e));
    },
    name: 'deck',
    props: {
        ID:{
            type: Number,
            required: true,
            default: 0
        }
    },

    data() {
        return {
            deckName: '',
            category_id: 0,
            isOpen: 'false',            
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
        createDeck() {
            //this.$validator.validateAll().then((result) => {
                //if (result) {  
            let deckInfo = document.getElementById("formCreateDeck");
            let deck = new FormData(deckInfo);
            console.log(deck);
            fetch(this.apiURL, {
                    method: 'POST',                    
                    mode: 'no-cors',  
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
            this.$modal.hide('createDeck');
            
            
               alert('Your Deck has been submitted!');
        //}else{ 
            //alert('Your Deck has missing fields!');
        //}
        //})

        },
        show(){
             this.$modal.show('createDeck');
        },
        hide(){
             this.$modal.hide('createDeck');
        }}};

        // getAllDecks(){
        //     fetch(this.apiURL,{
        //         mode: 'no-cors'
        //         })
        //         .then(response => {
        //             return response.json();
        //         })
        //     //assign the deck objects from the DB to the decks array defined in this component
        //         .then(decks => {
        //             this.decks = decks;
        //         });   
        // };

        


</script>

<style>
#modal-header{
    text-align: center;
}
#category{
    padding-left: 50px;
}
</style>


