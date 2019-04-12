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
        public List<Cards> getCardInfo(string question, string answer, string image)
        {
            FlashCard flashCard = new FlashCard();
            List<Cards> CardsList = new List<Cards>();
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(SQL_GetCards, conn);
                    SqlDataReader reader = cmd.ExecuteReader();
                    cmd.Parameters.AddWithValue("@question", question);
                    cmd.Parameters.AddWithValue("@answer", answer);
                    cmd.Parameters.AddWithValue("@image", image);

                    while (reader.Read())
                    {
                        flashCard.userID = Convert.ToInt32(reader["Person_id"]);
                        flashCard.question = Convert.ToString(reader["Question"]);
                        flashCard.answer = Convert.ToString(reader["Answer"]);
                        flashCard.image = Convert.ToString(reader["Image"]);
                        
                    }
                }

            }
            catch (SqlException)
            {

                throw;
            }
            return CategoryList;
        }

        public void createCard(FlashCard newCard)
        {
            throw new NotImplementedException();
        }




    }
}
