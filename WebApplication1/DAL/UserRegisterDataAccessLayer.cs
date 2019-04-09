using Capstone.Web.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;



namespace Capstone.Web.DAL
{
    public class UserRegisterDataAccessLayer : IUserRegisterDataAccessLayer<UserModel>
    {
        private string connectionString;
        private const string SQL_RegisterUser = "INSERT INTO User_Info (Username, FirstName, LastName, Password) Values (@username, @firstName, @lastName, @password);";
        private const string SQL_LoginUser = "SELECT * FROM User_info where Username = @userName and Password = @password);";

        public UserRegisterDataAccessLayer(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public UserModel getUserInfo(string userName, string password)
        {
            UserModel tempModel = new UserModel();

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(SQL_LoginUser, conn);
                    cmd.Parameters.AddWithValue("@userName", userName);
                    cmd.Parameters.AddWithValue("@password", password);
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        tempModel.userId = Convert.ToInt32(reader["User_id"]);
                        tempModel.userName = Convert.ToString(reader["Username"]);
                        tempModel.firstName = Convert.ToString(reader["FirstName"]);
                        tempModel.lastName = Convert.ToString(reader["LastName"]);
                        tempModel.password = Convert.ToString(reader["Password"]);
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
            return tempModel;
        }

        public void createUser(UserModel userModel)
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