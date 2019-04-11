<template>
  <div id="app">
    <fixed-header>
      <div id='header'>
        <img id="logo" src="./assets/flashed-clipart-running.gif">
        <h1 id="title">Flashy Cards</h1>
        <img id="logo" src="./assets/reverse-flash.gif">
      </div>
    </fixed-header>
    <div class='content'>
      <login></login>
      <registration></registration>
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

export default {
  name: 'app',
  components: {
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
#header{
  display: flex;
  justify-content: center;
  background: black;
  color:white;
  
}
#logo{
  width: 5vw;
  height: 5vw;
}
#title{
  font-size: 3vw;
}
</style>
