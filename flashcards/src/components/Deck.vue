<template>
  <div class= "deck"> 
      <button id="createDeck" v-on:click.prevent="show()">Create a Deck</button>
      <modal id="Form" name="createDeck" :width="600" :height="225">
        <div id="modal-header">
            <h2>Create a Deck Form</h2>
        </div>
            <div id="modal-body">    
                <form id="formCreateDeck" @submit.prevent="createDeck()">
                
                    <div id="question">
                        <label>Question: </label>         
                    <input type="text" id="deck-name" v-validate="'required'" placeholder="Enter name of deck" v-model="deckName" name="deckName"/>
                    <span>{{ errors.first('deckName')}}</span>
                    </div>
                    <input type="hidden" value=ID name="person_id"/>
                    <div id="category">
                        <span id="cat">Choose the category of your deck:</span>
                        <select id="deck-category" v-validate="'required|min_value:1'" v-model="category_id" name="category_id">
                            <option disabled value=0>Please Select a Category</option>
                            <option v-for="category in categories" v-bind:key="category.id" :value="category.id"> {{category.name}} </option>     
                        </select>
                        <span>{{ errors.first('category_id') }}</span>
                    </div>
                    <br>
                    <div id="sharing">
                            <span class="Share">Would you like to publicly share your deck?</span>
                            <input type="checkbox" id="shareDeck" true-value="true" false-value="false" v-model="isOpen" name="isOpen">
                    </div>
                    <div id=buttons>
                        <button id="submitLoginButton">Submit</button>
                        <button id="cancelLoginButton" v-on:click.prevent="hide()">Cancel</button>
                    </div>     
                </form>
            </div>
        </modal>
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
                })
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
            categories: [],
            apiURL: "https://localhost:44337/api/deck"   

        };
    }, 

    methods: {
        createDeck() {
            this.$validator.validateAll().then((result) => {
                if (result) {  
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
                        this.decks.push(deck);
                    }
                    })
                    .catch(err => console.error(err));

            
                    this.name = '';
                    this.share_deck = false;
                    this.categoryName = '';
                    this.showCreateDeckForm = false;
                    this.$modal.hide('createDeck');
            
            
                    alert('Your Deck has been submitted!');
                }
            })

        },
        show(){
             this.$modal.show('createDeck');
        },
        hide(){
             this.$modal.hide('createDeck');
        }}
};


</script>

<style>
#modal-header{
    text-align: center;
    background-color:  #FF983E;
}
.Share {
    color: black;
    font-size: 12pt;
}
#question {
    padding-left: 14px;
}
#sharing {
    padding-left: 14px;
}
#category{
    padding-left: 14px;
    padding-top: 20px;
}
#cat{
    color:black;
    font-size: 12pt;
}
</style>


