<template>
<div>
<h2>This is the beginning of the Update Card Section.</h2>

<div class="UpdateCard">
    <button id="update-card-button" v-on:click.prevent="show()">Update Card</button>

    <!-- Add elements to search for the card you want to update -->


    <modal id='update-card-modal' name="update-card-modal" :width="600" :height="300">
            <div id="modal-header">
                <h2>Update Card Form</h2>
            </div>
            <div id="modal-body">

            <form id="update-card-form" @submit.prevent="Button">
                <div id="body">
                    <label>New Question: </label>
                    <input type="text" id="question" placeholder="if applicable" v-model="question" />
                </div>
                <div>
                    <label>New Answer: </label>
                    <input type="text" id="answer" placeholder="if applicable" v-model="answer" />
                </div>
                <div>
                    <label>New Image: </label>
                    <input type="text" id="image" placeholder="if applicable" v-model="image" />
                </div>
                <div>
                    <label>New Tags: </label>
                    <input type="text" id="tags" placeholder="if applicable" v-model="tags" />
                </div>

                <!-- add a hidden field that also passes through the deck id -->
                <div>
                    <button id="SubmitButton">Submit</button>
                    <button id="CancelButton" v-on:click.prevent="hide()">Cancel</button>
                </div>
            </form>
            </div>
            
      </modal>

</div>

</div>    
</template>

<script>
export default {
    name: 'UpdateCard',
    //HAVE TO SOMEHOW BIND THE CARD ID SO THE URL IN THE BUTTON METHOD WORKS CORRECTLY
    cardId: 0,
    question: '',
    answer: '',
    image: '',
    tags: '',
    apiURL: "https://localhost:44337/api/Card",


    methods: {
        show(){
            this.$modal.show('update-card-modal');
        },
        hide(){
            this.$modal.hide('update-card-modal');
        },

        Button() {
        //NOT SURE IF THIS NEEDS ADJUSTED BECAUSE FIELDS IN UPDATE CARD FORM ABOVE ARE OPTIONAL AND NOT REQUIRED
         this.$validator.validateAll().then((result) => {
             if (result) {
          let cardUpdate = document.getElementById("update-card-form")
            let card = new FormData(cardUpdate)
            fetch(this.apiURL + "/" + this.cardId, {
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
            alert('Your update has been submitted!');
        }else{
            alert('Your update did not work.');
        }
    }
        }
    }
}

</script>

<style>

</style>


