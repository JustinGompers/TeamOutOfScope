<template>
    <div class= "SearchCardSection">   
      <a id="SearchButton" v-on:click.prevent="show()">Search Flash Cards</a>
      <modal id="Form" name="SearchCard" :width="600" :height="400">
        <div id="modal-header">
                <h2>Search a Card Form</h2>
            </div>
            <div id="modal-body">
      <form id="formSearch" @submit.prevent="Button()" >
          <input type="hidden" id="CardId" value="1" name="cardId" />
        <div>
          <label>Search: </label>
        <input type="text" v-validate="'required'" id="search" placeholder="Enter a tag" name="search" v-model="search" />
        </div>
         <button id="SubmitButton">Submit</button>
        <button id="CancelButton" v-on:click.prevent="hide()">Cancel</button>
      </form>
      </div>
     
    </modal>
  
</div>

</template>

<script>
export default {
    name: 'SearchCard',

    data() {
        return {

          cards: [],
          showFormSearch: false,
          apiURL: "https://localhost:44337/api/SearchCard",
          search: '',
            
        };
    },
    methods: {
    Button() {
         this.$validator.validateAll().then((result) => {
             if (result) {
          let cardSearch = document.getElementById("formSearch")
            let search = new FormData(cardSearch)
            fetch(this.apiURL, {
                method: 'GET',
                body: search,
                mode: 'no-cors',
                headers: {
                    'Content-Type': 'application/json'
                }
            })
            .then(response => {
                return response.json();
            })
            .catch(err => {
                err
            });
            this.$modal.hide('SearchCard');
            this.search = '';
            this.showFormSearch = false;
            alert('Search Succesful!');
        }else{
            alert('Your search has missing fields!');
        }
    })
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

    
    
    
    
