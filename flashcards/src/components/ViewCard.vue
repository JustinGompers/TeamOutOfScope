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

    },

    methods: {
        ShowCardInfo(){
            this.$modal.show('update-card-modal');
        },

        HideCardInfo(){
            this.$modal.hide('update-card-modal');
        },
    }

}
</script>

<style>

</style>


