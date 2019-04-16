using System;
using FlashyCards.Model;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FlashyCards.Model.FlashCardModel;

namespace FlashyCards.DAL.FlashCardDAL
{
    interface ICardOptionsDAL
    {
        void CreateCard(FlashCard newCard);
        List<FlashCard> GetAllFlashCards(int deckID);
        List<FlashCard> GetFlashCardsByTag(string tag);
    }
}
