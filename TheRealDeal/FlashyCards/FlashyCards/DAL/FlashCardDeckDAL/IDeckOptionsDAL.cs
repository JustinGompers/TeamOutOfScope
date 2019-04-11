using FlashyCards.Model.UserInfoModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlashyCards.DAL.FlashCardDeckDAL
{
    interface IDeckOptionsDAL
    {
        Category GetCategoryList();
    }
}
