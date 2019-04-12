using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using FlashyCards.Model.FlashCardModel;

namespace FlashyCards.DAL.FlashCardDAL
{
    public class CardOptionsDAL : ICardOptions
    {
        private string connectionString;
        private const string SQL_GetCards = "Select * FROM Card order by asc;";

        public CardOptionsDAL(string connectionString)
        {
            this.connectionString = connectionString;
        }
        public List<Cards> getCardInfo()
        {
            List<Cards> CardsList = new List<Cards>();
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(SQL_GetCards, conn);
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        FlashCard tempCard = new FlashCard();
                        tempCard.question = Convert.ToString(reader["Name"]);
                        tempCard.Card_id = Convert.ToInt32(reader["Category_id"]);

                        CardsList.Add(tempCard);
                    }
                }

            }
            catch (SqlException)
            {

                throw;
            }
            return CategoryList;
        }

    }

    
}
