using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;


namespace Walmart.Prova.Data
{
    public class Util
    {


        public static DataTable GetDataTable(string sql)
        {
            DataTable dt = new DataTable();
            SqlConnection cnn = new SqlConnection(Configuracao.ConnectionString);
            cnn.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cnn;
            cmd.CommandText = sql;
            SqlDataReader reader = cmd.ExecuteReader();
            dt.Load(reader);
            reader.Close();
            cnn.Close();
            return dt;
        }

        public static string ExecuteScalar(string sql)
        {
            SqlConnection cnn = new SqlConnection(Configuracao.ConnectionString);
            cnn.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cnn;
            cmd.CommandText = sql;

            object value = cmd.ExecuteScalar();
            cnn.Close();
            if (value != null)
            {
                return value.ToString();
            }
            return "";
        }

        public static string ExecuteScalar(string sql, params SqlParameter[] parameters)
        {
            SqlConnection cnn = new SqlConnection(Configuracao.ConnectionString);
            cnn.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cnn;
            cmd.CommandText = sql;

            foreach (var parameter in parameters)
            {
                cmd.Parameters.Add(parameter);
            }

            object value = cmd.ExecuteScalar();
            cnn.Close();
            if (value != null)
            {
                return value.ToString();
            }
            return "";
        }

        public static int ExecuteNonQuery(string sql)
        {
            SqlConnection cnn = new SqlConnection(Configuracao.ConnectionString);
            cnn.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cnn;
            cmd.CommandText = sql;
            int rowsUpdated = cmd.ExecuteNonQuery();
            cnn.Close();

            return rowsUpdated;
        }

        public static int ExecuteNonQuery(string sql, params SqlParameter[] parameters)
        {
            SqlConnection cnn = new SqlConnection(Configuracao.ConnectionString);
            cnn.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cnn;
            cmd.CommandText = sql;

            foreach (var parameter in parameters)
            {
                cmd.Parameters.Add(parameter);
            }


            int rowsUpdated = cmd.ExecuteNonQuery();
            cnn.Close();

            return rowsUpdated;
        }

        public static IDataReader GetIDataReader(string sql)
        {
            SqlConnection cnn = new SqlConnection(Configuracao.ConnectionString);
            cnn.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cnn;
            cmd.CommandText = sql;
            IDataReader reader = cmd.ExecuteReader();

            return reader;
        }

    }
}
