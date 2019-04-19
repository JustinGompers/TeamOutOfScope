<template>
    <div class= "CardSection">   
      <button id="CardButton" v-on:click.prevent="show()">Create a Card</button>
      <modal id="Form" name="CreateCard" :width="600" :height="275">
        <div id="modal-header">
                <h2>Create a Card Form</h2>
            </div>
            <div id="modal-body">
      <form id="formCard" @submit.prevent="Button()" >
        <div>
          <label>Question: </label>
        <input type="text" v-validate="'required'" id="question" placeholder="Enter a question" name="question" v-model="question" />
        </div>
        <div>
          <label>Answer: </label>
        <input type="text" id="answer" v-validate="'required'" placeholder="Enter the answer" name="answer" v-model="answer" />
        </div>
        <div>
          <label>Image: </label>
        <input type="text" id="image" placeholder="Enter an image url" name="img" v-model="image" />
        </div>
        <div>
          <label>Tags: </label>
        <input type="text" id="tags" v-validate="'required|max:20'" name="tag" placeholder="Enter tags" v-model="tags" />
        <span>{{ errors.first('tag') }}</span>
        </div>
        <div id="Buttons">
         <button id="SubmitButton">Submit</button>
      <button id="CancelButton" v-on:click.prevent="hide()">Cancel</button>
      </div>
      </form>
      </div>
     
      </modal>
        

      </div>
    
</template> 
        
    
<script>
export default {
    name: 'Card',   

    props: {
        ID: {
            type: Number,
            required: true,
            default: 0
        }
    },   

    data() {
        return {

          cards: [],
          showCardForm: false,
          question: '',
          answer: '',
          image: '',
          tags: '',
          addCard: false        
        };  
    },

    methods: {
    Button() {
         this.$validator.validateAll().then((result) => {
             if (result) {
          let cardInput = document.getElementById("formCard")
            let card = new FormData(cardInput)
            this.apiURL = "https://localhost:44337/api/Card/" + this.ID
            fetch(this.apiURL, {
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
            this.$modal.hide('CreateCard');
            this.question = '';
            this.answer = '';
            this.image = '';
            this.tags = '';
            alert('Your card has been submitted!');
            this.$emit('addCard', !this.addCard);
        }else{
            alert('Your card has missing fields!');
        }
    })
    },

    show(){
            this.$modal.show('CreateCard');
        },
        hide(){
            this.$modal.hide('CreateCard');
        }
}
}


</script>


<style>
.CardSection{
    display: inline;
}
#CardButton{ 
    width: 150px;
    height: 50px;
    background: #800020;
    font-style: bold;
    font-size: 15pt;
    color: white;
    cursor: pointer;
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