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
            <About></About>
            </div>
              <img id="menu" src="./assets/FlashyMenu.png">
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
                  <span>{{ this.User.firstName }} {{ this.User.lastName }}</span>
              </div>
              <div id="Card">
                  <Card></Card>
                </div>
            </div>
          </a>
        </Slide>
        
        
      </div>
    </fixed-header>
    <div class='content'>
      <Deck></Deck>
      <div id="PubDecks">
        <ul class="decks">
          </ul>
        </div>
        
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
import Registration from './components/Registration.vue'
import Deck from './components/Deck.vue'
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
    About
  },
  data() {
    return {
      User: {},
      PublicDecks: []
    }
  },
  methods: {
    getUserInfo(UserInfo){
      this.User = UserInfo;
    },
    getRegisteredUser(UserInformation){
      this.User = UserInformation;
    }
  }
}
</script>

<style>
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
