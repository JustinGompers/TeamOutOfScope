<template>
    <div class= "SearchCardSection">   
      
      <a id="SearchButton" v-on:click.prevent="show()">Search Cards</a>
      <modal id="Form" name="SearchCard" :width="600" :height="205">
        <div id="modal-header">
                <h2>Search Cards Form</h2>
            </div>
            <div id="modal-body">
      <form id="formSearch" @submit.prevent="Button()" >
          <input type="hidden" id="CardId" value="1" name="cardId" />
        <div>
          <label>Enter a tag: </label>
        <input type="text" v-validate="'required'" id="search" placeholder="i.e. algebra" name="search" v-model="search" />
        </div>
        <div id="Buttons">
         <button id="SubmitButton">Submit</button>
        <button id="CancelButton" v-on:click.prevent="hide()">Cancel</button>
        </div>
      </form>
      </div>
    </modal>
    
    <div class= "AddCardSection">
      </div>
      <a id="AddButton" v-on:click.prevent="show()">Add a Card</a>
      <modal id="Form" name="AddCard" :width="600" :height="205">
        <div id="modal-header">
          <h2>Add Cards Form</h2>
          </div>
          <div id="modal-body">
            <form id="AddCardSearch" @submit.prevent="Button()" >
              <input type="hidden" id="DeckId" value="1" name="deckId" />
              
                <select id="user-decks" v-validate="'required|min_value:1'" v-on:click.prevent="viewDecks()" v-model="category_id" name="user-deck-options">
                        <option disabled value=0>Please Select a Deck</option>
                        <option v-for="deck in userDecks" v-bind:key="deck.name" :value="deck.deckId"> {{deck.name}} </option>     
                </select>
                </form>
          </div>
              </modal>


    
  
    </div>
    

</template>


<script>
export default {
    name: 'SearchCard',

    data() {
        return {

          cards: [],
          showFormSearch: false,
          apiURL: "https://localhost:44337/api/Card/tag/",
          search: '',
            
        };
    },
    methods: {
    Button() {
         this.$validator.validateAll().then((result) => {
             if (result) {
            this.apiURL = this.apiURL + this.search
            fetch(this.apiURL, {
                method: 'GET'
            })
            .then(response => {
                return response.json();
            })
            .catch(err => {
                err
            });
            this.$modal.hide('SearchCard');
            this.search = '';
            this.showFormSearch = false;
            alert('Search Succesful!');
        }else{
            alert('Your search has missing fields!');
        }
    })
    },
    
    show(){
            this.$modal.show('SearchCard');
        },
        hide(){
            this.$modal.hide('SearchCard');
        }
    }
    }
</script>
<style>

#SearchButton{ 
  Color: white;
  border-bottom: solid;
  font-size: 24pt;
}
#SubmitButton{
  display: flex;
    justify-content: center;
    justify-content: space-around;
    padding-top: 5px;
    background: #800020;
        color: white;
        width: 300px;
        height: 50px;
        font-size: 25px;
        cursor: pointer;
}
#CancelButton{
  display: flex;
    justify-content: center;
    justify-content: space-around;
    padding-top: 5px;
    background: #800020;
        color: white;
        width: 300px;
        height: 50px;
        font-size: 25px;
        cursor: pointer;
}
div input{
    align-items: center;
}
#Buttons{
    display: flex;
    justify-content: center;
    justify-content: space-around;
    padding-top: 5px;
}
#buttons button{
        background: #800020;
        color: white;
        width: 300px;
        height: 50px;
        font-size: 25px;
        cursor: pointer;
}


</style>

    
    
    
    
