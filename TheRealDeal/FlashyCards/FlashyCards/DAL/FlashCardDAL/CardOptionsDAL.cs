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

        private const string SQL_CreateNewCard = "INSERT into Card (question, answer, image) VALUES (@question, @answer, @image); SELECT @@Identity";
        private const string SQL_GetCard = "SELECT * from Card_Deck as CD " +
            "JOIN Card on CD.Card_id = Card.Card_id " +
            "WHERE CD.Deck_id = @CD.Deck_ID";
        
        



        public CardOptionsDAL(string connectionString)
        {
            this.connectionString = connectionString;
        }
        public List<FlashCard> getCardInfo(FlashCard flashCard )
        {
            
            List<FlashCard> cardsList = new List<FlashCard>();
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(SQL_GetCard, conn);
                    cmd.Parameters.AddWithValue("@CD.Deck_ID", flashCard.cardID);
                    SqlDataReader reader = cmd.ExecuteReader();
                    

                    while (reader.Read())
                    {
                        flashCard.userID = Convert.ToInt32(reader["Person_id"]);
                        flashCard.question = Convert.ToString(reader["Question"]);
                        flashCard.answer = Convert.ToString(reader["Answer"]);
                        flashCard.image = Convert.ToString(reader["Image"]);
                        cardsList.Add(flashCard);
                    }
                }

            }
            catch (SqlException)
            {

                throw;
            }
            return cardsList;
        }

        public int createCard(FlashCard flashCard)
        {
            int card_ID = 0;
           // List<FlashCard> cardsList = new List<FlashCard>();
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(SQL_CreateNewCard, conn);
                    cmd.Parameters.AddWithValue("@question", flashCard.question);
                    cmd.Parameters.AddWithValue("@answer", flashCard.answer);
                    cmd.Parameters.AddWithValue("@image", flashCard.image);
                    card_ID = Convert.ToInt32(cmd.ExecuteScalar());
                    
                }

            }
            catch (SqlException)
            {

                throw;
            }
            return card_ID;
        }

       
    }
}
