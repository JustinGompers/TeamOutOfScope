<template>
<div class="study-session-section">
    <button id="study-session-button" v-on:click.prevent="show()">Study Session</button>

    <modal id="study-session-form" name="startStudySession" :width="600" :height="325">
        <div id="modal-header">
            <h2>Study Session</h2>
        </div>    
            <div id="modal-body">  

                        <vue-flip :active-click="true" width="500px" height="200px" v-if="isEnd === false" id="card">
                        <div slot="front">
                            <p id="cardText">{{Cards[index].question}}</p>
                            <div id=buttons>
                                <button id="oneButton" v-on:click.prevent="hide()">Leave Session</button>
                            </div> 
                        </div>
                        <div slot="back">
                            <p id="cardText">{{Cards[index].answer}}</p>
                            <div id=buttons>
                                <button id="threeButton" v-on:click.prevent="addToRightList(Cards[index])">I got it right!</button>                               
                                <button id="threeButton" v-on:click.prevent="addToWrongList(Cards[index])">I feel shame :(</button>
                                <button id="threeButton" v-on:click.prevent="hide()">Leave Session</button>
                            </div>
                        </div>
                        </vue-flip>

                        <p v-if="isEnd === true">Right Answers: {{rightDeck.length}}</p>
                        <p v-if="isEnd === true">Wrong Answers: {{wrongDeck.length}}</p>
                        <div id=buttons>
                                <button id="twoButton" v-if="isEnd === true" v-on:click.prevent="show()">Review Deck Again</button>
                                <button id="twoButton" v-if="isEnd === true" v-on:click.prevent="hide()">Leave Session</button> 
                        </div>
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
            apiURL: "https://localhost:44337/api/deck"
        }
    },

    methods: {         
        show(){
             this.$modal.show('startStudySession');
             this.index = 0;
             this.isEnd = false;
             this.rightDeck = [];
             this.wrongDeck = [];
        },
        hide(){
             this.$modal.hide('startStudySession');
        },
        addToRightList(item){
            if(this.index < this.Cards.length-1){
            this.rightDeck.push(item);
            this.index++;
            }else{
                this.rightDeck.push(item);
                this.isEnd = true;
            }
        },
        addToWrongList(item){
           if(this.index < this.Cards.length-1){
            this.wrongDeck.push(item);
            this.index++;
            }else{
                this.wrongDeck.push(item);
                this.isEnd = true;
            }
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
.flipcard p{
    font-size: 22pt;
}
.flipcard{
    padding-left: 50px;
}
.front {
    display: flex;
    align-items: center;
    justify-content: center;
    background-color: #FF983E;
    color: white;
}

.back {
    display: flex;
    align-items: center;
    justify-content: center;
    background-color: #800020;
    color: white
}
#oneButton{
    margin-left: 50px;
    text-align: center;
    width: 500px;
    background:  #FF983E;
    color: white;
    border: solid #800020;
    height: 35px;
}
#threeButton{
    margin-left: 50px;
    text-align: center;
    width: 166px;
    background: black;
    color: white;
    border: solid #FF983E;
    height: 35px;
}
#twoButton{
    margin-left: 50px;
    text-align: center;
    width: 250px;
    background: black;
    color: white;
    border: solid #FF983E;
    height: 35px;
}
.flip-containter{
    height: 200px;
    width: 500px;
    padding-left: 50px;
    }
</style>


