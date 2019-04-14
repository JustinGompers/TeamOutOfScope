<template>
    <div class= "CardSection">   
      <button id="CardButton" v-on:click.prevent="showCardForm = true" v-if="showCardForm== false">Create Your Card</button>
      
      <form id="formCard" v-if="showCardForm" >

        <div>
        <input type="text" id="question" placeholder="Enter a question" v-model="question" />
        </div>
        <div>
        <input type="text" id="answer" placeholder="Enter the answer" v-model="answer" />
        </div>
        <div>
        <input type="text" id="image" placeholder="Enter an image url" v-model="image" />
        </div>
        <div>
        <input type="text" id="tags" placeholder="Enter tags" v-model="tags" />
        </div>
        
        <button id="SubmitButton" v-on:click="submitCard">Submit</button>
        <button id="CancelButton" v-on:click.prevent="showCardForm = false">Cancel</button>
        
      </form>
      </div>
    
</template> 
        
    
<script>
export default {
    name: 'Card',   

    // props: {
    //     id: Number,
    //     question: String,
    //     answer: String,
    //     image: String
    // },   

    data() {
        return {

          cards: [],
          showCardForm: false,
          apiURL: "https://localhost:44337/api/Card",
          question: '',
          answer: '',
          image: '',
          tags: '',
            
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
            this.image = '';
            this.tags = '';
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

#CardButton{
  border: 1px solid rgb(207, 93, 0);
  border-radius: 15px;
  box-shadow: 2px 2px #888888;
}
#SubmitButton{
  border: 1px solid rgb(207, 93, 0);
  border-radius: 15px;
  box-shadow: 2px 2px #888888;
}
#CancelButton{
  border: 1px solid rgb(207, 93, 0);
  border-radius: 15px;
  box-shadow: 2px 2px #888888;
}


input {
  display: inline-block;
  
}

</style>