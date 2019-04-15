<template>
    <div class= "CardSection">   
      <a id="CardButton" v-on:click.prevent="show()">Create a Card</a>
      <modal id="Form" name="CreateCard" :width="600" :height="400">
        <div id="modal-header">
                <h2>Create a Card Form</h2>
            </div>
            <div id="modal-body">
      <form id="formCard" @submit.prevent="Button" >

        <div>
          <label>Question: </label>
        <input type="text" id="question" placeholder="Enter a question" v-model="question" />
        </div>
        <div>
          <label>Answer: </label>
        <input type="text" id="answer" placeholder="Enter the answer" v-model="answer" />
        </div>
        <div>
          <label>Image: </label>
        <input type="text" id="image" placeholder="Enter an image url" v-model="image" />
        </div>
        <div>
          <label>Tags: </label>
        <input type="text" id="tags" placeholder="Enter tags" v-model="tags" />
        </div>
      </form>
      </div>
      <button id="SubmitButton">Submit</button>
      <button id="CancelButton" v-on:click.prevent="hide()">Cancel</button>
      </modal>
        

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
         this.$validator.validateAll().then((result) => {
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
            alert('Your card has been submitted!');
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

#CardButton{ 
  Color: white;
  border-bottom: solid;
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


</style>