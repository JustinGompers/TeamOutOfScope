<template>
    <div class= "loginSection"> 
        <h2>This is the start of the Login section</h2>   
        <button id="loginButton" v-on:click.prevent="showLoginForm = true" v-if="showLoginForm== false">Login / Register</button>

        <ul id="formLogin" v-if="showLoginForm === true">
        <li id="emailField" >
            <input type="text" id="login-email" placeholder="Enter your email">
        </li>
        <li id="passwordField">
            <input type="text" id="login-password" placeholder="Enter your password">
        </li>
        <button id="submitLoginButton" >Submit</button>
        <button id="cancelLoginButton" v-on:click.prevent="showLoginForm = false">Cancel</button>

        </ul>
    </div>
</template>

<script>
export default {
    name: "Login",

    data() {
        return {
            email: String,
            password: String,
            showLoginForm: false
        };
    }, 

    methods: {

        /*Finish Login Section
        submitLogin(input)
        {
                  // use fetch to see if a user with these credentials comes back.
            fetch(this.apiURL, {
                method: "GET",
                headers: {
                "Content-Type": "application/json; charset=utf-8"
                },
                body: JSON.stringify(input)
            })
                .then(response => {
                if (response.ok) {
                    // if our post was successful add the card to our cards array so the user can see it
                    // the next time this page is refreshed the new card will be pulled from the server.
                    this.cards.push(card);
                }
                })
                .catch(err => console.error(err));
                }
        }
        */
    }
}

</script>

<style lang="scss" scoped>

</style>

