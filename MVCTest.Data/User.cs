using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;

namespace MVCTest.Data
{
    public class User : DataObject
    {

        private int userId;
        private string fname;
        private string lname;

        public int UserId
        {
            get => userId;
            set => userId = value;
        }

        public string FirstName
        {
            get => fname;
            set => fname = value;
        }

        public string LastName
        {
            get => lname;
            set => lname = value;
        }

        public User():base()
        {

        }

        public User(SqlTransaction trans) : base(trans)
        {

        }

        public User(int id) : base()
        {
            ResetProperties();
            var data = GetUser(id);
            FirstName = data.FirstName;
            LastName = data.LastName;
            UserId = data.UserId;
        }

        private void ResetProperties()
        {
            FirstName = "";
            LastName = "";
            UserId = -1;
        }

        public User GetUser(int id)
        {
            User user = new User();
            SqlConnection conn = new SqlConnection(user.ConnectionString);

            SqlCommand cmd = new SqlCommand("GetUser", conn)
            {
                CommandType = CommandType.StoredProcedure,
                Transaction = SqlTransaction
            };

            cmd.Parameters.AddWithValue("@userId", id);

            conn.Open();

            SqlDataAdapter sa = new SqlDataAdapter(cmd);

            DataSet ds = new DataSet();
            try
            {
                sa.Fill(ds);
                
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                conn.Close();
            }

            var dataRowCollection = ds.Tables[0]?.Rows;
            if (dataRowCollection != null)
                foreach (DataRow dataRow in dataRowCollection)
                {
                    user.UserId = Convert.ToInt32(dataRow["UserId"]);
                    user.FirstName = dataRow["FName"].ToString();
                    user.LastName = dataRow["LName"].ToString();
                }

            return user;

        }

        public List<User> GetUsers()
        {
            List<User> users = new List<User>();

            StringBuilder sb = new StringBuilder();
            sb.Append("select * from User");

            SqlConnection conn = new SqlConnection(ConnectionString);

            SqlCommand cmd = new SqlCommand(sb.ToString(), conn)
            {
                Transaction = SqlTransaction
            };

            conn.Open();

            SqlDataAdapter sa = new SqlDataAdapter(cmd);

            DataSet ds = new DataSet();
            try
            {
                sa.Fill(ds);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                conn.Close();
            }

            var dataRowCollection = ds.Tables[0]?.Rows;
            if (dataRowCollection != null)
                foreach (DataRow dataRow in dataRowCollection)
                {
                    User user = new User
                    {
                        UserId = Convert.ToInt32(dataRow["UserId"]),
                        FirstName = dataRow["FName"].ToString(),
                        LastName = dataRow["LName"].ToString()
                    };
                    users.Add(user);
                }

            return users;

        }
    }
}