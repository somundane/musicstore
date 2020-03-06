using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Configuration;

namespace FinalProj.DataAccess
{
    public class BaseTier
    {
        protected string connectionString;
        protected string query;
        protected SqlDataAdapter da;
        protected DataSet ds;
        protected SqlConnection conn;
        protected SqlCommand cmd;
        protected SqlDataReader reader;
        protected bool success;

        public BaseTier()
        {
            connectionString = ConfigurationManager.ConnectionStrings["StoreData"].ToString();
        }
    }
}