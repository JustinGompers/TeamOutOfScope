<template>
    <div class= "loginSection"> 
        <button id="loginButton" v-on:click.prevent="show()">Login</button>
        <modal id="form" name="Login" :width="600" :height="225">
            <div id="modal-header">
                <h2>Login Form</h2>
            </div>
            <div id="modal-body">
            <form id="formLogin" @submit.prevent="submitLogin">
                <div id="emailField" >
                    <label>Email:</label>
                    <input type="text" v-validate="'required|email'" id="login-email" name="userName" placeholder="Enter your email" v-model.trim="email"/>
                    <span>{{ errors.first('userName') }}</span>
                </div>
                <div id="passwordField">
                    <label>Password:</label>
                    <input type="password" v-validate="'required'" id="login-password" name="password" placeholder="Enter your password" v-model.trim="password"/>
                    <span>{{ errors.first('password') }}</span>
                </div>
                <div id="buttons">
                    <button id="submitLoginButton" >Submit</button>
                    <button id="cancelLoginButton" v-on:click.prevent="hide()">Cancel</button>
                </div>
            </form>
            </div>
        </modal>
        <p id="loginSuccessful" v-if="showSuccessMsg===true">Welcome {{ singleUser.firstName }} {{ singleUser.lastName }}!</p>
        <p id="loginFailed" v-if="showFailMsg===true">Email and/or password are not a match.</p>


    </div>
</template>

<script>
export default {
    name: "login",


    data() {
        return {
            email: '',
            password: '',
            showLoginForm: false, 
            users: [],
            //example:  "http://localhost:5000/api/cards",
            apiURL: "https://localhost:44337/api/values",
            showSuccessMsg: false, 
            showFailMsg: false, 
            singleUser: {}
            };
    }, 

    methods: {

        //Finish Login Section
        submitLogin(e)
        {
            this.$validator.validateAll().then((result) => {
                if (result){
            e.preventDefault();
            console.log(this.email)
            console.log(this.password)
            this.apiURL = "https://localhost:44337/api/values" + '/' + this.email + '/' + this.password;
            // use fetch to this user from the database         
            fetch(this.apiURL,{
                method: 'GET'
                })
                .then(response => {
                    return response.json();
                })
            //assign the user objects from the DB to the users array defined in this component
                .then(data => {
                    this.singleUser = data;
                    console.log(this.singleUser.userId);
                    if (this.singleUser.userId > 0){
                        this.showSuccessMsg = true;
                        this.$emit('confirmedUser', this.singleUser);
                        console.log("This worked.");
                    }
                    //otherwise emit empty object titled noUserFound
                    else {
                        this.showFailMsg = true;
                        this.$emit('noUserFound', this.singleUser); 
                        console.log("This DID NOT work!");
                    }
                })
                .catch(e => {
                    console.log(e);
                });   

            this.showLoginForm = false;
            
            //filter thru users array and return the user with matching email
            /*
            let confirmedUser = this.users.filter((user) => {
                return input.email === user.Username;
            }); */

            //if a confirmed user is returned, emit the confirmedUser object so that the next component
            //can obtain this info
            //console.log(this.singleUser.userId)

            //clear the email and password fields
            //this.email='';
            //this.password = '';
            
                }
                else{
                    alert('Please enter both fields to log in!');
                }   
        })
        },
        show(){
            this.$modal.show('Login');
        },
        hide(){
            this.$modal.hide('Login');
        }
    //Once it's determined which component will pick up the emit from this function, then have to bind that in the App.vue file
    //Ex:  <componentName v-bind:elementName="confirmedUser">  or <componentName v-bind:elementName="noUserFound">

    //Also have to add "props: { confirmedUser, noUserFound } in child component"

    //May have to write function in App.vue that accepts the object being emitted from this function and does something
    //with that (ie start user session ?)--and then bind whatever gets returned from this function to the corresponding
    //html tag in the App.vue file instead

    //would suggest creating a component that displays the Profile Info in place of the Login button once Submit is clicked
    //and user is confirmed from database.  Otherwise, display error message.

    } 
}


</script>

<style>
#modal-header{
    text-align: center;
}
#modal-body{
    text-align: left;
}
#buttons{
    display: flex;
    justify-content: center;
    justify-content: space-around;
    padding-top: 5px;
}
#loginButton{
  width: 200px;
  height: 30px;
  font-size: 15pt;
  color: white;
  background: black;
  border: solid #FF983E;
  cursor: pointer;
}
#emailField label{
    padding-right: 37px;
}
</style>

