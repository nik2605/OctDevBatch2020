using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace MVCTest.Data
{
    public class DataObject
    {
        public DataObject()
        {
            _connectionString = ConfigurationManager.ConnectionStrings["DbContext"].ConnectionString;
            SqlTransaction = null;
        }

        public DataObject(SqlTransaction trans)
        {
            _connectionString = ConfigurationManager.ConnectionStrings["DbContext"].ConnectionString;
            SqlTransaction = trans;
        }

        private string _connectionString;

        public string ConnectionString => _connectionString;

        public SqlTransaction SqlTransaction { get; set; }
    }
}