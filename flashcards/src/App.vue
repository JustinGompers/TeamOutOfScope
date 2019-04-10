<template>
  <div id="app">
    <h1 id="title">Flashy Cards</h1>
    <img id="logo" src="./assets/flashed-clipart-running.gif">
    <login></login>
    <registration></registration>
    <card></card>
  </div>


</template>

<script>
<<<<<<< HEAD
=======
//import HelloWorld from './components/HelloWorld.vue'
>>>>>>> c8551b15247ba13527162d955a253bc46236cda9
import Card from './components/Card.vue'
import Login from './components/Login.vue'
import Registration from './components/Registration.vue'

export default {
  name: 'app',
  components: {
    Card,
    Login,
    Registration
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
