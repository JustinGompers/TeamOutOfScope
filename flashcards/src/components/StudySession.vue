<template>
<div>
    <h2>This is the start of the Study Session</h2>

    <button id="start-study-session" v-on:click.prevent="show()">Start Study Session</button>

    <modal id="study-session-form" name="startStudySession" :width="600" :height="225">
        <div id="modal-header">
            <h2>Study Session</h2>
        </div>
            <div id="modal-body">  
                <form id="formCreateDeck">
                    <div id="deck-options">
                        <span id="decks">Choose the deck for your study session:</span>
                        <select id="user-decks" v-validate="'required|min_value:1'" v-on:click.prevent="viewDecks()" v-model="category_id" name="user-deck-options">
                            <option disabled value=0>Please Select a Deck</option>
                            <option v-for="deck in userDecks" v-bind:key="deck.name" :value="deck.deckId"> {{deck.name}} </option>     
                        </select>
                        <span>{{ errors.first('user-deck-options') }}</span>
                    </div>
                    <div id=buttons>
                        <button id="submitLoginButton" v-on:click.prevent="getDeck">Submit</button>
                        <button id="cancelLoginButton" v-on:click.prevent="hide()">Cancel</button>
                    </div>   
                </form> 
        </div>
    </modal>



</div>
</template>

<script>
export default {
    name: 'StudySession',

    props: {
        user: {
            type: Number,
            required: true,
            default: 0
        }
    },

    data () {
        return {
            userId: 0,
            deckId: 0,
            name: '',
            beginStudySession: false,
            userCards: [],
            rightDeck: [],
            wrongDeck: [],
            apiURL: "https://localhost:44337/api/deck"
        }
    },

    methods: {         
        getCards(){
            fetch("https://localhost:44337/api/Card/" + this.user, {
                method: 'GET',
                mode: 'no-cors'
                })
                .then(response => {
                    return response.json();
                })
                 .then(data => {
                    this.userCards = data;
                })
                .catch(e => console.log(e));
        },
        show(){
            beginStudySession: true;
             this.$modal.show('startStudySession');
        },
        hide(){
             this.$modal.hide('startStudySession');
        }
    }

}
</script>

<style>

</style>


