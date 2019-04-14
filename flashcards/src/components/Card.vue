<template>
    <div class= "CardSection">   
      <a id="CardButton" v-on:click.prevent="show()">Create Your Card</a>
      <modal id="Form" name="Form" :width="600" :height="165">
        <div id="modal-header">
                <h2>Create a Card Form</h2>
            </div>
            <div id="modal-body">
      <form id="formCard" @submit.prevent="Button" >

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
      </form>
      </div>
      </modal>
        <button id="SubmitButton">Submit</button>
        <button id="CancelButton" v-on:click.prevent="hide()">Cancel</button>
        
      
      
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
    }
    },

    show(){
            this.$modal.show('Form');
        },
        hide(){
            this.$modal.hide('Form');
        }
}


</script>


<style>

#CardButton{ 
  Color: white;
  border-bottom: solid;
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