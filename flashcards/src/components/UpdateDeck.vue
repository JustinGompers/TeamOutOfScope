<template>
<div>
    <h2>This is the start of the Update Deck section.</h2>

    <div id="update-deck-section">
        <button id="update-deck-button" v-on:click.prevent="showUpdateDeckForm()">Update Deck</button>

        <modal id='update-deck-modal' name="update-deck-modal" :width="600" :height="300">
          <div id="modal-header">
            <h2>Update Deck Form</h2>
          </div>

          <div id="modal-body">
            <form id="update-deck-form" @submit.prevent="UpdateDeck()">
                <div id="new-deck-name">
                    <label>New Deck Name: </label>
                    <input type="text" id="deck-name" placeholder="if applicable" v-model="deckName" name="Name"/>
                </div>
            </form>
          </div>


        </modal>
    </div>
</div>
</template>

<script>
export default {

    name: 'UpdateDeck',

    data() {
        return {
            deckName: ''
        }
    },

    props: {
        chosenDeck: {
            type: Number,
            required: true,
            default: 0
        }
    },

    methods: {
        showUpdateDeckForm(){
            this.$modal.show('update-deck-modal');
        },

        hideUpdateDeckForm(){
            this.$modal.hide('update-deck-modal');
        },

    }
}
</script>

<style>

</style>


