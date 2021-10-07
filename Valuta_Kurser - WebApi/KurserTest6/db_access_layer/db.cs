using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using KurserTest6.Models;


    namespace KurserTest6.db_access_layer
    {
        public class db
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["con"].ConnectionString);

            KurserModel kurs = new KurserModel();
            public void Add_Rate(KurserModel cs)

            {

                SqlCommand com = new SqlCommand("Sp_Customer_Add", con);

                com.CommandType = CommandType.StoredProcedure;

                com.Parameters.AddWithValue("@id", cs.id);

                com.Parameters.AddWithValue("@FromCurrency", cs.FromCurrency);

                com.Parameters.AddWithValue("@ToCurrency", cs.ToCurrency);

                com.Parameters.AddWithValue("@´Rate", cs.Rate);

                com.Parameters.AddWithValue("@UpdatedAt", cs.UpdatedAt);

                con.Open();

                com.ExecuteNonQuery();

                con.Close();



            }
        }
    }

