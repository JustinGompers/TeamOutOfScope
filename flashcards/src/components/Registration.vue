<template>
    <div class= "RegistrationSection">    
        <button id="RegistrationButton" v-on:click.prevent="ShowRegistrationForm = true" v-if="ShowRegistrationForm== false">Register</button>

        <form @submit="checkForm" id="formLogin" v-if="ShowRegistrationForm === true">
            <div>
                <label>Email:</label>
                <input type="email" v-model="email" id="email" placeholder="Enter your email">
            </div>
            <div>
                <label>Password: </label>
                <input type="text" v-model="password" id="Registration-password" placeholder="Enter your password">
            </div>
            <div>
                <label>Password2: </label>
                <input type="text" v-model="password2" placeholder="Confirm your passoword.">
            </div>
            <div>
                <label>First name: </label>
                <input type="text" v-model="firstName" placeholder="Enter your first name.">
            </div>
            <div>
                <label>Last name: </label>
                <input type="text" v-model="lastName" placeholder="Enter your last name.">
            </div>
            <button @click="Submit()">Submit</button>
            <button id="cancelRegistrationButton" v-on:click.prevent="ShowRegistrationForm = false">Cancel</button>
        </form>
    </div>
</template>

<script>
export default {
    name: "Registration",
    
    data(){
        return {
            errors: [],
            ShowRegistrationForm: false,
            email: null,
            password: null,
            password2: null,
            firstName: null,
            lastName: null
        }
    },
    methods: {
        checkForm: function (e) {
      this.errors = [];

      if (!this.password) {
        this.errors.push("Name required.");
      }
      if (!this.password2) {
        this.errors.push("Name required.");
      }
      if (!this.firstName) {
        this.errors.push("Name required.");
      }
      if (!this.lastName) {
        this.errors.push("Name required.");
      }
      if (!this.email) {
        this.errors.push('Email required.');
      } else if (!this.validEmail(this.email)) {
        this.errors.push('Valid email required.');
      }

      if (!this.errors.length) {
        return true;
      }
      e.preventDefault();
    },
    validEmail: function (email) {
            var re = /^(([^<>()\[\]\\.,;:\s@"]+(\.[^<>()\[\]\\.,;:\s@"]+)*)|(".+"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/;
            return re.test(email);
    },
    Submit() {
      this.$validator.validateAll()
      if (!this.errors.any()) {
        alert('submit')
      }
    }
    }
}
</script>

<style lang="scss" scoped>
</style>