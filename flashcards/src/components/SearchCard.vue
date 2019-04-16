<template>
<div class= "SearchCardSection">   
      <a id="SearchButton" v-on:click.prevent="show()">Search Flash Cards</a>
</div>

</template>

// <script>
// export default {
//     name: 'Card',

//     data() {
//         return {

//           cards: [],
//           showCardForm: false,
//           apiURL: "https://localhost:44337/api/Card",
//           question: '',
//           answer: '',
//           image: '',
//           tags: '',
            
//         };  
//     },
// </script>