<template>
<div class="study-session-section">
    <button id="study-session-button" v-on:click.prevent="show()">Study Session</button>

    <modal id="study-session-form" name="startStudySession" :width="600" :height="325">
        <div id="modal-header">
            <h2>Study Session</h2>
        </div>    
            <div id="modal-body">  
                <div id="card-body">
                        <vue-flip :active-click="true" width="500px" height="200px" v-if="isEnd === false" id="card">
                        <div slot="front">
                            <p id="cardText">{{Cards[index].question}}</p>
                        </div>
                        <div slot="back">
                            <p id="cardText">{{Cards[index].answer}}</p>
                            <div id=backstudybuttons>
                                <button id="leftButton" v-on:click.prevent="addToRightList(Cards[index])">I got it right!</button>                               
                                <button id="rightButton" v-on:click.prevent="addToWrongList(Cards[index])">I feel shame :(</button>
                            </div>
                        </div>
                        </vue-flip>
                        </div>
                        
                        <div id="studyanswers">
                        <span id="right" v-if="isEnd === true">Right Answers: {{rightDeck.length}}</span>
                        <span id="wrong" v-if="isEnd === true">Wrong Answers: {{wrongDeck.length}}</span>
                        </div>
                        <div id=studysessionbuttons>
                                <button id="leftButton" v-if="isEnd === true" v-on:click.prevent="show()">Review Deck Again</button>
                                <button id="rightButton" v-if="isEnd === true" v-on:click.prevent="hide()">Leave Session</button> 
                        </div>
                        <div id=frontstudybuttons v-if="isEnd === false">
                                <button id="oneButton" v-on:click.prevent="hide()">Leave Session</button>
                        </div> 
            </div>
    </modal>
</div>
</template>

<script>
import VueFlip from 'vue-flip';
import { setTimeout } from 'timers';
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
            setTimeout(() =>{
            if(this.index < this.Cards.length-1){
            this.rightDeck.push(item);
            this.index++;
            }else{
                this.rightDeck.push(item);
                this.isEnd = true;
            }}, 220);
        },
        addToWrongList(item){
            setTimeout(() =>{
           if(this.index < this.Cards.length-1){
            this.wrongDeck.push(item);
            this.index++;
            }else{
                this.wrongDeck.push(item);
                this.isEnd = true;
            }}, 220)
        }        
    }

}
</script>

<style>
#card-body{
    padding-left: 50px;
}
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
 #frontstudybuttons #oneButton{
    margin-left: 50px;
    text-align: center;
    width: 500px;
    background:  #FF983E;
    color: white;
    border: solid #800020;
    height: 35px;
}
#backstudybuttons button{
    text-align: center;
    width: 166px;
    background: black;
    color: white;
    border: solid #FF983E;
    height: 35px;
}

#studysessionbuttons #leftButton{
    margin-left: 50px;
    text-align: center;
    width: 250px;
    background: #800020;
    color: white;
    border: solid #FF983E;
    height: 35px;
}
#studysessionbuttons #rightButton{
    text-align: center;
    width: 250px;
    background: #800020;
    color: white;
    border: solid #FF983E;
    height: 35px;
}
#studysessionbuttons{
    margin-top: 50px;
}
.flip-containter{
    height: 200px;
    width: 500px;
    padding-left: 50px;
    }
#cardText {
    text-align: center;
}
#backstudybutton #leftbutton{
    margin-left: 45px;
}
#studyanswers span{
    margin-left: 60px;
    color: black;
    font-size: 20pt;
}
#studyanswers #right{
    background: green;
    border: solid green;
}
#studyanswers #wrong{
    background: red;
    border: solid red;
}
</style>


