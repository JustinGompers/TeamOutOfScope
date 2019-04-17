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
              <div>
              <About></About>
              </div>
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
                  <span>{{ this.User.firstName }} {{ this.User.lastName }} {{ this.User.userId }}</span>
              </div>
              <div id="Deck" v-if="this.User.userName">
                  <Card v-if="this.ChosenDeck.deck_id" :ID=this.ChosenDeck.deck_id @addCard="addedCard"></Card>
                  <SearchCard v-if="this.ChosenDeck.deck_id"></SearchCard>
                  
                </div>
            </div>
          </a>
        </Slide>
        
        
      </div>
    </fixed-header>
    <div class='content' v-if="this.User.userName">
      <div class="choices">
        <Deck :ID=this.User.userId @addDeck="addedDeck" v-if="!this.SelectedDeck"></Deck>
        <button class="selectbar" v-if="!this.SelectedDeck" @click="Selected">Select Deck</button>
        <button class="selectbar" v-if="this.SelectedDeck" @click="SelectedDeck = 0">Return to Decks</button>
        <StudySession v-if="this.SelectedDeck" :user=this.User.userId :Cards=this.Cards :Deck=this.ChosenDeck></StudySession>
        <UpdateCard v-if="this.SelectedDeck" :chosenCard=this.ChosenCard.cardID @updateCard="addedCard"></UpdateCard>
        <ViewCard v-if="this.SelectedDeck" :Card=this.ChosenCard></ViewCard>
        </div>
      <h2 v-if="this.SelectedDeck">{{this.ChosenDeck.deckName}} Cards</h2>
       <ViewDeckCards :DID=this.ChosenDeck.deck_id v-if="this.SelectedDeck" :ADD=this.CardAdded @cardData="GroupCards" @chosenCard="getCardInfo"></ViewDeckCards>
       <ViewUserDecks v-if="!this.SelectedDeck && this.User.userName" :ID=this.User.userId @chosenDeck="getDeckInfo" @DeckCards="getCards" :ADD=this.DeckAdded></ViewUserDecks>
      </div>
      
      
      
      
      <UpdateDeck></UpdateDeck>
      <div id="PubDecks">
        <ul class="decks">
          </ul>
        </div>
        
        <footer id="footer">&copy; 2019 FlashyCards.com</footer>
        <footer id="footerslogan"> 	&trade;"Learning is FUNdamental"</footer>
        
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

// Vue.components('Deck', {
//   props: ['UserId'],
//   watch: {
//     UserId(newValue, oldValue) {

//     }
//   }
// })

export default {
    beforeCreate() {
        console.log('Im First');
        /*
        fetch(this.apiUrl, {
          method: 'GET'
        })
        .then(response => {
          return response.json();
        })
        .then(data => {
          this.PublicDecks = data;
          console.log(this.PublcDecks);
        })
        */
    },
  name: 'app',
  components: {
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
      SelectedCard: 0
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
    }
  }
}
</script>

<style>
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
