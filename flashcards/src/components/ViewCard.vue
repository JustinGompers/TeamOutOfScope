<template>
  <div>
      <h2>This is the start of the View Card section.</h2>

      <div class="view-card-section">
          <button id="view-card-button" v-on:click.prevent="ShowCardInfo()">View Card</button>

          <modal id='view-card-modal' name="view-card-modal" :width="600" :height="300">
            <div id="modal-header">
                <h2>Card Info</h2>
            </div>
            <div id="modal-body">
                <br>
                <p>Card Question:  {{ question }} </p>
                <p>Card Answer:  {{ answer }} </p>
                <p>Card Image:  {{ image }} </p>
                <p>Card Tag:  {{ tag }} </p>
                <br>
            </div>
            <div>
                <button id="done" v-on:click.prevent="HideCardInfo()">Done</button>
            </div>
        </modal>
      </div>
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
        question: String,
        answer: String,
        image: String,
        tag: String
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

</style>


