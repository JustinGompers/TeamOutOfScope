<template>
  <div class="view-card-section">
          <button id="view-card-button" v-on:click.prevent="ShowCardInfo()">View Card</button>

          <modal id='view-card-modal' name="view-card-modal" :width="600" :height="300">
            <div id="modal-header">
                <h2>Card Info</h2>
            </div>
            <div id="modal-body">
                <br>
                <p>Card Question:  {{ this.Card.question }} </p>
                <p>Card Answer:  {{ this.Card.answer }} </p>
                <p>Card Image:  {{ this.Card.image }} </p>
                <p>Card Tag:  {{ this.Card.tag }} </p>
                <br>
            </div>
            <div>
                <button id="done" v-on:click.prevent="HideCardInfo()">Done</button>
            </div>
        </modal>
      </div>
</template>

<script>
export default {
    name: 'ViewCard',

    data() {
        return {

        }
    }, 

    props: {
        Card:{
            type: Object,
            required: true
        },
    },

    methods: {
        ShowCardInfo(){
            this.$modal.show('view-card-modal');
        },

        HideCardInfo(){
            this.$modal.hide('view-card-modal');
        },
    }

}
</script>

<style>
.view-card-section{
    display: inline;
}
#view-card-button{
    width: 150px;
    height: 50px;
    background: #800020;
    font-style: bold;
    font-size: 15pt;
    color: white;
    cursor: pointer;
}
</style>


