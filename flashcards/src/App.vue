<template>
  <div id="app">
    <fixed-header>
      <div id='header'>
        <div id='main'>
          
          <img id="logo" src="./assets/flashed-clipart-running.gif">
          <img id="title" src="./assets/Flashlogo.png">
          <img id="logo" src="./assets/reverse-flash.gif">
        </div>
        <Slide disableOutsideClick>
          <a id="home" href="#">
            <div id='hamburgers'>
              <div>
            
            </div>
              <img id="menu" src="./assets/FlashyMenu.png">
              <br>

              <div id="login" v-if="!this.User.userName">
              <login @confirmedUser="getUserInfo"></login>
              </div>
              <div id="register" v-if="!this.User.userName">
              <registration @registeredUser="getRegisteredUser"></registration>
              </div>
              <div id="LoggedUser" v-if="this.User.userName">
                <div>
                  <img id="userPhoto" src="./assets/normalpic.jpg">
                  </div>
                  <p class="User">{{ this.User.firstName }} {{ this.User.lastName }}</p>
              </div>
                  <div v-if="this.User.userName">
                  <button class="logout" @click="UserReset">Logout</button>
                  </div>
                  <div id="about">
                  <About></About>
                  </div>
            </div>
          </a>
        </Slide>
        
        
      </div>
    </fixed-header>
    <div class='content'>
      <div id="SelectDeck">
      <button v-if="!this.SelectedDeck.deck_id" class="selectbar" @click="Selected">Select Deck</button>
      </div>
      <div class="choices" v-if="this.User.userName || this.SelectedDeck.deck_id">
        <UpdateDeck v-if="!this.SelectedDeck.deck_id && !this.ChosenPublicDeck.deck_id" :chosenDeck=this.SelectedDeck.deck_id @deck-update="addedDeck"></UpdateDeck>
        <SearchCard v-if="this.SelectedPublic === false && this.SelectedDeck.deck_id" :DID=this.SelectedDeck.deck_id @CardTagAdded="addedCard"></SearchCard>
        <Card v-if="this.SelectedDeck.deck_id && this.SelectedPublic === false" :ID=this.SelectedDeck.deck_id @addCard="addedCard"></Card>
        <Deck :ID=this.User.userId @addDeck="addedDeck" v-if="!this.SelectedDeck.deck_id && !this.ChosenPublicDeck.deck_id"></Deck>
        <StudySession v-if="this.SelectedDeck.deck_id" :user=this.User.userId :Cards=this.Cards :Deck=this.SelectedDeck></StudySession>
        <UpdateCard v-if="this.SelectedDeck.deck_id && this.SelectedPublic === false" :chosenCard=this.ChosenCard.cardID @updateCard="addedCard"></UpdateCard>
        <ViewCard v-if="this.SelectedDeck.deck_id" :Card=this.ChosenCard></ViewCard>
        <button class="selectbar" v-if="this.SelectedDeck.deck_id" @click="Return">Return</button>
        </div>
      <h2 v-if="this.SelectedDeck.deck_id">{{this.SelectedDeck.deckName}} Cards</h2>
       <ViewDeckCards :DID=this.SelectedDeck.deck_id v-if="this.SelectedDeck.deck_id" :ADD=this.CardAdded @cardData="GroupCards" @chosenCard="getCardInfo"></ViewDeckCards>
       <ViewUserDecks v-if="this.User.userName && !this.SelectedDeck.deck_id" :ID=this.User.userId @chosenDeck="getDeckInfo" @DeckCards="getCards" :ADD=this.DeckAdded :Change=this.ChosenPublicDeck.deck_id></ViewUserDecks>
      </div>
      
      
      
      


        <div v-if="!this.SelectedDeck.deck_id">
        <img class="public" src="./assets/publicdecks.png">
        <div id="Decks">
            <span v-for="deck in PublicDecks" v-bind:key="deck.deck_id" :value="deck">
                <div class="decklist">
                <img src="./assets/cards.png">
                <button @click="SelectedPublicDeck(deck)" :class="{'active': deck.deck_id == ChosenPublicDeck.deck_id}"> {{deck.deckName}}</button>
                </div>
            </span>
        </div>
    </div>
    <div id="bottom">
        <footer id="footer">&copy; 2019 FlashyCards.com</footer>
        <footer id="footerslogan"> 	&trade;"Learning is FUNdamental"</footer>
        </div>
    </div>


</template>

<script>
//import HelloWorld from './components/HelloWorld.vue'
import Card from './components/Card.vue'
import About from './components/About.vue'
import Login from './components/Login.vue'
import ViewDeckCards from './components/ViewDeckCards.vue'
import Registration from './components/Registration.vue'
import Deck from './components/Deck.vue'
import ViewUserDecks from './components/ViewUserDecks.vue'
import StudySession from './components/StudySession.vue'
import SearchCard from './components/SearchCard.vue'
import UpdateCard from './components/UpdateCard.vue'
import ViewCard from './components/ViewCard.vue'
import UpdateDeck from './components/UpdateDeck.vue'
import FixedHeader from 'vue-fixed-header'
import { Slide } from 'vue-burger-menu'
import VueFlip from 'vue-flip';
import { setTimeout } from 'timers';

// Vue.components('Deck', {
//   props: ['UserId'],
//   watch: {
//     UserId(newValue, oldValue) {

//     }
//   }
// })

export default {
    created() {
        console.log('Im First');
        
        fetch("https://localhost:44337/api/deck/Public", {
          method: 'GET'
        })
        .then(response => {
          return response.json();
        })
        .then(data => {
          this.PublicDecks = data;
          console.log(this.PublcDecks);
        })
        
    },
  name: 'app',
  components: {
    'vue-flip': VueFlip,
    Slide,
    FixedHeader,
    Card,
    Login,
    Registration, 
    Deck,
    About,
    SearchCard,
    StudySession,
    ViewUserDecks,
    ViewDeckCards,
    UpdateCard,
    ViewCard,
    UpdateDeck
  },
  data() {
    return {
      User: {},
      Deck: [],
      ChosenUserDeck: {},
      ChosenPublicDeck: {},
      ChosenCard: {},
      Cards: [],
      PublicDecks: [],
      showDecks: false,
      CardAdded: false,
      DeckAdded: false,
      SelectedDeck: {},
      SelectedCard: 0,
      SelectedPublic: false,
      apiURL: "https://localhost:44337/api/deck/user/1"
    }
  },
  methods: {
    getUserInfo(UserInfo){
      this.User = UserInfo;
    },
    getRegisteredUser(UserInformation){
      this.User = UserInformation;
    },
    getDeckInfo(DeckInfo){
      this.ChosenUserDeck = DeckInfo;
      this.ChosenPublicDeck = {};
    },
    getCards(DeckCards){
      this.Cards = DeckCards;
    },
    addedCard(){
      this.CardAdded = !this.CardAdded
    },
    addedDeck(){
      this.DeckAdded = !this.DeckAdded
      setTimeout(() =>
      fetch("https://localhost:44337/api/deck/Public", {
          method: 'GET'
        })
        .then(response => {
          return response.json();
        })
        .then(data => {
          this.PublicDecks = data;
          console.log(this.PublcDecks);
        }), 500)
    },
    GroupCards(Group){
        this.Cards = Group;
    },
    Selected(){
      if(this.ChosenUserDeck.deck_id){
        this.SelectedDeck = this.ChosenUserDeck
      }else{
        this.SelectedDeck = this.ChosenPublicDeck
      }
    },
    getCardInfo(card){
      this.ChosenCard = card;
    },
    UserReset(){
      this.User = {};
    },
    SelectedPublicDeck(Deck){
      this.ChosenPublicDeck = Deck;
      this.ChosenUserDeck = {};
      this.SelectedPublic = true;
    },
    Return(){
      this.SelectedDeck = 0;
      this.SelectedPublic = false;
    }
  }
}
</script>

<style>
#about{
  padding-top: 10px;
}
.choices{
  display: inline;
}
#SelectDeck{
  display:inline;
}
#bottom{
  padding-top: 150px;
}
.decklist .active{
    background-color: red;
}
.logout{
  width: 200px;
  height: 30px;
  font-size: 15pt;
  color: white;
  background: black;
  border: solid #FF983E;
  cursor: pointer;
}
.User{
  color: white;
  font-size: 16pt;
}
.public{
  width: 25%;
}
html{
  background: #FF983E;
}
.selectbar{
    width: 150px;
    height: 50px;
    background: #800020;
    font-style: bold;
    font-size: 15pt;
    color: white;
    cursor: pointer;
}
#app {
  font-family: 'Avenir', Helvetica, Arial, sans-serif;
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
  text-align: center;
  color: #2c3e50;
  background: #FF983E;
}
#header.vue-fixed-header--isFixed {
  position: fixed;
  left: 0;
  top: 0;
  width: 100vw;
}
#main{
  display: flex;
  color:white;
}
#header{
  display:flex;
  background: black;
  justify-content: center;
}
#logo{
  width: 7vw;
  height: 7vw;
}
#title{
  width: 30vw;
  height: 10vw;
}
.bm-burger-bars {
  background-color: white;
}
.bm-menu{
  height: 400px;
  background-color: #800020;
  transition: 0.0s;
}
.bm-item-list{
  margin-left: 5%;
}
.bm-item-list > *{
  padding: 0.0em;
}
#hamburgers{
  display: inline;
}
#hamburgers h2{
  font-size: 200%;
  color: white;
  background: black;
  border: solid black;
  border-radius: 4px;
}
li{
  margin-left: 5%;
}
#register{
  padding-top: 15px;
}
#menu{
  width: 95%;
  border-bottom: solid black 5pt;
}
#userPhoto{
  padding-top: 10px;
  border-radius: 125px;
  width: 50%;
}
#LoggedUser{
  color: white;
}
#Card{
  padding-top: 15px;
}
#login{
  padding-top: 10px;
}
</style>
