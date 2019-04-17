<template>
    <div class= "RegistrationSection">    
        <a id="RegistrationButton" v-on:click.prevent="show()">Register</a>
        <modal id='form' name="Cards" :width="600" :height="300">
            <div id="modal-header">
                <h2>Register Form</h2>
            </div>
            <div id="modal-body">
            <form id="formLogin" @submit.prevent="Button">
                <div id="body">
            <div id="E">
                <label>Email:</label>
                <input type="email" v-validate="'required|email'" v-model="User.userName" id="email" name="userName" placeholder="Enter your email">
                <span>{{ errors.first('userName') }}</span>
            </div>
            <div id="P">
                <label>Password: </label>
                <input type="text" v-validate="'required|min:8'" v-model="User.password" id="Registration-password" name="password" ref="password" placeholder="Enter your password">
                <span>{{ errors.first('password') }}</span>
            </div>
            <div id="P2">
                <label>Password2: </label>
                <input type="text" v-validate="'required|confirmed:password'" v-model="password2" name="password2" placeholder="Confirm your passoword.">
                <span>{{ errors.first('password2') }}</span>
            </div>
            <div id="FN">
                <label>First name: </label>
                <input type="text" v-validate="'required'" v-model="User.firstName" name="firstName" placeholder="Enter your first name.">
                <span>{{ errors.first('firstName') }}</span>
            </div>
            <div id="LN">
                <label>Last name: </label>
                <input type="text" v-validate="'required'" v-model="User.lastName" name="lastName" placeholder="Enter your last name.">
                <span>{{ errors.first('lastName') }}</span>
            </div>
            </div>
            <div id="buttons">
                <button @click="hide()">Submit</button>
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
            apiURL2: 'https://localhost:44337/api/values',
            password2: '',
            User: {
                userName: '',
                firstName: '',
                lastName: '',
                password: ''
            },
            Userlogged: {}
        }
    },
    methods: {
    Button(){
      this.$validator.validateAll().then((result) => {
        if (result) {
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
            this.apiURL2 = this.apiURL2 + "/" + this.User.userName + "/" + this.User.password;
            this.User.userName = '';
            this.User.firstName = '';
            this.User.lastName = '';
            this.User.password = '';
            this.password2 = '';
            this.$modal.hide('Form');
            alert('Your form has been sumbitted welcome to FlashyCard family!');
            fetch(this.apiURL2,{
                method: 'GET'
                })
                .then(response => {
                    return response.json();
                })
            //assign the user objects from the DB to the users array defined in this component
                .then(data => {
                    this.Userlogged = data;
                    console.log(this.Userlogged.userId);
                    if (this.Userlogged.userId > 0){
                        this.showSuccessMsg = true;
                        this.$emit('registeredUser', this.Userlogged);
                        this.$modal.hide('Cards');
                        console.log("This worked.");
                    }
                    //otherwise emit empty object titled noUserFound
                    else {
                        this.showFailMsg = true;
                        this.$emit('noUserFound', this.Userlogged); 
                        console.log("This DID NOT work!");
                    }
                })
                .catch(e => {
                    console.log(e);
                });
        }else{
            alert('Your form has missing fields.  Please fill out to register.');
        }
      });
    },
        validEmail: function (email) {
            var re = /^(([^<>()\[\]\\.,;:\s@"]+(\.[^<>()\[\]\\.,;:\s@"]+)*)|(".+"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/;
            return re.test(email);
        },
        show(){
            this.$modal.show('Cards');
        },
        hide(){
            this.$modal.hide('Cards');
        },
        getUser(){
            
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
div input{
    align-items: center;
}
#RegistrationButton{
    font-size: 24pt;
}
#E label{
    padding-right: 54px;
}
#P label{
    padding-right: 11px;
}
#FN label{
    padding-right: 4px;
}
#LN label{
    padding-right: 5px;
}
div span{
    font-size: 8pt;
    color: red;
}
</style>