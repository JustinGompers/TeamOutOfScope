<template>
    <div class= "cardSection"> 
        <h2>This is where the card section will go</h2>   
      <button id="createCard" v-on:click="showNewCardForm">Create Your Card</button>
      
      <ul id="formNewCard">
        <li id="newCardQuestion" style="display:none;">
            <input type="text" id="new-question" placeholder="Add New Question" v-on:keyup.enter="addCard">
        </li>
        <li id="newCardAnswer" style="display:none;">
            <input type="text" id="new-answer" placeholder="Add New Answer" v-on:keyup.enter="addCard">
        </li>
        <li
            v-for="card in cards"
            v-bind:key="card.id"
            v-bind:class="{/*TO BE COMPLETED*/}"
            
            v-on:click="changeStatus(card.id, $event)"> <!--not sure how this will be used yet-->
        
            <input type="checkbox">
            {{card.question}}
            {{card.answer}}
            <i class="far fa-check-circle" v-bind:class="{/*TO BE COMPLETED*/}"></i> <!--not sure how this will be used yet-->
        </li>
      </ul> 
    
    </div>

    
</template>

<script>
export default {
    name: "card",   

    props: {
        id: Number,
        question: String,
        answer: String,
        image: String
    },   


    data() {
        return {
            //example:  "http://localhost:5000/api/cards",
            apiURL: "YOUR_REST_API_URL",
            cards: []
        };  
    },

    //borrowed from TodoList.vue file from Building REST APIs tutorial
    //not entirely sure yet how it might be used--assign what comes back from FlashCardsDB to the local cards variable?
    created() {
    fetch(this.apiURL)
      .then(response => {
        return response.json();
      })
      .then(cards => {
        this.cards = cards;
      })
      .catch(err => console.log(err));
    },

    //borrowed from TodoList.vue file from Building REST APIs tutorial
    //may still need tweaked to our specific application
    addCard() {
      const newCard = document.getElementById("new-card");
      //we will be accepting properties of a card object (question, answer & maybe image too)
      //need some way to assign multiple properties... is this enough to do it?
      const card = newCard.value;
      const maxid = Math.max(...this.cards.map(card => card.id));
      //const card = { id: maxid + 1 };

      // use fetch to create a new card in our FlashCardsDB.
      fetch(this.apiURL, {
        method: "POST",
        headers: {
          "Content-Type": "application/json; charset=utf-8"
        },
        body: JSON.stringify(card)
      })
        .then(response => {
          if (response.ok) {
            // if our post was successful add the card to our cards array so the user can see it
            // the next time this page is refreshed the new card will be pulled from the server.
            this.cards.push(card);
          }
        })
        .catch(err => console.error(err));

      // clear the value so the user can type another task
      newCard.value = "";
    },

    showNewCardForm() {
      console.log("Add Card...");
      // the list-item that contains the input box
      const form = document.getElementById("newCardQuestion");
      // the new todo form field
      const input = document.getElementById("new-question");
      // the list-item is hidden by default
      form.removeAttribute("style");
      // set the focus to the input box so the user can start typing a new card
      const form2 = document.getElementById("newCardAnswer");
      // the new todo form field
      const input2 = document.getElementById("new-answer");
      // the list-item is hidden by default
      form.removeAttribute("style");
      // set the focus to the input box so the user can start typing a new card
      input.focus();
    }
  };


</script>

<style lang="scss" scoped>

</style>


