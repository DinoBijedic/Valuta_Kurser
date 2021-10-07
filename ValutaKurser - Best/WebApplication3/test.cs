using Newtonsoft.Json;
using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Net;
using System.Web.UI;

namespace WebApplication3
{
    public class test
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                ServicePointManager.Expect100Continue = true;
                ServicePointManager.SecurityProtocol = (SecurityProtocolType)3072;
                string json = (new WebClient()).DownloadString("https://valutakurser.azurewebsites.net/ValutaKurs");
                DataTable dt = JsonConvert.DeserializeObject<DataTable>(json);
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    string con = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
                    using (SqlConnection conn = new SqlConnection(con))
                    {
                        string sql = "INSERT INTO ValutaKurser VALUES(@id, @ToCurrency, @FromCurrency, @Rate, @UpdatedAt)";
                        using (SqlCommand cmd = new SqlCommand(sql, conn))
                        {
                            cmd.Parameters.AddWithValue("@id", dt.Rows[i]["id"].ToString());
                            cmd.Parameters.AddWithValue("@ToCurrency", dt.Rows[i]["ToCurrency"].ToString());
                            cmd.Parameters.AddWithValue("@FromCurrency", dt.Rows[i]["FromCurrency"].ToString());
                            cmd.Parameters.AddWithValue("@Rate", dt.Rows[i]["Rate"].ToString());
                            cmd.Parameters.AddWithValue("@UpdatedAt", dt.Rows[i]["UpdatedAt"].ToString());
                            conn.Open();
                            cmd.ExecuteNonQuery();
                            conn.Close();
                        }
                    }
                }
            }
        }

    }
}