using FlashyCards.Model.FlashCardDeckModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlashyCards.DAL.FlashCardDeckDAL
{
    interface IDeckOptionsDAL
    {
        List<Category> GetCategoryList();
        void CreateDeck(UserFlashCardDeck newDeck);
        List<UserFlashCardDeckWithID> GetUserDecks(int userID);
        List<SharableDecks> GetSharableDecks();
        UserFlashCardDeckWithID updateDeck(UserFlashCardDeckWithID updatedDeck);
        UserFlashCardDeckWithID GetSingleDeck(int deckID);
    }
}
