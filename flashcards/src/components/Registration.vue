<template>
    <div class= "RegistrationSection">    
        <button id="RegistrationButton" v-on:click.prevent="ShowRegistrationForm = true" v-if="ShowRegistrationForm== false">Register</button>

        <form @submit.prevent="Button()" id="formLogin" v-if="ShowRegistrationForm === true">
            <div>
                <label>Email:</label>
                <input type="email" v-validate="'required|email'" v-model="User.userName" id="email" name="userName" placeholder="Enter your email">
                <span>{{ errors.first('userName') }}</span>
            </div>
            <div>
                <label>Password: </label>
                <input type="text" v-validate="'required|min:8'" v-model="User.password" id="Registration-password" name="password" ref="password" placeholder="Enter your password">
                <span>{{ errors.first('password') }}</span>
            </div>
            <div>
                <label>Password2: </label>
                <input type="text" v-validate="'required|confirmed:password'" v-model="password2" name="password2" placeholder="Confirm your passoword.">
                <span>{{ errors.first('password2') }}</span>
            </div>
            <div>
                <label>First name: </label>
                <input type="text" v-model="User.firstName" name="firstName" placeholder="Enter your first name.">
            </div>
            <div>
                <label>Last name: </label>
                <input type="text" v-model="User.lastName" name="lastName" placeholder="Enter your last name.">
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
            error: [],
            ShowRegistrationForm: false,
            apiURL: 'https://localhost:44337/api/values',
            password2: '',
            User: {
                userName: '',
                firstName: '',
                lastName: '',
                password: ''
        },
        }
    },
    methods: {
    Button() {
      this.$validator.validateAll().then((result) => {
        if (result) {
            alert('Form Submitted!');
          let reg = document.getElementById("formLogin")
            let person = new FormData(reg)
            fetch(this.apiURL, {
                method: 'POST',
                body: person,
                mode: 'no-cors',
                headers: {
                    'Content-Type': 'application/json'
                }
            })
            .catch(err => {
                err
            });
        }else{
            alert('Correct them errors!');
        }
      });
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