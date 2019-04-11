<template>
  <div class= "deck"> 
      <h2>This is the start of the Deck section</h2> 
      <button id="createDeck" v-on:click.prevent="showCreateDeckForm = true" v-if="showCreateDeckForm== false">Create Your Deck</button>
      
      <ul id="formCreateDeck" v-if="showCreateDeckForm === true">
        
        <input type="text" id="deck-name" placeholder="Enter name of deck" v-model.trim="name"/>

        <select id="deck-category" v-model="categories">
            <option v-for="category in categories" {{category.Name}}</option>"
            </select>
        
        <form id="ShareDeckField">
             Would you like to publicly share your deck?<br>
            <input type="radio" id="share-deck-yes" name="yes-or-no" value="yes" v-on:click="share_deck=true" v-model="share_deck"/>Yes<br>
            <input type="radio" id="share-deck-no" name="yes-or-no" value="no" v-on:click="share_deck=false" v-model="share_deck"/>No<br>
        </form>
        <button id="submitLoginButton" v-on:click="submitNewDeck">Submit</button>
        <button id="cancelLoginButton" v-on:click.prevent="showCreateDeckForm = false">Cancel</button>
      </ul>
      </div>
</template>

<script>
export default {
    name: 'deck',

    data() {
        return {
            name: '',
            share_deck: false,
            category: '',
            showCreateDeckForm: false, 
            categories: []
           

        
        };
    }, 

    methods: {
        getCategories() {

        }
    },

        createDeck(input) {

        }
}

</script>

<style>

</style>


