using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace SharedFood
{
    public abstract class Repository
    {
        protected string ConnectionString = ConfigurationManager.ConnectionStrings["db"].ConnectionString;

        private CommandType GetCommandType(SqlCommand sqlcommand)
        {
            if (sqlcommand.CommandText.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries).Length == 1)
                return CommandType.StoredProcedure;
            else
                return CommandType.Text;
        }

        #region ExecuteNonQuery

        protected int ExecuteNonQuery(SqlCommand command)
        {
            using (SqlConnection cnn = new SqlConnection(ConnectionString))
            {
                command.Connection = cnn;
                command.CommandType = GetCommandType(command);

                command.Connection.Open();
                return command.ExecuteNonQuery();
            }
        }

        protected int ExecuteNonQuery(SqlConnection conn, SqlTransaction trans, SqlCommand command)
        {
            command.Connection = conn;
            command.Transaction = trans;
            command.CommandType = GetCommandType(command);
            return command.ExecuteNonQuery();
        }


        #endregion

        #region ExecuteScalar

        protected object ExecuteScalar(SqlCommand command)
        {
            using (SqlConnection cnn = new SqlConnection(ConnectionString))
            {
                command.Connection = cnn;
                command.CommandType = GetCommandType(command);
                command.Connection.Open();
                return command.ExecuteScalar();
            }
        }

        protected object ExecuteScalar(SqlConnection conn, SqlTransaction trans, SqlCommand command)
        {
            command.Connection = conn;
            command.CommandType = GetCommandType(command);
            command.Transaction = trans;
            return command.ExecuteScalar();
        }

        #endregion

        #region ExecuteDataSet

        protected DataSet ExecuteDataSet(SqlCommand command)
        {
            using (SqlConnection cnn = new SqlConnection(ConnectionString))
            {
                command.Connection = cnn;
                command.CommandType = GetCommandType(command);
                SqlDataAdapter da = new SqlDataAdapter(command);
                DataSet ds = new DataSet();
                command.Connection.Open();
                da.Fill(ds);
                return ds;
            }
        }

        #endregion

        #region ExecuteDataReader

        protected SqlDataReader ExecuteReader(SqlCommand command)
        {
            command.Connection = new SqlConnection(ConnectionString);
            command.CommandType = GetCommandType(command);
            command.Connection.Open();
            return command.ExecuteReader(CommandBehavior.CloseConnection);
        }

        #endregion

        #region EvaluateParameter

        protected object EvaluateParameter(string value)
        {
            if (string.IsNullOrEmpty(value))
                return DBNull.Value;
            else
                return value;
        }

        protected object EvaluateParameter(double value)
        {
            if (value == 0)
                return DBNull.Value;
            else
                return value;
        }

        protected object EvaluateParameter(decimal value)
        {
            if (value == 0)
                return DBNull.Value;
            else
                return value;
        }

        protected object EvaluateParameter(Int64 value)
        {
            if (value == 0)
                return DBNull.Value;
            else
                return value;
        }

        protected object EvaluateParameter(int value)
        {
            if (value == 0)
                return DBNull.Value;
            else
                return value;
        }

        protected object EvaluateParameter(byte value)
        {
            if (value == 0)
                return DBNull.Value;
            else
                return value;
        }

        protected object EvaluateParameter(DateTime value)
        {
            if (value.Year == 1)
                return DBNull.Value;
            else
                return value;
        }

        protected object EvaluateParameter(Guid value)
        {
            if (value.ToString() == "00000000-0000-0000-0000-000000000000")
                return DBNull.Value;
            else
                return value;
        }

        #endregion

    }
}