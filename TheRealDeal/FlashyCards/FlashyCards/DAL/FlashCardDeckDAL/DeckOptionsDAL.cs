using FlashyCards.Model.FlashCardDeckModels;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace FlashyCards.DAL.FlashCardDeckDAL
{
    public class DeckOptionsDAL : IDeckOptionsDAL
    {
        private string connectionString;
        private int deckID;
        private const string SQL_GetCategories = "Select * FROM Category order by Name asc;";
        private const string SQL_CreateNewDeckInDeckTable = "Insert into Deck (Name, Category_id, Share_Deck) Values (@DeckName, @Category_id, @Share_Deck); Select @@identity;";
        private const string SQL_CreateNewDeckUserRelationship = "Insert into User_Decks (Person_id, Deck_id) Values (@Person_id, @Deck_id);";
        private const string SQL_GetUserDecks = "Select Deck.Deck_id, Deck.Name, Deck.Category_id, Deck.Share_Deck, User_info.Person_id From Deck " +
            "inner join User_Decks on Deck.Deck_id = User_Decks.Deck_id " +
            "inner join User_info on User_Decks.Person_id = User_info.Person_id " +
            "where User_info.Person_id = @userID;";

        public DeckOptionsDAL(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public List<Category> GetCategoryList()
        {
            List<Category> categoryList = new List<Category>();
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(SQL_GetCategories, conn);
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        Category tempCategory = new Category();
                        tempCategory.Name = Convert.ToString(reader["Name"]);
                        tempCategory.ID = Convert.ToInt32(reader["Category_id"]);
                        categoryList.Add(tempCategory);
                    }
                }
            }
            catch (SqlException)
            {

                throw;
            }
            return categoryList;
        }

        public void CreateDeck(UserFlashCardDeck newDeck)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(SQL_CreateNewDeckInDeckTable, conn);
                    cmd.Parameters.AddWithValue("@DeckName", newDeck.deckName);
                    cmd.Parameters.AddWithValue("@Category_id", newDeck.category_id);
                    cmd.Parameters.AddWithValue("@Share_Deck", newDeck.isSharing);
                    deckID = Convert.ToInt32(cmd.ExecuteScalar());

                    cmd = new SqlCommand(SQL_CreateNewDeckUserRelationship, conn);
                    cmd.Parameters.AddWithValue("@Person_id", newDeck.person_id);
                    cmd.Parameters.AddWithValue("@Deck_id", deckID);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (SqlException)
            {

                throw;
            }
        }

        public List<UserFlashCardDeckWithID> GetUserDecks(int userID)
        {
            List<UserFlashCardDeckWithID> DeckList = new List<UserFlashCardDeckWithID>();
            
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(SQL_GetUserDecks, conn);
                    cmd.Parameters.AddWithValue("@userID", userID);
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        UserFlashCardDeckWithID tempDeck = new UserFlashCardDeckWithID();
                        tempDeck.deck_id = Convert.ToInt32(reader["Deck_id"]);
                        tempDeck.deckName = Convert.ToString(reader["Name"]);
                        tempDeck.category_id = Convert.ToInt32(reader["Category_id"]);
                        tempDeck.isSharing = Convert.ToBoolean(reader["Share_Deck"]);
                        tempDeck.person_id = Convert.ToInt32(reader["Person_id"]);
                        DeckList.Add(tempDeck);
                    }

                }
            }
            catch (SqlException)
            {

                throw;
            }
            return DeckList;
        }
        
    }
}
