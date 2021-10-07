using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using KurserTest8.Models;

namespace KurserTest8.db_access_layer
{
    public class db
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["con"].ConnectionString);

        public void AddKurs(Kurser cs)
        {
            SqlCommand com = new SqlCommand("InsertDataWebApi", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@id", cs.id);
            com.Parameters.AddWithValue("@FromCurrency",cs. FromCurrency);
            com.Parameters.AddWithValue("@ToCurrency", cs.ToCurrency);
            com.Parameters.AddWithValue("@Rate", cs.Rate);
            com.Parameters.AddWithValue("@UpdatedAt", cs.UpdatedAt);
            con.Open();
            com.ExecuteNonQuery();
            con.Close();
        }
    }
}