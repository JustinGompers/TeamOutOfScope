using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FlashyCards.DAL.FlashCardDAL;
using FlashyCards.Model.FlashCardModel;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FlashyCards.Controllers
{
    [EnableCors]
    [Route("api/[controller]")]
    [ApiController]
    public class CardController : ControllerBase
    {
        private CardOptionsDAL Dal;
        public CardController(CardOptionsDAL Dal)
        {
            this.Dal = Dal;

        }

        // Returns List of Flashcards associated with a deck, GET API(url = api/Card/{deckID})
        [HttpGet("{deckID}", Name = "GetFlashCardsByDeck")]
        public ActionResult<List<FlashCardWithID>> GetFlashCardsByDeck(int deckID)
        {
            List<FlashCardWithID> flashCardList = Dal.GetAllFlashCards(deckID);
            if (flashCardList != null)
            {
                return flashCardList;
            }
            return NotFound();
        } 
        
        // Returns List of Flashcards associated with a tag, GET API(url = api/Card/{tag})
        [HttpGet("tag/{tag}", Name = "GetFlashCardsByTag")]
        public ActionResult<List<FlashCardWithID>> GetFlashCardsByTag(string tag)
        {
            List<FlashCardWithID> flashCardList = Dal.GetFlashCardsByTag(tag);
            if (flashCardList != null)
            {
                return flashCardList;
            }
            return NotFound();
        }

        //Creates a FlashCard Associated with a Deck, POST API(url = api/Card)
        [HttpPost]
        public ActionResult<List<FlashCardWithID>> createFlashCard([FromForm] FlashCard newCard)
        {
            if (newCard.image == null)
            {
                newCard.image = "";
            }

            Dal.CreateCard(newCard);
            List<FlashCardWithID> updatedFlashCardDeck = Dal.GetAllFlashCards(newCard.deckID);
            if (updatedFlashCardDeck != null)
            {
                return updatedFlashCardDeck;
            }
            return NotFound();
        }

        //Example: PUT api/card/16
        //Updates a Flashcard
        [HttpPut("{id}")]
        public ActionResult updateFlashCard(int id, [FromBody] FlashCardWithID updatedCard)
        {
            //for security, make sure that the id used in API call matches the id in the flashcard object that's passed in
            if (id != updatedCard.cardID)
            {
                return NotFound();
            }

            //make sure this card is, in fact, already existing in the DB
            var existingCard = Dal.GetSingleCard(id);

            if (existingCard == null)
            {
                return NotFound();
            }

            //For fields passed in from the API ... if those fields are null, keep the existing data in the DB
            //For the fields passed in from API that are NOT null, update that data in the DB
            existingCard.cardID = updatedCard.cardID;            
            existingCard.deckID = updatedCard.deckID;

            existingCard.question = updatedCard.question == "" ? existingCard.question : updatedCard.question;
            existingCard.image = updatedCard.image == "" ? existingCard.image : updatedCard.image;
            existingCard.answer = updatedCard.answer == "" ? existingCard.answer : updatedCard.answer;
            existingCard.tag = updatedCard.tag == "" ? existingCard.tag : updatedCard.tag;

            bool isNowUpdated = Dal.UpdateCard(id, existingCard);

            if (!isNowUpdated)
            {
                return NotFound();
            } else
            {
                return CreatedAtRoute("GetFlashCardsByTag", new { tag = existingCard.tag }, existingCard);
            }

            
        }

    }
}
