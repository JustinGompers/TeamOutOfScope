<template>
<div>
<h2 id="aboutSection">About</h2>
 
<modal id="Form" name="About" :width="600" :height="400"> 
    <div id="modal-body">
        <h3 id="aboutbody">Founded in 2019 by four Tech Elevator students, Flashy Cards is the premier flash card study site for all academic subjects.</h3>
       
</div>
</modal>
</div>


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

#aboutSection{
    Color: white;
    border-bottom: solid;
    font-size: 10px;
}
#modal-header{
    text-align: center;
    background: lightblue;
}
#aboutbody{
    color: white;
    font-size: 15px;
}
</style>
    
