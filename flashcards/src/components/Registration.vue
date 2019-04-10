<template>
    <div class= "RegistrationSection">    
        <button id="RegistrationButton" v-on:click.prevent="ShowRegistrationForm = true" v-if="ShowRegistrationForm== false">Register</button>

        <form @submit.prevent="Submit(User)" id="formLogin" v-if="ShowRegistrationForm === true">
            <div>
                <label>Email:</label>
                <input type="email" v-model="User.email" id="email" name="email" placeholder="Enter your email">
            </div>
            <div>
                <label>Password: </label>
                <input type="text" v-model="User.password" id="Registration-password" name="password" placeholder="Enter your password">
            </div>
            <div>
                <label>Password2: </label>
                <input type="text" v-model="password2" name="password2" placeholder="Confirm your passoword.">
            </div>
            <div>
                <label>First name: </label>
                <input type="text" v-model="User.firstName" name="FirstName" placeholder="Enter your first name.">
            </div>
            <div>
                <label>Last name: </label>
                <input type="text" v-model="User.lastName" name="LastName" placeholder="Enter your last name.">
            </div>
            <button>Submit</button>
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
            apiURL: 'https://localhost:44337/api/values',
            password2: '',
            User: {
                email: '',
                password: '',
                firstName: '',
                lastName: ''
        },
        }
    },
    methods: {
    Submit(User) {
        //this.$validator.validateAll()
        //if(!this.errors.any()){
        //alert('submit')
        //}
        fetch(this.apiURL, {
        method: 'POST',
        body: JSON.stringify(User),
        mode: 'no-cors'
        }).then(function(response) {
            console.log(JSON.stringify(User))
        }).catch(err => {
            err
        });
    },
        checkForm: function (e) {
      this.errors = [];

      if (!this.password) {
        this.errors.push(" required.");
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
    
    }
}
</script>

<style lang="scss" scoped>
</style>