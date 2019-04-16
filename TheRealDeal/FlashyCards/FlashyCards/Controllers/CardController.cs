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
        public ActionResult<List<FlashCard>> GetFlashCardsByDeck(int deckID)
        {
            List<FlashCard> flashCardList = Dal.GetAllFlashCards(deckID);
            if (flashCardList != null)
            {
                return flashCardList;
            }
            return NotFound();
        }

        // Returns List of Flashcards associated with a tag, GET API(url = api/Card/tag/{tag})
        [HttpGet("tag/{tag}", Name = "GetFlashCardsByTag")]
        public ActionResult<List<FlashCard>> GetFlashCardsByTag(string tag)
        {
            List<FlashCard> flashCardList = Dal.GetFlashCardsByTag(tag);
            if (flashCardList != null)
            {
                return flashCardList;
            }
            return NotFound();
        }

        //Creates a FlashCard Associated with a Deck, POST API(url = api/Card/{deckID})
        [HttpPost("{deckID}")]
        public ActionResult<List<FlashCard>> createFlashCard([FromForm] FlashCard newCard, int deckID)
        {
            if (newCard.image == null)
            {
                newCard.image = "";
            }

            Dal.CreateCard(newCard, deckID);
            List<FlashCard> updatedFlashCardDeck = Dal.GetAllFlashCards(deckID);
            if (updatedFlashCardDeck != null)
            {
                return updatedFlashCardDeck;
            }
            return NotFound();
        }

        //Example: PUT api/card/16
        //Updates a Flashcard
        [HttpPut("{id}")]
        public ActionResult<List<FlashCard>> updateFlashCard(int id, [FromForm] FlashCard updatedCard)
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

            existingCard.question = updatedCard.question == "" ? existingCard.question : updatedCard.question;
            existingCard.image = updatedCard.image == "" ? existingCard.image : updatedCard.image;
            existingCard.answer = updatedCard.answer == "" ? existingCard.answer : updatedCard.answer;
            existingCard.tag = updatedCard.tag == "" ? existingCard.tag : updatedCard.tag;

            bool isNowUpdated = Dal.UpdateCard(id, existingCard);

            if (isNowUpdated)
            {
                return Dal.GetFlashCardsByTag(existingCard.tag);
            }
            return NotFound();
        }

        //Example: DELETE api/card/16
        //Disconnects the relationship between a card and its deck
        [HttpDelete("{id}")]
        public ActionResult RemoveFlashCard(int id)
        {
            var existingCard = Dal.GetSingleCard(id);

            if (existingCard == null)
            {
                return NotFound();
            }

            bool isNowRemoved = Dal.RemoveCard(id);

            if (isNowRemoved)
            {
                return NoContent();
            }
            else
            {
                return NotFound();
            }
        }

    }
}
