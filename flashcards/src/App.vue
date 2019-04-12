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
              <h2>Flashy Menu {{ User.userId }}</h2>
              <registration @registeredUser="getRegisteredUser"></registration>
            </div>
          </a>
        </Slide>
        
      </div>
    </fixed-header>
    <div class='content' v-if="User != {}">
      <login @confirmedUser="getUserInfo"></login>
      <Card></Card>
      <Deck></Deck>
    </div>
  </div>


</template>

<script>
//import HelloWorld from './components/HelloWorld.vue'
import Card from './components/Card.vue'
import Login from './components/Login.vue'
import Registration from './components/Registration.vue'
import Deck from './components/Deck.vue'
import FixedHeader from 'vue-fixed-header'
import { Slide } from 'vue-burger-menu'

export default {
  name: 'app',
  components: {
    Slide,
    FixedHeader,
    Card,
    Login,
    Registration, 
    Deck
  },
  data() {
    return {
      User: {}
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
  background: lightblue;
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
  height: 40%;
  background-color: #800020;
  transition: 0.5s;
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
</style>
