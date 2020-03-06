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
    public class OrderTier : BaseTier
    {
        public OrderTier() : base()
        {

        }

        public List<Orders> getAllOrders()
        {
            List<Orders> orders = null;
            Orders order = null;

            query = "SELECT * FROM orders;";

            conn = new SqlConnection(connectionString);
            cmd = new SqlCommand(query, conn);

            try
            {
                conn.Open();
                reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    orders = new List<Orders>();
                    while (reader.Read())
                    {
                        order = new Orders();
                        order.order_no = (int)reader["order_no"];
                        order.SKU = (int)reader["SKU"];
                        order.qty_ordered = (int)reader["qty_ordered"];
                        order.order_status = (string)reader["order_status"];
                        orders.Add(order);
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

            return orders;
        }

        //new order
        public bool insertOrder(Orders item)
        {
            int rows;

            query = "INSERT INTO orders (SKU, qty_ordered, order_status) " +
                "VALUES(@SKU, @qty, @status);";

            conn = new SqlConnection(connectionString);
            cmd = new SqlCommand(query, conn);

            cmd.Parameters.Add("@SKU", SqlDbType.Int).Value = item.SKU;

            cmd.Parameters.Add("@qty", SqlDbType.Int).Value = item.qty_ordered;
            
            cmd.Parameters.Add("@status", SqlDbType.NVarChar, 20).Value = "pending";


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

        public List<Orders> getPendingOrders()
        {
            List<Orders> orders = null;
            Orders order = null;

            query = "SELECT * FROM orders WHERE order_status = @status;";

            conn = new SqlConnection(connectionString);
            cmd = new SqlCommand(query, conn);

            cmd.Parameters.Add("@status", SqlDbType.NVarChar, 20).Value = "pending";

            try
            {
                conn.Open();
                reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    orders = new List<Orders>();
                    while (reader.Read())
                    {
                        order = new Orders();
                        order.order_no = (int)reader["order_no"];
                        order.SKU = (int)reader["SKU"];
                        order.qty_ordered = (int)reader["qty_ordered"];
                        order.order_status = (string)reader["order_status"];
                        orders.Add(order);
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

            return orders;
        }

        public bool orderRec(int onum)
        {
            int rows;

            query = "UPDATE orders SET order_status = 'received' WHERE order_no = @num";

            conn = new SqlConnection(connectionString);
            cmd = new SqlCommand(query, conn);

            cmd.Parameters.Add("@num", SqlDbType.Int).Value = onum;

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