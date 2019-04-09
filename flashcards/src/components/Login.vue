<template>
    <div class= "loginSection"> 
        <h2>This is the start of the Login section</h2>   
        <button id="loginButton" v-on:click.prevent="showLoginForm = true" v-if="showLoginForm== false">Login / Register</button>

        <ul id="formLogin" v-if="showLoginForm === true">
        <li id="emailField" >
            <input type="text" id="login-email" placeholder="Enter your email" v-model.trim="email"/>
        </li>
        <li id="passwordField">
            <input type="text" id="login-password" placeholder="Enter your password" v-model.trim="password"/>
        </li>
        <button id="submitLoginButton" v-on:click="submitLogin(vm)">Submit</button>
        <button id="cancelLoginButton" v-on:click.prevent="showLoginForm = false">Cancel</button>

        </ul>
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
            apiURL: "YOUR_REST_API_URL",
        };
    }, 

    methods: {

        //Finish Login Section
        submitLogin(input)
        {
            // use fetch to bring back all users from the database         
            fetch(this.apiURL)
                .then(response => {
                    return response.json();
                })
            //assign the user objects from the DB to the users array defined in this component
                .then(users => {
                    this.users = users;
                });   

            this.showLoginForm = false;
            
            //filter thru users array and return the user with matching email
            let confirmedUser = this.users.filter((user) => {
                return input.email === user.Username;
            });

            //if a confirmed user is returned, emit the confirmedUser object so that the next component
            //can obtain this info
            if (confirmedUser != null){
                this.$emit('confirmedUser', confirmedUser);

            //otherwise emit empty object titled noUserFound
            } else {
                this.$emit('noUserFound', confirmedUser); 
            }
            
            //clear the email and password fields
            this.email='';
            this.password = '';
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

