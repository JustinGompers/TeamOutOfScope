<template>
<div>
<h2>This is the beginning of the Update Card Section.</h2>

<div class="choose-card">
    <button id="choose-card-button" v-on:click.prevent="showSearch()">Choose Card to Update</button>

<!-- Add elements to search for the card you want to update -->
    <modal id='search-card-modal' name="search-card-modal" :width="600" :height="300">
            <div id="modal-header">
                <h2>Search Card to Update</h2>
            </div>
            <div id="modal-body">
                <div id="deck">
                        <span id="deck">Choose the deck that contains the card you would like updated:</span>
                        <select id="choose-deck" v-validate="'required|min_value:1'" v-model="Deck_id" name="deck_id"
                            v-on:click="populateCards">
                            <option disabled value=0>Please Select a Deck</option>
                            <option v-for="deck in decks" v-bind:key="deck.Deck_id" :value="deck.Deck_id"> {{deck.Name}} </option>     
                        </select>
                        <span>{{ errors.first('Deck_id') }}</span>
                </div>
                <div id="card">
                        <span id="card">Choose the card you would like updated:</span>
                        <select id="choose-card" v-validate="'required|min_value:1'" v-model="Card_id" name="card_id">
                            <option disabled value=0>Please Select a Card</option>
                            <option v-for="card in cards" v-bind:key="card.Card_id" :value="card.Card_id"> {{card.Question}} </option>     
                        </select>
                        <span>{{ errors.first('card_id') }}</span>
                </div>
                <div id=buttons>
                        <button id="submitLoginButton">Submit</button>
                        <button id="cancelLoginButton" v-on:click.prevent="hideSearch()">Cancel</button>
                </div>     
            </div>
    </modal>
    </div>

            <div class="UpdateCard">
                <button id="update-card-button" v-on:click.prevent="show()">Update Card</button>   


    <modal id='update-card-modal' name="update-card-modal" :width="600" :height="300">
            <div id="modal-header">
                <h2>Update Card Form</h2>
            </div>
            <div id="modal-body">

            <form id="update-card-form" @submit.prevent="Button">
                <div id="body">
                    <label>New Question: </label>
                    <input type="text" id="question" placeholder="if applicable" v-model="question" />
                </div>
                <div>
                    <label>New Answer: </label>
                    <input type="text" id="answer" placeholder="if applicable" v-model="answer" />
                </div>
                <div>
                    <label>New Image: </label>
                    <input type="text" id="image" placeholder="if applicable" v-model="image" />
                </div>
                <div>
                    <label>New Tags: </label>
                    <input type="text" id="tags" placeholder="if applicable" v-model="tags" />
                </div>

                <!-- add a hidden field that also passes through the deck id 
                     also need to somehow bind this-need the deckId field in script section
                     to be populated first-->
                <div>
                    <input type="hidden" id="deck-id" v-model="deckId" />
                </div>
                <div>
                    <button id="SubmitButton">Submit</button>
                    <button id="CancelButton" v-on:click.prevent="hide()">Cancel</button>
                </div>
            </form>
            </div>
            
      </modal>

</div>

</div>    
</template>

<script>
export default {

    beforeCreate(){
        fetch("https://localhost:44337/api/deck/user/" + this.userId,{
                method: 'GET'
                })
                .then(response => {
                    return response.json();
                })
                 .then(data => {
                    this.decks = data;
                })
                .catch(e => console.log(e));
    },

    name: 'UpdateCard',
    //HAVE TO SOMEHOW BIND THE CARD ID SO THE URL IN THE BUTTON METHOD WORKS CORRECTLY
    Card_id: 0,
    Deck_id: 0,
    question: '',
    answer: '',
    image: '',
    tags: '',
    decks: [],
    cards: [],
    apiURL: "https://localhost:44337/api/Card",

    props: {
        userId:{
            type: Number,
            required: true,
            default: 0
        }
    },

    methods: {

        show(){
            this.$modal.show('update-card-modal');
        },

        hide(){
            this.$modal.hide('update-card-modal');
        },

        showSearch(){
            this.$modal.show('search-card-modal');
        },

        hideSearch(){
            this.$modal.hide('search-card-modal');
        },

        populateCards(){
            
              fetch(this.apiURL + "/" + Deck_id,{
                method: 'GET'
                })
                .then(response => {
                    return response.json();
                })
            //assign the user objects from the DB to the cards array defined in this component
                .then(data => {
                    this.cards = data;
                })
                .catch(e => {
                    console.log(e);
                });

            },

        Button() {
        //NOT SURE IF THIS NEEDS ADJUSTED BECAUSE FIELDS IN UPDATE CARD FORM ABOVE ARE OPTIONAL AND NOT REQUIRED
         this.$validator.validateAll().then((result) => {
             if (result) {
          let cardUpdate = document.getElementById("update-card-form")
            let card = new FormData(cardUpdate)
            fetch(this.apiURL + "/" + this.cardId, {
                method: 'POST',
                body: card,
                mode: 'no-cors',
                headers: {
                    'Content-Type': 'application/json'
                }
            })
            .then(response => {
                return response.json();
            })
            .catch(err => {
                err
            });
            this.question = '';
            this.answer = '';
            this.image = '';
            this.tags = '';
            this.showCardForm = false;
            alert('Your update has been submitted!');
        }else{
            alert('Your update did not work.');
        }
        })
    }
    }
}

</script>

<style>

</style>


