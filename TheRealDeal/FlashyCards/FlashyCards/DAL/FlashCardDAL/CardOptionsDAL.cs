using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using FlashyCards.Model.FlashCardModel;

namespace FlashyCards.DAL.FlashCardDAL
{
    public class CardOptionsDAL : ICardOptionsDAL
    {
        private string connectionString;
        private int cardID;
        private int tagID;
        private const string SQL_CreateNewCardInCardTable = "Insert into Card (Question, Image, Answer) Values (@Question, @Image, @Answer); SELECT @@identity";
        private const string SQL_CreateNewTagInTagTable = "Insert into Tags (Name) Values (@Name); Select @@identity;";
        private const string SQL_CreateNewCardDeckRelationship = "Insert into Deck_Cards (Deck_id, Card_id) Values (@Deck_id, @Card_id);";
        private const string SQL_CreateNewTagCardRelationship = "Insert into Card_Tags (Card_id, Tag_id) Values (@Card_id, @Tag_id);";
        private const string SQL_GetAllCardsAssociatedWithDeck = "Select Deck_Cards.Deck_id, Card.Card_id, Card.Question, Card.Answer, Card.Image, Tags.Name " +
            "From Deck_Cards inner join Card on Deck_Cards.Card_id = Card.Card_id left outer join " +
            "Card_Tags on Card.Card_id = Card_Tags.Card_id left outer join Tags on Card_Tags.Tag_id = Tags.tags_id " +
            "where Deck_Cards.Deck_id = @Deck_id;";
        private const string SQL_GetAllCardsAssociatedWithTag = "Select Deck_Cards.Deck_id, Card.Card_id, Card.Question, Card.Answer, Card.Image, Tags.Name " +
        "From Deck_Cards inner join Card on Deck_Cards.Card_id = Card.Card_id left outer join " +
        "Card_Tags on Card.Card_id = Card_Tags.Card_id left outer join Tags on Card_Tags.Tag_id = Tags.tags_id " +
        "where Tags.Name = @TagName;";

        private const string SQL_GetSingleCard = "Select Card.Card_id, Deck.Deck_id, Card.Question, Card.Image, Card.Answer, Tags.Name from Card "
            + "inner join Card_Tags on Card.Card_id = Card_Tags.Card_id "
            + "inner join Tags on Tags.tags_id = Card_Tags.Tag_id "
            + "inner join Deck_Cards on Deck_Cards.Card_id = Card.Card_id "
            + "inner join Deck on Deck.Deck_id = Deck_Cards.Deck_id "
            + "where Card.Card_id = @id;";

        private const string SQL_UpdateCard = "update Card set Question = @question, Image = @image, Answer = @answer "
            //+ "from Deck_Cards inner join Card on Deck_Cards.Card_id = Card.Card_id "
            + "where Card_id = @cardId; "
            + "update Tags set Name = @tagName "
            + "from Card_Tags inner join Tags on Card_Tags.Tag_id = Tags.tags_id "
            + "where Card_Tags.Card_id = @cardId;";

        private const string SQL_AddCardToDeck = "Insert into Deck_Cards (Deck_id, Card_id) values (@Deck_id, @Card_id);";

        public CardOptionsDAL(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public List<FlashCard> GetAllFlashCards(int deckID)
        {
            List<FlashCard> cardsList = new List<FlashCard>();

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(SQL_GetAllCardsAssociatedWithDeck, conn);
                    cmd.Parameters.AddWithValue("@Deck_id", deckID);
                    SqlDataReader reader = cmd.ExecuteReader();


                    while (reader.Read())
                    {
                        FlashCard tempCard = new FlashCard();
                        tempCard.cardID = Convert.ToInt32(reader["Card_id"]);
                        tempCard.question = Convert.ToString(reader["Question"]);
                        tempCard.answer = Convert.ToString(reader["Answer"]);
                        tempCard.image = Convert.ToString(reader["Image"]);
                        tempCard.tag = Convert.ToString(reader["Name"]);
                        cardsList.Add(tempCard);
                    }
                }

            }
            catch (SqlException)
            {

                throw;
            }
            return cardsList;
        }

        public void CreateCard(FlashCard newCard, int deckID)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(SQL_CreateNewCardInCardTable, conn);
                    cmd.Parameters.AddWithValue("@Question", newCard.question);
                    cmd.Parameters.AddWithValue("@Answer", newCard.answer);
                    cmd.Parameters.AddWithValue("@Image", newCard.image);
                    cardID = Convert.ToInt32(cmd.ExecuteScalar());

                    cmd = new SqlCommand(SQL_CreateNewTagInTagTable, conn);
                    cmd.Parameters.AddWithValue("@Name", newCard.tag);
                    tagID = Convert.ToInt32(cmd.ExecuteScalar());

                    cmd = new SqlCommand(SQL_CreateNewCardDeckRelationship, conn);
                    cmd.Parameters.AddWithValue("@Deck_id", deckID);
                    cmd.Parameters.AddWithValue("@Card_id", cardID);
                    cmd.ExecuteScalar();

                    cmd = new SqlCommand(SQL_CreateNewTagCardRelationship, conn);
                    cmd.Parameters.AddWithValue("@Card_id", cardID);
                    cmd.Parameters.AddWithValue("@Tag_id", tagID);
                    cmd.ExecuteScalar();                   
                }
            }
            catch (SqlException)
            {

                throw;
            }
        }

        public List<FlashCard> GetFlashCardsByTag(string tag)
        {
            List<FlashCard> cardList = new List<FlashCard>();

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(SQL_GetAllCardsAssociatedWithTag, conn);
                    cmd.Parameters.AddWithValue("@TagName", tag);
                    SqlDataReader reader = cmd.ExecuteReader();


                    while (reader.Read())
                    {
                        FlashCard tempCard = new FlashCard();
                        tempCard.cardID = Convert.ToInt32(reader["Card_id"]);
                        tempCard.question = Convert.ToString(reader["Question"]);
                        tempCard.answer = Convert.ToString(reader["Answer"]);
                        tempCard.image = Convert.ToString(reader["Image"]);
                        tempCard.tag = Convert.ToString(reader["Name"]);
                        cardList.Add(tempCard);
                    }

                }
            }
            catch (SqlException)
            {

                throw;
            }
            return cardList;
        }

        public FlashCard GetSingleCard (int id)
        {

            FlashCard singleFlashCard = new FlashCard();

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(SQL_GetSingleCard, conn);
                    cmd.Parameters.AddWithValue("@id", id);
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {                        
                        singleFlashCard.cardID = Convert.ToInt32(reader["Card_id"]);
                        singleFlashCard.question = Convert.ToString(reader["Question"]);
                        singleFlashCard.image = Convert.ToString(reader["Image"]);
                        singleFlashCard.answer = Convert.ToString(reader["Answer"]);
                        singleFlashCard.tag = Convert.ToString(reader["Name"]);
                    }
                }
            } catch (SqlException)
            {
                throw;
            }

            return singleFlashCard;
        }

        public bool UpdateCard (int id, FlashCard card)
        {
            int rowsAffected = -1;

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    SqlCommand cmd = new SqlCommand(SQL_UpdateCard, connection);

                    cmd.Parameters.AddWithValue("@question", card.question);
                    cmd.Parameters.AddWithValue("@image", card.image);
                    cmd.Parameters.AddWithValue("@answer", card.answer);
                    cmd.Parameters.AddWithValue("@tagName", card.tag);
                    cmd.Parameters.AddWithValue("@cardId", card.cardID);

                    rowsAffected = cmd.ExecuteNonQuery();
                }
            }
            catch (Exception)
            {

                throw;
            }

            return rowsAffected > 0;
        }

        public bool RemoveCard(int id)
        {
            int rowsAffected = -1;

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    SqlCommand cmd = new SqlCommand($"Delete from Deck_Cards where Card_id = @cardId;", connection);

                    cmd.Parameters.AddWithValue("@cardId", id);

                    rowsAffected = cmd.ExecuteNonQuery();
                }
            }
            catch (Exception)
            {

                throw;
            }

            return rowsAffected > 0;
        }

        public bool AddCardToDeck (int deckId, int cardId)
        {
            int rowsAffected = -1;

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    SqlCommand cmd = new SqlCommand(SQL_AddCardToDeck, connection);

                    cmd.Parameters.AddWithValue("@Deck_Id", deckId);
                    cmd.Parameters.AddWithValue("@Card_Id", cardId);

                    rowsAffected = cmd.ExecuteNonQuery();
                }
            }
            catch (Exception)
            {

                throw;
            }

            return rowsAffected > 0;
        }
    }
    
}
