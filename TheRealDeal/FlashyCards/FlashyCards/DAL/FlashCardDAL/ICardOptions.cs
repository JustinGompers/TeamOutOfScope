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
        void createCard(FlashCard newCard);
        FlashCard getCardInfo(string question, string answer, string image);
    }
}
