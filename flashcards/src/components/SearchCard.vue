<template>
<div class= "SearchCardSection">   
      <a id="SearchButton" v-on:click.prevent="show()">Search Flash Cards</a>
      <modal id="Form" name="SearchCard" :width="600" :height="400">
        <div id="modal-header">
                <h2>Search a Card Form</h2>
            </div>
            <div id="modal-body">
      <form id="formSearch" @submit.prevent="Button()" >
          <input type="hidden" id="CardId" value="1" name="cardId" />
        <div>
          <label>Search: </label>
        <input type="text" v-validate="'required'" id="search" placeholder="Enter a tag" name="search" v-model="question" />
        </div>
         <button id="SubmitButton">Submit</button>
      <button id="CancelButton" v-on:click.prevent="hide()">Cancel</button>
      </form>
      </div>
     
      </modal>
        

      </div>
      
</div>

</template>

<script>
export default {
    name: 'Card',

    data() {
        return {

          cards: [],
          apiURL: "https://localhost:44337/api/SearchCard",
          Search: '',
            
        }
    }
}
</script>