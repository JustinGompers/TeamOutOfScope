<template>
<div>
<button id="AboutButton" v-on:click.prevent="show()">About</button>
<modal id="Form" name="About" :width="600" :height="150"> 
    <div id="modal-body">
    <form id="formCard" @submit.prevent="Button()" >
    <h3 id="aboutbody">Founded in 2019 by four Tech Elevator students, Flashy Cards is the premier flash card study site for all academic subjects. With over 30 million active users from 119 countries, Flashy cards is the trusted learning experience in schools and households throughout the world. Please register and embark on an educational journey by creating your first flash card deck today!</h3>
        
    </form>
</div>
</modal>
</div>



</template>

<script>
export default {
    name: 'About',

methods:{

     show(){
            this.$modal.show('About');
        },
        hide(){
            this.$modal.hide('About');
        }
}
}

</script>

<style>

#AboutButton{
    width: 200px;
    height: 30px;
    font-size: 15pt;
    color: white;
    background: black;
    border: solid #FF983E;
    cursor: pointer;
    
}
#modal-body{
    text-align: center;
    background: white;
}
#aboutbody{
    color: black;
    font-size: 17px;
}
</style>
    
