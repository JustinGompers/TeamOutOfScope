using System;
using FlashyCards.Model;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FlashyCards.Model.FlashCardModel;

namespace FlashyCards.DAL.FlashCardDAL
{
    interface ICardOptions
    {
        int createCard(FlashCard newCard);
        List<FlashCard> getCardInfo(FlashCard flashCard);
    }
}
