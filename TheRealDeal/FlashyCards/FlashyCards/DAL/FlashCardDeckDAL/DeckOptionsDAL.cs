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
        private const string SQL_GetSharableDecks = "Select Deck.Name, Category.Name as 'Category_Name', Deck.Deck_id From Deck " +
            "left outer join Category on Deck.Category_id = Category.Category_id " +
            "where Deck.Share_Deck = 1;";
        private const string SQL_UpdateDeck = "update Deck set Deck.Name = @deckName, Deck.Share_Deck = @shareDeck, " +
            "Deck.Category_id = @categoryID where Deck_id = @deckID;";
        private const string SQL_GetSingleDeck = "Select Deck.Deck_id, Deck.Name, Deck.Category_id, Deck.Share_Deck, User_info.Person_id From Deck " +
            "inner join User_Decks on Deck.Deck_id = User_Decks.Deck_id " +
            "inner join User_info on User_Decks.Person_id = User_info.Person_id " +
            "where Deck.Deck_id = @deckID;";

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
            List<UserFlashCardDeckWithID> deckList = new List<UserFlashCardDeckWithID>();
            
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
                        deckList.Add(tempDeck);
                    }

                }
            }
            catch (SqlException)
            {

                throw;
            }
            return deckList;
        }

        public List<SharableDecks> GetSharableDecks()
        {
            List<SharableDecks> sharableDeckList = new List<SharableDecks>();

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(SQL_GetSharableDecks, conn);
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        SharableDecks tempDeck = new SharableDecks();
                        tempDeck.deckName = Convert.ToString(reader["Name"]);
                        tempDeck.categoryName = Convert.ToString(reader["Category_Name"]);
                        tempDeck.deck_id = Convert.ToInt32(reader["Deck_id"]);
                        sharableDeckList.Add(tempDeck);
                    }

                }
            }
            catch (SqlException)
            {

                throw;
            }
            return sharableDeckList;
        }

        public UserFlashCardDeckWithID updateDeck(UserFlashCardDeckWithID updatedDeck)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    int affectedRows = 0;
                    SqlCommand cmd = new SqlCommand(SQL_UpdateDeck, conn);
                    cmd.Parameters.AddWithValue("@deckName", updatedDeck.deckName);
                    cmd.Parameters.AddWithValue("@shareDeck", updatedDeck.isSharing);
                    cmd.Parameters.AddWithValue("@categoryID", updatedDeck.category_id);
                    cmd.Parameters.AddWithValue("@deckID", updatedDeck.deck_id);
                    affectedRows = cmd.ExecuteNonQuery();
                    return affectedRows == 0 ? (UserFlashCardDeckWithID)null : updatedDeck;
                }
            }
            catch (SqlException)
            {
                throw;
            }
        }

        public UserFlashCardDeckWithID GetSingleDeck(int deckID)
        {
            UserFlashCardDeckWithID tempDeck = new UserFlashCardDeckWithID();
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(SQL_GetSingleDeck, conn);
                    cmd.Parameters.AddWithValue("@deckID", deckID);
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        tempDeck.deck_id = Convert.ToInt32(reader["Deck_id"]);
                        tempDeck.deckName = Convert.ToString(reader["Name"]);
                        tempDeck.category_id = Convert.ToInt32(reader["Category_id"]);
                        tempDeck.isSharing = Convert.ToBoolean(reader["Share_Deck"]);
                        tempDeck.person_id = Convert.ToInt32(reader["Person_id"]);
                    }

                }
            }
            catch (Exception)
            {

                throw;
            }
            return tempDeck;
        }
    }
}
