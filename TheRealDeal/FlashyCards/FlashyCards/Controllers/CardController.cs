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
        public ActionResult<List<FlashCardWithID>> createFlashCard([FromBody] FlashCard newCard)
        {
            Dal.CreateCard(newCard);
            List<FlashCardWithID> updatedFlashCardDeck = Dal.GetAllFlashCards(newCard.deckID);
            if (updatedFlashCardDeck != null)
            {
                return updatedFlashCardDeck;
            }
            return NotFound();
        }
    }
}
