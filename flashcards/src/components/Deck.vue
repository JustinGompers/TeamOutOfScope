<template>
  <div class= "deck"> 
      <h2>This is the start of the Deck section</h2> 
      <button id="createDeck" v-on:click.prevent="showCreateDeckForm = true" v-if="showCreateDeckForm== false">Create Your Deck</button>
      
      <ul id="formCreateDeck" v-if="showCreateDeckForm === true">
        <li id="nameOfDeckField" >
            <input type="text" id="deck-name" placeholder="Enter name of deck." v-model.trim="email"/>
        </li>
        <li id="ShareDeckField">
            Would you like to publicly share your deck?<br>
            <input type="radio" id="share-deck-yes" value="yes" v-on:click="share_deck=true" v-model="share_deck"/>Yes<br>
            <input type="radio" id="share-deck-no" value="no" v-on:click="share_deck=false" v-model="share_deck"/>No<br>

            
        </li>
        <button id="submitLoginButton" v-on:click="submitLogin">Submit</button>
        <button id="cancelLoginButton" v-on:click.prevent="showLoginForm = false">Cancel</button>
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
            showCreateDeckForm: false

        
        };
    }
}

</script>

<style>

</style>


