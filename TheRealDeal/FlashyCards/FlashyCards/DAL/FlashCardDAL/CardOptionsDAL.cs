using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlashyCards.DAL.FlashCardDAL
{
    public class CardOptionsDAL : ICardOptions
    {
        private string connectionString;
        private const string SQL_GetCards = "Select * FROM Card order by asc;";
    }

    public CardOptionsDAL(string connectionString)
    {
        this.connectionString = connectionString;
    }
}
