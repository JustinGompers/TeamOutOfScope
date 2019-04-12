<template>
    <div class= "loginSection"> 
        <button id="loginButton">Login</button>
        <form id="formLogin" v-on:submit="submitLogin()">
            <div id="emailField" >
                <label>Email:</label>
                <input type="text" id="login-email" name="userName" placeholder="Enter your email" v-model.trim="email"/>
            </div>
            <div id="passwordField">
                <label>Password:</label>
                <input type="text" id="login-password" name="password" placeholder="Enter your password" v-model.trim="password"/>
            </div>
            <div>
                <button id="submitLoginButton" >Submit</button>
                <button id="cancelLoginButton">Cancel</button>
            </div>
        </form>
        <p id="loginSuccessful" v-if="showSuccessMsg===true">Welcome {{singleUser.FirstName}} {{singleUser.LastName}}!</p>
        <p id="loginFailed" v-if="showFailMsg===true">Email and/or password are not a match.</p>


    </div>
</template>

<script>
export default {
    name: "login",


    data() {
        return {
            userId: 0,
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
        submitLogin()
        {
            console.log(this.email)
            console.log(this.password)
            this.apiURL = this.apiURL + '/' + this.email + '/' + this.password;
            // use fetch to this user from the database         
            fetch(this.apiURL,{
                method: 'GET',
                mode: 'no-cors'
                })
                .then(response => {
                    console.log(response);
                    return response.json();
                })
            //assign the user objects from the DB to the users array defined in this component
                .then(user => {
                    this.singleUser = user;
                });   

            this.showLoginForm = false;
            
            //filter thru users array and return the user with matching email
            /*
            let confirmedUser = this.users.filter((user) => {
                return input.email === user.Username;
            }); */

            //if a confirmed user is returned, emit the confirmedUser object so that the next component
            //can obtain this info
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
            return false;

            

            //clear the email and password fields
            //this.email='';
            //this.password = '';
            
            
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

<style lang="scss" scoped>

</style>

