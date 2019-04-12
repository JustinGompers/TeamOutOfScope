<template>
    <div class= "RegistrationSection">    
        <a id="RegistrationButton" v-on:click.prevent="show()">Register</a>
        <modal id='form' name="Form" :width="600" :height="400" @submit.prevent="Button()">
            <div id="modal-header">
                <h2>Register Form</h2>
            </div>
            <div id="modal-body">
            <form id="formLogin">
                <div id="body">
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
            </div>
            <div id="buttons">
                <button @submit.prevent="Button()">Submit</button>
                <button id="cancelRegistrationButton" v-on:click.prevent="hide()">Cancel</button>
            </div>
         </form>
        </div>
        </modal>

    </div>
</template>

<script>
export default {
    name: "Registration",
    
    data(){
        return {
            error: [],
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
          let reg = document.getElementById("formLogin")
            let person = new FormData(reg)
            fetch(this.apiURL, {
                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                
                body: person,
                mode: 'no-cors',
                headers: {
                    'Content-Type': 'application/json'
                }
            })
            .catch(err => {
                err
            });
            this.User.userName = '';
            this.User.firstName = '';
            this.User.lastName = '';
            this.User.password = '';
            this.password2 = '';
            this.ShowRegistrationForm = false;
            alert('Your form has been sumbitted welcome to FlashyCard family!');
        }else{
            this.$modal.hide('Form');
        }
      });
    },
        validEmail: function (email) {
            var re = /^(([^<>()\[\]\\.,;:\s@"]+(\.[^<>()\[\]\\.,;:\s@"]+)*)|(".+"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/;
            return re.test(email);
        },
        show(){
            this.$modal.show('Form');
        },
        hide(){
            this.$modal.hide('Form');
        }
    }
}
</script>

<style>
#RegistrationButton{
    Color: white;
    border-bottom: solid;
}
#modal-header{
    text-align: center;
    background: lightblue;
}
#body{
    padding-left: 10px;
}
#buttons{
    display: flex;
    justify-content: center;
    justify-content: space-around;
    padding-top: 5px;
}
#buttons button{
        background: #800020;
        color: white;
        width: 300px;
        height: 50px;
        font-size: 25px;
        cursor: pointer;
}
#form{
}
div input{
    align-items: center;
}
</style>