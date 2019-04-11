<template>
  <div id="app">
    <fixed-header>
      <div id='header'>
        <div id='main'>
          <img id="logo" src="./assets/flashed-clipart-running.gif">
          <h1 id="title">Flashy Cards</h1>
          <img id="logo" src="./assets/reverse-flash.gif">
        </div>
        <Slide disableOutsideClick>
          <a id="home" href="#">
            <div id='hamburgers'>
              <h2>Flashy Menu</h2>
              <login></login>
              <registration></registration>
            </div>
          </a>
        </Slide>
        
      </div>
    </fixed-header>
    <div class='content'>

      <card></card>
      <deck></deck>
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
  width: 5vw;
  height: 5vw;
}
#title{
  font-size: 3vw;
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
