using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FlashyCards.Model.UserInfoModels;

namespace FlashyCards.DAL.FlashCardDeckDAL
{
    public class DeckOptionsDAL : IDeckOptionsDAL
    {
        private string connectionString;
        private const string SQL_GetCategories = "Select * FROM Category order by asc;";

        public DeckOptionsDAL(string connectionString)
        {
            this.connectionString = connectionString;
        }

        //public Category GetCategoryList()
        //{
        //    List<Category> CategoryList = new List<Category>();

        //    try
        //    {
        //        using(SqlConnection)

        //    }
        //    catch (Exception)
        //    {

        //        throw;
        //    }
        }
    }
}
