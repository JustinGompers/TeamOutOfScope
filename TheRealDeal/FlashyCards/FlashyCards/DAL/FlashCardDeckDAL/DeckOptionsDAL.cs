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
        private const string SQL_GetCategories = "Select * FROM Category order by asc;";

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
    }
}
