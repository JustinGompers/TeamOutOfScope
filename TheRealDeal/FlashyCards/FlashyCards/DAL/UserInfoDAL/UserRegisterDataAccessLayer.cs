using FlashyCards.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace FlashyCards.DAL
{
    public class UserRegisterDataAccessLayer : IUserRegisterDataAccessLayer
    {
        private string connectionString;
        private const string SQL_RegisterUser = "INSERT INTO User_Info (Username, FirstName, LastName, Password, Salt) Values (@username, @firstName, @lastName, @password, @salt);";
        private const string SQL_LoginUser = "SELECT * FROM User_info where Username = @userName";

        public UserRegisterDataAccessLayer(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public UserModel getUserInfo(string userName)
        {
            UserModel tempModel = new UserModel();

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(SQL_LoginUser, conn);
                    cmd.Parameters.AddWithValue("@userName", userName);
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        tempModel.userId = Convert.ToInt32(reader["Person_id"]);
                        tempModel.userName = Convert.ToString(reader["Username"]);
                        tempModel.firstName = Convert.ToString(reader["FirstName"]);
                        tempModel.lastName = Convert.ToString(reader["LastName"]);
                        tempModel.password = Convert.ToString(reader["Password"]);
                        tempModel.salt = Convert.ToString(reader["salt"]);
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
            return tempModel;
        }

        public void createUser(RegisterUserModel userModel)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(SQL_RegisterUser, conn);
                    cmd.Parameters.AddWithValue("@username", userModel.userName);
                    cmd.Parameters.AddWithValue("@firstName", userModel.firstName);
                    cmd.Parameters.AddWithValue("@lastName", userModel.lastName);
                    cmd.Parameters.AddWithValue("@password", userModel.password);
                    cmd.Parameters.AddWithValue("@salt", userModel.salt);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (SqlException)
            {

                throw;
            }
        }
    }
}
