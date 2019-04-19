<template>
<div class="update-deck-section">
        <button id="update-deck-button" v-on:click.prevent="ShowUpdateDeckForm()">Update Deck</button>

        <modal id='update-deck-modal' name="update-deck-modal" :width="600" :height="200">
          <div id="modal-header">
            <h2>Update Deck Form</h2>
          </div>

          <div id="modal-body">
              <p id="warning">*Unfilled Content will stay the same.*</p>
            <form id="update-deck-form" @submit.prevent="UpdateDeck()">
                <div id="formContent">
                <div id="new-deck-name">
                    <label>New Deck Name: </label>
                    <input type="text" id="deck-name" v-validate="'max:25'" placeholder="if applicable" v-model="deckName" name="deckName"/>
                </div>
                <div id="new-deck-category">
                    <span id="cat">Choose the category of your deck:</span>
                        <select id="deck-category" v-validate="'required|min_value:1'" v-model="category_id" name="category_id">
                            <option disabled value=0>Please Select a Category</option>
                            <option v-for="category in categories" v-bind:key="category.id" :value="category.id"> {{category.name}} </option>     
                        </select>
                    <span>{{ errors.first('category_id') }}</span>
                </div>
                <div id="IsSharing">
                            <span class="Share">Would you like to publicly share your deck?</span>
                            <input type="checkbox" id="shareDeck" true-value="true" false-value="false" v-model="isOpen" name="isOpen">
                    </div>
                    </div>
                <div id=submit-deck-update-buttons>
                    <button id="submit-deck-update-button">Submit</button>
                    <button id="cancel-deck-update-button" v-on:click.prevent="HideUpdateDeckForm()">Cancel</button>
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

    name: 'UpdateDeck',

    data() {
        return {
            deckName: '',
            categories: [],
            category_id: 0,
            apiURL: "https://localhost:44337/api/deck/update/",
            updateDeck: false 
        }
    },

    props: {
        chosenDeck: {
            type: Number,
            required: true,
            default: 0
        }
    },

    methods: {
        ShowUpdateDeckForm(){
            this.$modal.show('update-deck-modal');
        },

        HideUpdateDeckForm(){
            this.$modal.hide('update-deck-modal');
        },

        UpdateDeck() {
         this.$validator.validateAll().then((result) => {
             if (result) {
          let deckUpdate = document.getElementById("update-deck-form")
            let deck = new FormData(deckUpdate)
            fetch(this.apiURL + this.chosenDeck, {
                method: 'POST',
                body: deck,
                mode: 'no-cors'                
            })
            .then(response => {
                return response.json();
            })
            .catch(err => {
                console.log(err)
            });
            this.deckName = '';
            this.$modal.hide('update-deck-modal');

            alert('Your update has been submitted!');
            this.$emit('deck-update', !this.updateDeck);
            
        }else{
            alert('Your update did not work.  Please try again.');
        }
        })
    }

    }
}
</script>

<style>
#warning{
    font-size: 8pt;
    padding-left: 15px;
}
.update-deck-section{
    display: inline;
}
#update-deck-button{
    width: 150px;
    height: 50px;
    background: #800020;
    font-style: bold;
    font-size: 15pt;
    color: white;
    cursor: pointer;
}
#submit-deck-update-buttons button{
    background: #800020;
        color: white;
        width: 300px;
        height: 50px;
        font-size: 25px;
        cursor: pointer;
}
#formContent{
    padding-left: 15px;
}
</style>


