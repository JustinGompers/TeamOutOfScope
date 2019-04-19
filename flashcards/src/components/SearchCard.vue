<template>
    <div class="SearchCardSection">   
      
      <button id="SearchButton" v-on:click.prevent="show()">Search Cards</button>
      <modal id="Form" name="SearchCard" :width="600" :height="400">
        <div id="modal-header">
                <h2>Search Cards Form</h2>
            </div>
            <div id="modal-body">
      <form id="formSearch" @submit.prevent="Button()" >
        <div id="searchbar">
          <label>Enter a tag: </label>
        <input type="text" v-validate="'required'" id="search" placeholder="i.e. algebra" name="search" v-model="search" />
        </div>
        <div id="SearchButtons">
         <button id="SubmitButton">Submit</button>
        <button id="CancelButton" v-on:click.prevent="hide()">Cancel</button>
        </div>
      </form>
        <div id="searchtable">
            <tr>
                <th>Card Question?</th>
                <th>Card Answer</th>
                <th></th>
            <tr>
            <tr v-for="card in cards" v-bind:key="card.cardID" :value="card">
                <td>{{card.question}}</td>
                <td>{{card.answer}}</td>
                <td id="addbutton"><button @click="addToDeck(card.cardID)">Add to Deck</button></td>
            </tr>
        </div>
      </div>
    </modal>
    </div>
    

</template>


<script>
export default {
    name: 'SearchCard',
    props:{
        DID:{
            type: Number,
            required: true,
            default: 0
        }
    },
    data() {
        return {

          cards: [],
          showFormSearch: false,
          apiURL: "https://localhost:44337/api/Card/tag/",
          search: '',
            
        };
    },
    methods: {
    Button() {
         this.$validator.validateAll().then((result) => {
             if (result) {
            this.apiURL = "https://localhost:44337/api/Card/tag/" + this.search
            fetch(this.apiURL, {
                method: 'GET'
            })
            .then(response => {
                return response.json();
            })
            .then(data => {
                this.cards = data;
            })
            .catch(err => {
                console.log(err);
            });
            this.search = '';
            this.showFormSearch = false;
            alert('Search Succesful!');
        }else{
            alert('Your search has missing fields!');
        }
    })
    },
    addToDeck(ID){
        fetch("https://localhost:44337/api/Card/update/" + this.DID + "/" + ID, {
            method: 'POST'
        })
        .then(response => {
            return response.json();
        })
        .catch(err => {
            console.log(err);
        })
        alert('The Card has been added to the deck!');
        this.$emit('CardTagAdded', ID);
    },
    show(){
            this.$modal.show('SearchCard');
        },
        hide(){
            this.$modal.hide('SearchCard');
        }
    }
    }
</script>
<style>
#searchtable{
    padding-left: 20px;
}
#seachbar{
    padding-bottom: 10px;
}
table, th, td {
    border: 1px solid black;  
}
th{
    background: #FF983E;
}
th, td{
    padding-top: 5px;
    padding-right: 100px;
}
#addbutton{
    padding: 0px;
}
#addbutton button{
    width: 125px;
    height: 25px;
    background: #800020;
    border: solid #FF983E;
    color: white;
}
#searchcard{
    font-size: 12pt;
    color: black;
}
.SearchCardSection{
    display:inline;
}
#SearchButton{ 
    width: 150px;
    height: 50px;
    background: #800020;
    font-style: bold;
    font-size: 15pt;
    color: white;
    cursor: pointer;
}
#SubmitButton{
  display: flex;
    justify-content: center;
    justify-content: space-around;
    padding-top: 5px;
    background: #800020;
        color: white;
        width: 300px;
        height: 50px;
        font-size: 25px;
        cursor: pointer;
}
#CancelButton{
  display: flex;
    justify-content: center;
    justify-content: space-around;
    padding-top: 5px;
    background: #800020;
        color: white;
        width: 300px;
        height: 50px;
        font-size: 25px;
        cursor: pointer;
}
div input{
    align-items: center;
}
#SearchButtons{
    padding-left: 50px;
    padding-bottom: 5px;
}
#SearchButtons button{
        display: inline;
        background: #800020;
        color: white;
        width: 100px;
        height: 25px;
        font-size: 13px;
        cursor: pointer;
}
</style>

    
    
    
    
