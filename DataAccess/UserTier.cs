using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Configuration;
using FinalProj.Models;

namespace FinalProj.DataAccess
{
    public class UserTier : BaseTier
    {
        public UserTier() : base()
        {

        }

        public List<Users> getUsers()
        {
            List<Users> userList = null;
            Users user = null;

            query = "SELECT * FROM users;";
            conn = new SqlConnection(connectionString);
            cmd = new SqlCommand(query, conn);

            try
            {
                conn.Open();
                reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    userList = new List<Users>();
                    while (reader.Read())
                    {
                        user = new Users();
                        user.user_id = (int)reader["user_id"];
                        user.first_name = (string)reader["first_name"];
                        user.last_name = (string)reader["last_name"];
                        user.username = (string)reader["username"];
                        user.password = (string)reader["password"];
                        user.type = (string)reader["type"];

                        userList.Add(user);
                    }
                }

            }
            catch (SqlException ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                conn.Close();
            }

            return userList;
        }

        public string getUserType(string user)
        {
            string type = null;

            query = "SELECT type FROM users WHERE username = @user;";
            conn = new SqlConnection(connectionString);
            cmd = new SqlCommand(query, conn);

            cmd.Parameters.Add("@user", SqlDbType.NVarChar, 20).Value = user;

            try
            {
                conn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows == true)
                {
                    while (dr.Read())
                    {
                        type = dr.GetString(0);
                    }

                }
            }
            catch (SqlException ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                conn.Close();
            }

            return type;

        }

        public bool userExists(string username)
        {
            query = "SELECT * FROM users WHERE username = @user;";
            conn = new SqlConnection(connectionString);
            cmd = new SqlCommand(query, conn);

            cmd.Parameters.Add("@user", SqlDbType.NVarChar, 20).Value = username;

            try
            {
                conn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    if (dr.HasRows == true)
                    {
                        success = true;
                    }
                    else
                    {
                        success = false;
                    }
                }
            }
            catch (SqlException ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                conn.Close();
            }

            return success;

        }

        public bool validPassword(string username, string password)
        {
            success = false;
            query = "SELECT username, password FROM users WHERE username = @user AND password = @pass;";
            conn = new SqlConnection(connectionString);
            cmd = new SqlCommand(query, conn);

            cmd.Parameters.Add("@user", SqlDbType.NVarChar, 20).Value = username;
            cmd.Parameters.Add("@pass", SqlDbType.NVarChar, 20).Value = password;

            try
            {
                conn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    if (dr.HasRows == true)
                    {
                        success = true;
                    }
                    else
                    {
                        success = false;
                    }
                }
            }
            catch (SqlException ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                conn.Close();
            }

            return success;

        }


        public bool insertUser(Users user)
        {
            int rows = 0;

            query = "INSERT INTO users" +
                "(first_name, last_name, username, password, type)" +
                "Values(@FName, @LName, @username, @password, @type);";

            conn = new SqlConnection(connectionString);
            cmd = new SqlCommand(query, conn);

            cmd.Parameters.Add("@FName", SqlDbType.VarChar, 20).Value = user.first_name;
            cmd.Parameters.Add("@LName", SqlDbType.NVarChar, 50).Value = user.last_name;
            cmd.Parameters.Add("@username", SqlDbType.NVarChar, 50).Value = user.username;
            cmd.Parameters.Add("@password", SqlDbType.NVarChar, 50).Value = user.password;
            cmd.Parameters.Add("@type", SqlDbType.NVarChar, 50).Value = user.type;

            try
            {
                conn.Open();

                rows = cmd.ExecuteNonQuery();

                if (rows > 0)
                {
                    success = true;
                }
                else
                {
                    success = false;

                }


            }
            catch (SqlException ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                conn.Close();
            }

            return success;
        }

        public bool updateUsers(User user)
        {
            return success;
        }

        public bool deleteUser(int id)
        {
            return success;
        }

        public string getIdByUser(string user)
        {
            int id = 0;

            query = "SELECT user_id FROM users WHERE username = @user;";
            conn = new SqlConnection(connectionString);
            cmd = new SqlCommand(query, conn);

            cmd.Parameters.Add("@user", SqlDbType.NVarChar, 20).Value = user;

            try
            {
                conn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows == true)
                {
                    while (dr.Read())
                    {
                        id = dr.GetInt32(0);
                    }

                }
            }
            catch (SqlException ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                conn.Close();
            }

            return id.ToString();

        }
        
    }
}