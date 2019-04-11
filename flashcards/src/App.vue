<template>
  <div id="app">
    <h1 id="title">Flashy Cards</h1>
    <img id="logo" src="./assets/flashed-clipart-running.gif">
    <login></login>
    <registration></registration>
    <card></card>
    <deck></deck>
  </div>


</template>

<script>
//import HelloWorld from './components/HelloWorld.vue'
import Card from './components/Card.vue'
import Login from './components/Login.vue'
import Registration from './components/Registration.vue'
import Deck from './components/Deck.vue'

export default {
  name: 'app',
  components: {
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
  margin-top: 60px;
  background: lightblue;
}
#logo{
  width: 25%;
}
#title{
  font-size: 600%;
}
</style>
