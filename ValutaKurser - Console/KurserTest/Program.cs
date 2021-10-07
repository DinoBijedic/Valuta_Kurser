using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Net;
using Newtonsoft.Json;

namespace KurserTest
{
    class Program
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ProcessAPI();
        }
        
        protected void ProcessAPI()
        {
            string url = "https://valutakurser.azurewebsites.net/ValutaKurs";
            ServicePointManager.Expect100Continue = true;
            ServicePointManager.SecurityProtocol = (SecurityProtocolType)3072;
            string json = (new WebClient()).DownloadString(url);
            List<Kurser> res = JsonConvert.DeserializeObject<List<Kurser>>(json);
            foreach (var kurser in res)
            {
                string conString = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
                string query = "INSERT INTO dbo.ValutaKurser VALUES (@id,@fromCurrency,@toCurrency,@rate,@updatedAt)";
                using (SqlConnection con = new SqlConnection(conString))
                {
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@id", kurser.id);
                    cmd.Parameters.AddWithValue("@fromCurrency", kurser.FromCurrency);
                    cmd.Parameters.AddWithValue("@toCurrency", kurser.ToCurrency);
                    cmd.Parameters.AddWithValue("@rate", kurser.Rate);
                    cmd.Parameters.AddWithValue("@updatedAt", kurser.UpdatedAt);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
            }
        }

        public class Kurser
        {
            public int id { get; set; }
            public string FromCurrency { get; set; }
            public string ToCurrency { get; set; }
            public int Rate { get; set; }
            public DateTime UpdatedAt { get; set; }
        }
    }
}
