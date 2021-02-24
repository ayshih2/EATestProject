using System;
using System.Data;
using System.Data.SqlClient;

namespace EAAutoFramework.Helpers
{
    public static class DataHelperExtensions
    {
        // open the connection with the database
        public static SqlConnection DBConnect(this SqlConnection sqlConnection, string connectionString)
        {
            try
            {
                sqlConnection = new SqlConnection();
                sqlConnection.Open();
                return sqlConnection;
            } catch (Exception e)
            {
                LogHelpers.Write("error: " + e.Message);
            }
            return null;
        }

        // close the connection with database
        public static void DBClose(this SqlConnection sqlConnection)
        {
            try
            {
                sqlConnection.Close();
            } catch (Exception e)
            {
                LogHelpers.Write("error: " + e.Message);
            }
        }

        // execute query
        public static DataTable ExecuteQuery(this SqlConnection sqlConnection, string queryString)
        {
            DataSet dataset;
            try
            {
                // check for connection state
                if ((sqlConnection == null) || (sqlConnection != null 
                    && (sqlConnection.State == System.Data.ConnectionState.Closed 
                    || sqlConnection.State == System.Data.ConnectionState.Broken)))
                {
                    sqlConnection.Open();
                }
                SqlDataAdapter dataAdapter = new SqlDataAdapter();
                dataAdapter.SelectCommand = new SqlCommand(queryString, sqlConnection);
                dataAdapter.SelectCommand.CommandType = CommandType.Text;

                dataset = new DataSet();
                dataAdapter.Fill(dataset, "table");
                sqlConnection.Close();
                return dataset.Tables["table"];
            } catch (Exception e)
            {
                dataset = null;
                sqlConnection.Close();
                LogHelpers.Write("error: " + e.Message);
                return null;
            }  finally
            {
                sqlConnection.Close();
                dataset = null;
            }
        }
    }
}
