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
                        <p v-bind="currentCard">{{currentCard.Answer}}</p> 
                        <span>{{ errors.first('user-deck-options') }}</span>
                    </div>
                    <div id=buttons>
                        <button id="submitLoginButton" v-on:click.prevent="getCurrentCard()">Next</button>
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
        },
        Cards: {
            type: Array,
            required: true,
        },
        Deck: {
            type: Object,
            required: true,
        }
    },

    data () {
        return {
            userId: 0,
            deckId: 0,
            name: '',
            index: 0,
            beginStudySession: false,
            rightDeck: [],
            wrongDeck: [],
            currentCard: this.Cards[index],
            apiURL: "https://localhost:44337/api/deck"
        }
    },

    methods: {         
        show(){
             this.$modal.show('startStudySession');
        },
        hide(){
             this.$modal.hide('startStudySession');
        },
        getCurrentCard(){
            if(this.index < this.Cards.length){
            this.index++;}
        }
    }

}
</script>

<style>

</style>


