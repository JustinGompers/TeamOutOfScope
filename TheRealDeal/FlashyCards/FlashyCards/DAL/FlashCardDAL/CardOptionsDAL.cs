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

        public CardOptionsDAL(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public List<FlashCardWithID> GetAllFlashCards(int deckID)
        {
            List<FlashCardWithID> cardsList = new List<FlashCardWithID>();

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
                        FlashCardWithID tempCard = new FlashCardWithID();
                        tempCard.deckID = Convert.ToInt32(reader["Deck_id"]);
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

        public void CreateCard(FlashCard newCard)
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
                    cmd.Parameters.AddWithValue("@Deck_id", newCard.deckID);
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

        public List<FlashCardWithID> GetFlashCardsByTag(string tag)
        {
            List<FlashCardWithID> cardList = new List<FlashCardWithID>();

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
                        FlashCardWithID tempCard = new FlashCardWithID();
                        tempCard.deckID = Convert.ToInt32(reader["Deck_id"]);
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
    }
}
