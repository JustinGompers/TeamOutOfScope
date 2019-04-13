<template>
    <div class= "cardSection">   
      <button id="CardButton" v-on:click.prevent="showCardForm = true" v-if="showCardForm== false">Create Your Card</button>
      
      <form id="formCard" v-if="showCardForm" >

        <div>
        <label>Question:</label>
            <input type="text" id="question" placeholder="Enter a question" v-model="question" />
        </div>
        <div>
          <label>Answer: </label>
            <input type="text" id="answer" placeholder="Enter the answer" v-model="answer" />
        </div>
        
        <button id="submitQuestionButton" v-on:click="submitCard">Submit</button>
        <button id="cancelQuestionButton" v-on:click.prevent="showCardForm = false">Cancel</button>
        
      </form>
      </div>
    
</template> 
        
    
<script>
export default {
    name: 'Card',   

    props: {
        id: Number,
        question: String,
        answer: String,
        image: String
    },   

    data() {
        return {

          cards: [],
          showCardForm: false,
          apiURL: "https://localhost:44337/api/flashycards",
          question: '',
          answer: '',
            
        };  
    },

    methods: {
    Button() {
        if (result) {
          let cardInput = document.getElementById("formCard")
            let card = new FormData(cardInput)
            fetch(this.apiURL, {
                method: 'POST',
                body: card,
                mode: 'no-cors',
                headers: {
                    'Content-Type': 'application/json'
                }
            })
            .catch(err => {
                err
            });
            this.question = '';
            this.answer = '';
            this.showCardForm = false;
            alert('Your card has been submitted!');
        }else{
            alert('Correct them errors!');
        }
    }
    },
}

</script>

<style>
#modal-header{
    text-align: center;
}
</style>