using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using FinalProj.Models;

namespace FinalProj.DataAccess
{
    public class ItemTier : BaseTier
    {
        public ItemTier() : base()
        {

        }

        public List<Item> getAllItems()
        {
            List<Item> items = null;
            Item item = null;

            query = "SELECT * FROM inventory;";

            conn = new SqlConnection(connectionString);
            cmd = new SqlCommand(query, conn);

            try
            {
                conn.Open();
                reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    items = new List<Item>();
                    while (reader.Read())
                    {
                        item = new Item();
                        item.SKU = (int)reader["SKU"];
                        item.album_title = (string)reader["album_title"];
                        item.artist = (string)reader["artist"];
                        item.price = (decimal)reader["price"];
                        item.quantity = (int)reader["quantity"];
                        item.cover = (byte[])reader["cover"];
                        items.Add(item);
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

            return items;
        }

        //low stock items for order.aspx
        public List<Item> getLowItems()
        {
            List<Item> items = null;
            Item item = null;

            query = "SELECT * FROM inventory WHERE quantity < 5;";

            conn = new SqlConnection(connectionString);
            cmd = new SqlCommand(query, conn);

            try
            {
                conn.Open();
                reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    items = new List<Item>();
                    while (reader.Read())
                    {
                        item = new Item();
                        item.SKU = (int)reader["SKU"];
                        item.album_title = (string)reader["album_title"];
                        item.artist = (string)reader["artist"];
                        item.price = (decimal)reader["price"];
                        item.quantity = (int)reader["quantity"];
                        item.cover = (byte[])reader["cover"];
                        items.Add(item);
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

            return items;
        }

        public bool insertItem(Item item)
        {
            int rows;

            query = "INSERT INTO inventory (SKU, album_title, artist, price, quantity, cover) " +
                "VALUES(@SKU, @album, @artist, @price, @quantity, @cover);";

            conn = new SqlConnection(connectionString);
            cmd = new SqlCommand(query, conn);

            cmd.Parameters.Add("@SKU", SqlDbType.Int).Value = item.SKU;

            cmd.Parameters.Add("@album", SqlDbType.NVarChar, 30).Value = item.album_title;

            cmd.Parameters.Add("@artist", SqlDbType.NVarChar, 20).Value = item.artist;
            /*if (item.productDetails != null)
            {
                cmd.Parameters.Add("@Details", SqlDbType.NVarChar, 50).Value = item.productDetails;
            }
            else
            {
                cmd.Parameters.Add("@Details", SqlDbType.NVarChar, 50).Value = DBNull.Value;
            }*/
            cmd.Parameters.Add("@price", SqlDbType.Decimal).Value = item.price;

            cmd.Parameters.Add("@quantity", SqlDbType.Int).Value = item.quantity;

            cmd.Parameters.Add("@cover", SqlDbType.Image).Value = item.cover;

            try
            {

                conn.Open();
                rows = cmd.ExecuteNonQuery();
                if (rows <= 0)
                {
                    success = false;
                }
                else
                {
                    success = true;
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

        public bool deleteItem(int SKU)
        {
            int rows;

            query = "DELETE FROM inventory WHERE SKU = @delSKU";

            conn = new SqlConnection(connectionString);
            cmd = new SqlCommand(query, conn);

            cmd.Parameters.Add("@delSKU", SqlDbType.Int).Value = SKU;


            try
            {
                conn.Open();
                rows = cmd.ExecuteNonQuery();
                if (rows <= 0)
                {
                    success = false;
                }
                else
                {
                    success = true;
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

        public bool updateItem(Item item)
        {
            int rows;

            query = "UPDATE inventory SET album_title = @album, artist = @artist, price = @price, quantity = @quantity, cover = @cover " +
                "WHERE SKU = @editSKU";

            conn = new SqlConnection(connectionString);
            cmd = new SqlCommand(query, conn);

            cmd.Parameters.Add("@editSKU", SqlDbType.Int).Value = item.SKU;

            cmd.Parameters.Add("@album", SqlDbType.NVarChar, 30).Value = item.album_title;

            cmd.Parameters.Add("@artist", SqlDbType.NVarChar, 20).Value = item.artist;

            cmd.Parameters.Add("@price", SqlDbType.Decimal).Value = item.price;

            cmd.Parameters.Add("@quantity", SqlDbType.Int).Value = item.quantity;

            cmd.Parameters.Add("@cover", SqlDbType.Image).Value = item.cover;

            try
            {

                conn.Open();
                rows = cmd.ExecuteNonQuery();
                if (rows <= 0)
                {
                    success = false;
                }
                else
                {
                    success = true;
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

        public byte[] getImage(int ID)
        {
            byte[] Data = null;

            query = "SELECT cover FROM inventory WHERE SKU = @ID;";

            conn = new SqlConnection(connectionString);
            cmd = new SqlCommand(query, conn);

            cmd.Parameters.Add("@ID", SqlDbType.Int).Value = ID;

            try
            {
                conn.Open();
                var data = cmd.ExecuteScalar();
                if (data != DBNull.Value)
                {
                    Data = (byte[])data;
                }
                else
                {
                    Data = null;
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
            return Data;
        }

        public Item getItemByID(int id)
        {
            Item item = null;

            query = "SELECT * FROM inventory WHERE SKU = @SKU;";

            conn = new SqlConnection(connectionString);
            cmd = new SqlCommand(query, conn);

            cmd.Parameters.Add("@SKU", SqlDbType.Int).Value = id;

            try
            {
                conn.Open();

                reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    item = new Item();

                    reader.Read();

                    item.SKU = (int)reader["SKU"];
                    item.album_title = (string)reader["album_title"];
                    item.artist = (string)reader["artist"];
                    item.price = (decimal)reader["price"];
                    item.quantity = (int)reader["quantity"];
                    item.cover = (byte[])reader["cover"];

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

            return item;
        }

        public bool itemExists(int sku)
        {
            query = "SELECT * FROM inventory WHERE SKU = @SKU;";
            conn = new SqlConnection(connectionString);
            cmd = new SqlCommand(query, conn);

            cmd.Parameters.Add("@SKU", SqlDbType.Int).Value = sku;

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

        public List<Item> getPendingItems(int id)
        {
            List<Item> items = null;
            Item item = null;

            query = "SELECT o.user_id, i.SKU, album_title, artist, o.price, quantity, cover FROM inventory i RIGHT JOIN sales o ON i.SKU = o.SKU WHERE o.user_id = @id;";

            conn = new SqlConnection(connectionString);
            cmd = new SqlCommand(query, conn);

            cmd.Parameters.Add("@id", SqlDbType.Int).Value = id;

            try
            {
                conn.Open();
                reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    items = new List<Item>();
                    while (reader.Read())
                    {
                        item = new Item();
                        item.SKU = (int)reader["SKU"];
                        item.album_title = (string)reader["album_title"];
                        item.artist = (string)reader["artist"];
                        item.price = (decimal)reader["price"];
                        item.quantity = (int)reader["quantity"];
                        item.cover = (byte[])reader["cover"];
                        items.Add(item);
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

            return items;
        }

        public List<Item> getIncomingItems()
        {
            List<Item> items = null;
            Item item = null;

            query = "SELECT i.SKU, album_title, artist, price, quantity, cover FROM inventory i RIGHT JOIN orders o ON i.SKU = o.SKU WHERE o.order_status = @status;";

            conn = new SqlConnection(connectionString);
            cmd = new SqlCommand(query, conn);

            //cmd.Parameters.Add("@sku", SqlDbType.Int).Value = sku;
            cmd.Parameters.Add("@status", SqlDbType.NVarChar, 20).Value = "pending";

            try
            {
                conn.Open();
                reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    items = new List<Item>();
                    while (reader.Read())
                    {
                        item = new Item();
                        item.SKU = (int)reader["SKU"];
                        item.album_title = (string)reader["album_title"];
                        item.artist = (string)reader["artist"];
                        item.price = (decimal)reader["price"];
                        item.quantity = (int)reader["quantity"];
                        item.cover = (byte[])reader["cover"];
                        items.Add(item);
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

            return items;
        }

        public bool itemRec(int SKU, int qty)
        {
            int rows;

            query = "UPDATE inventory SET quantity = quantity + @add WHERE SKU = @SKU";

            conn = new SqlConnection(connectionString);
            cmd = new SqlCommand(query, conn);

            cmd.Parameters.Add("@SKU", SqlDbType.Int).Value = SKU;
            cmd.Parameters.Add("@add", SqlDbType.Int).Value = qty;


            try
            {
                conn.Open();
                rows = cmd.ExecuteNonQuery();
                if (rows <= 0)
                {
                    success = false;
                }
                else
                {
                    success = true;
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

        public bool decreaseItem(int SKU)
        {
            int rows;

            query = "UPDATE inventory SET quantity = quantity - 1 WHERE SKU = @SKU";

            conn = new SqlConnection(connectionString);
            cmd = new SqlCommand(query, conn);

            cmd.Parameters.Add("@SKU", SqlDbType.Int).Value = SKU;

            try
            {
                conn.Open();
                rows = cmd.ExecuteNonQuery();
                if (rows <= 0)
                {
                    success = false;
                }
                else
                {
                    success = true;
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

    }
}