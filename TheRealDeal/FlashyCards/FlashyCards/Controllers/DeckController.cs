using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FlashyCards.DAL.FlashCardDeckDAL;
using FlashyCards.Model.FlashCardDeckModels;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FlashyCards.Controllers
{
    [EnableCors]
    [Route("api/[controller]")]
    [ApiController]
    public class DeckController : ControllerBase
    {
        private DeckOptionsDAL deckOptionsDAL;
        public DeckController(DeckOptionsDAL deckOptionsDAL)
        {
            this.deckOptionsDAL = deckOptionsDAL;
        }
        
        //Returns List of Categories GET API(url = api/Deck)
        [HttpGet(Name = "GetCategoriesList")]
        public ActionResult<List<Category>> GetCategoriesList()
        {
            List<Category> categories = deckOptionsDAL.GetCategoryList();
            if (categories != null)
            {
                return categories;
            }
            return NotFound();
        }

        //Returns List of Decks Associated with User GET API(url = api/Deck/{user_Id})
        [HttpGet("user/{user_Id}", Name = "GetUserDecks")]
        public ActionResult<List<UserFlashCardDeckWithID>> GetUserDecks(int user_Id)
        {
            List<UserFlashCardDeckWithID> userDecks = deckOptionsDAL.GetUserDecks(user_Id);
            if (userDecks != null)
            {
                return userDecks;
            }
            return NotFound();
        }

        //Returns List of Decks That Are Sharable GET API(url = api/Deck/sharable)
        [HttpGet("sharable", Name = "GetSharableDecks")]
        public ActionResult<List<SharableDecks>> GetSharableDecks()
        {
            List<SharableDecks> sharableDecks = deckOptionsDAL.GetSharableDecks();
            if (sharableDecks != null)
            {
                return sharableDecks;
            }
            return NotFound();
        }


        //Creates a Deck Associated with a User POST API(url = api/Deck)
        [HttpPost]
        public ActionResult<List<UserFlashCardDeckWithID>> createUserDeck([FromForm] UserFlashCardDeck newDeck)
        {
            deckOptionsDAL.CreateDeck(newDeck);
            List<UserFlashCardDeckWithID> updatedUserDecks = deckOptionsDAL.GetUserDecks(newDeck.person_id);
            if (updatedUserDecks != null)
            {
                return updatedUserDecks;
            }
            return NotFound();
        }

        //Updates a Deck Associated with a deckID, PUT API(url = api/Deck/deckID/{deckID})
        [HttpPost("update/{deckID}")]
        public ActionResult<List<UserFlashCardDeckWithID>> updateDeck(int deckID, [FromForm] UserFlashCardDeckWithID deck)
        {
            UserFlashCardDeckWithID existingDeck = deckOptionsDAL.GetSingleDeck(deckID);
            if(existingDeck == null)
            {
                return NotFound();
            }

            existingDeck.deckName = String.IsNullOrEmpty(deck.deckName) ? existingDeck.deckName : deck.deckName;
            existingDeck.isSharing = deck.isSharing;
            existingDeck.category_id = deck.category_id;

            UserFlashCardDeckWithID updatedDeck = deckOptionsDAL.updateDeck(existingDeck);
            List<UserFlashCardDeckWithID> updatedUserDecks = new List<UserFlashCardDeckWithID>();
            if (updatedDeck != null)
            {
                return updatedUserDecks = deckOptionsDAL.GetUserDecks(updatedDeck.person_id);
            }
            return NotFound();
        }
    }
}