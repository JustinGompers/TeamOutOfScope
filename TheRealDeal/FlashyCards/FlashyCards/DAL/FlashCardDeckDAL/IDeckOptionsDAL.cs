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
    }
}
