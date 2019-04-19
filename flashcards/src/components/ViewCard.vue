<template>
  <div class="view-card-section">
          <button id="view-card-button" v-on:click.prevent="ShowCardInfo()">View Card</button>

          <modal id='view-card-modal' name="view-card-modal" :width="600" :height="325">
            <div id="modal-header">
                <h2>Card Info</h2>
            </div>
            <div id="modal-body">
            <div class="flipcard">
                <vue-flip :active-click="true" width="500px" height="200px" id="card">
                    <div slot="front">
                        <p>Question: {{this.Card.question}}</p>
                    </div>
                    <div slot="back">
                        <p>Answer: {{this.Card.answer}}</p>
                        <p>Tags: {{this.Card.tag}}</p>
                    </div>
                </vue-flip>
            </div>
            </div>
            <div>
                <button id="done" v-on:click.prevent="HideCardInfo()">Done</button>
            </div>
        </modal>
      </div>
</template>

<script>
import VueFlip from 'vue-flip';
export default {
    name: 'ViewCard',
    components:{
        'vue-flip': VueFlip
    },
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

#done{
    margin-left: 50px;
    text-align: center;
    width: 500px;
    background: black;
    color: white;
    border: solid #FF983E;
    height: 35px;
}
.flipcard p{
    font-size: 22pt;
    text-align: center;
}
.flipcard{
    padding-left: 50px;
}
.front {
    display: flex;
    align-items: center;
    justify-content: center;
    background-color: #FF983E;
    color: white;
}

.back {
    display: flex;
    align-items: center;
    justify-content: center;
    background-color: #800020;
    color: white
}
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


