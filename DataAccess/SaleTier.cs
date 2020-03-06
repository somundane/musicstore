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
    public class SaleTier : BaseTier
    {
        public SaleTier() : base()
        {

        }

        public List<Sale> getAllItems()
        {
            List<Sale> sales = null;
            Sale sale = null;

            query = "SELECT * FROM sales;";

            conn = new SqlConnection(connectionString);
            cmd = new SqlCommand(query, conn);

            try
            {
                conn.Open();
                reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    sales = new List<Sale>();
                    while (reader.Read())
                    {
                        sale = new Sale();
                        sale.sales_no = (int)reader["sales_no"];
                        sale.SKU = (int)reader["SKU"];
                        sale.price = (decimal)reader["price"];
                        sale.qty_sold = (int)reader["qty_sold"];
                        sale.user_id = (int)reader["user_id"];
                        sales.Add(sale);
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

            return sales;
        }

        public bool addSale(Sale sale)
        {
            int rows;

            query = "INSERT INTO sales (SKU, price, qty_sold, user_id) " +
                "VALUES(@SKU, @price, @qty_sold, @user_id);";

            conn = new SqlConnection(connectionString);
            cmd = new SqlCommand(query, conn);

            cmd.Parameters.Add("@SKU", SqlDbType.Int).Value = sale.SKU;

            cmd.Parameters.Add("@price", SqlDbType.Decimal).Value = sale.price;

            cmd.Parameters.Add("@qty_sold", SqlDbType.Int).Value = sale.qty_sold;

            cmd.Parameters.Add("@user_id", SqlDbType.Int).Value = sale.user_id;


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


        public List<Sale> getUserPurchase(int id)
        {
            List<Sale> sales = null;
            Sale sale = null;

            query = "SELECT * FROM sales WHERE user_id = @id;";

            conn = new SqlConnection(connectionString);
            cmd = new SqlCommand(query, conn);

            cmd.Parameters.Add("@id", SqlDbType.NVarChar, 20).Value = id;

            try
            {
                conn.Open();
                reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    sales = new List<Sale>();
                    while (reader.Read())
                    {
                        sale = new Sale();
                        sale.sales_no = (int)reader["sales_no"];
                        sale.SKU = (int)reader["SKU"];
                        sale.price = (decimal)reader["price"];
                        sale.qty_sold = (int)reader["qty_sold"];
                        sale.user_id = (int)reader["user_id"];
                        sales.Add(sale);
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

            return sales;
        }
    }
}