<template>
<div class="study-session-section">
    <button id="study-session-button" v-on:click.prevent="show()">Study Session</button>

    <modal id="study-session-form" name="startStudySession" :width="600" :height="225">
        <div id="modal-header">
            <h2>Study Session</h2>
        </div>
            <div id="modal-body">  
                <form id="formCreateDeck">
                    <vue-flip>
                    <div id="deck-options">
                        <div :side="front">
                            <p v-if="isQuestion === true" >{{Cards[index].question}}</p>
                            <div id=buttons>
                            <button id="submitLoginButton" v-if="isQuestion === true" v-on:click.prevent="getCurrentCard()">Show Answer</button>
                            <button id="cancelLoginButton" v-if="isQuestion === true" v-on:click.prevent="hide()">Leave Session</button>
                            </div> 
                        </div>
                        <p v-if="isQuestion === false" >{{Cards[index].answer}}</p>
                        <p v-if="isEnd === true">Right Answers: {{rightDeck.length}}</p>
                        <p v-if="isEnd === true">Wrong Answers: {{wrongDeck.length}}</p>
                        <span>{{ errors.first('user-deck-options') }}</span>
                    </div>
                    <div id=buttons>
                        <button id="submitLoginButton" v-if="isQuestion === false" v-on:click.prevent="addToRightList()">I got it right!</button>
                        <button id="cancelLoginButton" v-if="isQuestion === false" v-on:click.prevent="addToWrongList()">I feel shame :(</button>
                        <button id="submitLoginButton" v-if="isQuestion === true" v-on:click.prevent="getCurrentCard()">Show Answer</button>
                        <button id="cancelLoginButton" v-if="isQuestion === true" v-on:click.prevent="hide()">Leave Session</button>
                    </div>   
                    </vue-flip>
                </form> 
        </div>
    </modal>
</div>
</template>

<script>
import VueFlip from 'vue-flip';
export default {
    name: 'StudySession',
     components:{
        'vue-flip': VueFlip
    },
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
            isEnd: false,
            isQuestion: true,
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
            if(this.index < this.Cards.length-1)
            {
            this.index++;
            }
            else{
                this.isEnd = true;
            }
        },
        addToRightList(item){
            this.rightDeck.push(item);
        },
        addToWrongList(item){
            this.wrongDeck.push(item);
        }
        
    }

}
</script>

<style>
.study-session-section{
display: inline;
}
#study-session-button{
width: 150px;
height: 50px;
background: #800020;
font-style: bold;
font-size: 15pt;
color: white;
cursor: pointer;
}
</style>


