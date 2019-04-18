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
      <button v-if="!this.SelectedDeck" class="selectbar" @click="Selected">Select Deck</button>
      </div>
      <div class="choices" v-if="this.User.userName || this.SelectedDeck">
        <UpdateDeck v-if="!this.SelectedDeck" :chosenDeck=this.ChosenDeck.deck_id @deck-update="addedDeck"></UpdateDeck>
        <SearchCard v-if="this.SelectedPublic === false && this.SelectedDeck"></SearchCard>
        <Card v-if="this.SelectedDeck && this.SelectedPublic === false" :ID=this.ChosenDeck.deck_id @addCard="addedCard"></Card>
        <Deck :ID=this.User.userId @addDeck="addedDeck" v-if="!this.SelectedDeck"></Deck>
        <StudySession v-if="this.SelectedDeck" :user=this.User.userId :Cards=this.Cards :Deck=this.ChosenDeck></StudySession>
        <UpdateCard v-if="this.SelectedDeck && this.SelectedPublic === false" :chosenCard=this.ChosenCard.cardID @updateCard="addedCard"></UpdateCard>
        <ViewCard v-if="this.SelectedDeck" :Card=this.ChosenCard></ViewCard>
        <button class="selectbar" v-if="this.SelectedDeck" @click="Return">Return</button>
        </div>
      <h2 v-if="this.SelectedDeck">{{this.ChosenDeck.deckName}} Cards</h2>
       <ViewDeckCards :DID=this.ChosenDeck.deck_id v-if="this.SelectedDeck" :ADD=this.CardAdded @cardData="GroupCards" @chosenCard="getCardInfo"></ViewDeckCards>
       <ViewUserDecks v-if="this.User.userName" :ID=this.User.userId @chosenDeck="getDeckInfo" @DeckCards="getCards" :ADD=this.DeckAdded></ViewUserDecks>
      </div>
      
      
      
      


        <div v-if="!this.SelectedDeck">
        <img class="public" src="./assets/publicdecks.png">
        <div id="Decks">
            <span v-for="deck in PublicDecks" v-bind:key="deck.deck_id" :value="deck">
                <div class="decklist">
                <img src="./assets/cards.png">
                <button @click="SelectedPublicDeck(deck)" :class="{'active': deck.deck_id == ChosenDeck.deck_id}"> {{deck.deckName}}</button>
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
        
        fetch("https://localhost:44337/api/deck/user/1", {
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
      ChosenDeck: {},
      ChosenCard: {},
      Cards: [],
      PublicDecks: [],
      showDecks: false,
      CardAdded: false,
      DeckAdded: false,
      SelectedDeck: 0,
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
      this.ChosenDeck = DeckInfo;
    },
    getCards(DeckCards){
      this.Cards = DeckCards;
    },
    addedCard(){
      this.CardAdded = !this.CardAdded
    },
    addedDeck(){
      this.DeckAdded = !this.DeckAdded
    },
    GroupCards(Group){
        this.Cards = Group;
    },
    Selected(){
      this.SelectedDeck = this.ChosenDeck.deck_id;
    },
    getCardInfo(card){
      this.ChosenCard = card;
    },
    UserReset(){
      this.User = {};
    },
    SelectedPublicDeck(Deck){
      this.ChosenDeck = Deck;
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
  height: 60%;
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
  width: 20vw;
  border-bottom: solid black 5pt;
}
#userPhoto{
  border-radius: 125px;
  width: 50%;
}
#LoggedUser{
  color: white;
}
#Card{
  padding-top: 15px;
}
</style>
