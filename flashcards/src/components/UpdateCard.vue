<template>
<div>
<h2>This is the beginning of the Update Card Section.</h2>

<div class="choose-card">
    <button id="choose-card-button" v-on:click.prevent="showUpdateCardForm()">Update Card</button>

    <modal id='update-card-modal' name="update-card-modal" :width="600" :height="300">
        <div id="modal-header">
            <h2>Update Card Form</h2>
        </div>

        <div id="modal-body">

            <form id="update-card-form" @submit.prevent="Button()">
                <div id="body">
                    <label>New Question: </label>
                    <input type="text" id="question" placeholder="if applicable" v-model="question" name="question"/>
                </div>
                <div>
                    <label>New Answer: </label>
                    <input type="text" id="answer" placeholder="if applicable" v-model="answer" name="answer"/>
                </div>
                <div>
                    <label>New Image: </label>
                    <input type="text" id="image" placeholder="if applicable" v-model="image" name="image" />
                </div>
                <div>
                    <label>New Tags: </label>
                    <input type="text" id="tags" placeholder="if applicable" v-model="tag" name="tag"/>
                </div>

                <!-- add a hidden field that also passes through the deck id 
                     also need to somehow bind this-need the deckId field in script section
                     to be populated first-->
                <div>
                    <!-- <input type="hidden" id="deck-id" v-model="deckId" /> -->
                    <!-- <input type="hidden" :value="this.chosenDeck" name="deck_id"/> -->
                    <input type="hidden" :value="4/*this.chosenCard*/" name="cardID" />
                </div>
                <div>
                    <button id="SubmitButton">Submit</button>
                    <button id="CancelButton" v-on:click.prevent="hideUpdateCardForm()">Cancel</button>
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

    data(){
        return {
    //HAVE TO SOMEHOW BIND THE CARD ID AND DECK ID SO THE URLs IN THE BUTTON METHOD WORKS CORRECTLY
    Card_id: 0,
    Deck_id: 0,
    question: '',
    answer: '',
    image: '',
    tag: '',
    apiURL: "https://localhost:44337/api/Card/4"
        }
    },

    // props: {
    //     chosenCard: {
    //         type: Number,
    //         required: true,
    //         default: 0
    //     }
    // },

    methods: {

        showUpdateCardForm(){
            this.$modal.show('update-card-modal');
        },

        hideUpdateCardForm(){
            this.$modal.hide('update-card-modal');
        },

        Button() {
         this.$validator.validateAll().then((result) => {
             if (result) {
          let cardUpdate = document.getElementById("update-card-form")
            let card = new FormData(cardUpdate)
            fetch("https://localhost:44337/api/Card/Update/4", {
                method: 'POST',
                body: card,
                mode: 'no-cors'                
            })
            .then(response => {
                return response.json();
            })
            .catch(err => {
                console.log(err)
            });
            this.question = '';
            this.answer = '';
            this.image = '';
            this.tags = '';
            alert('Your update has been submitted!');
        }else{
            alert('Your update did not work.  Please try again.');
        }
        })
    }
    }
}

</script>

<style>

</style>


