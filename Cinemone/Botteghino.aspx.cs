using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using static System.Net.Mime.MediaTypeNames;

namespace Cinemone
{
    public partial class Botteghino : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["cinema"].ConnectionString.ToString();
            SqlConnection conn = new SqlConnection(connectionString);
            string selectedValue = DropDownList2.SelectedValue;
            try
            {
               
                conn.Open(); //proviamo ad aprire la connessione con il db
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                


                // questa stringa genererà un errore in quanto IdCustomer non esiste!
                cmd.CommandText = "insert into Cinema(Nome,Cognome,Sala_nord,Sala_est,Sala_sud)"+"Values(@Nome, @Cognome, @Sala_nord, @Sala_est, @Sala_sud)";

                cmd.Parameters.AddWithValue("@Nome", Nome.Text);
                cmd.Parameters.AddWithValue("@Cognome", Cognome.Text);
                cmd.Parameters.AddWithValue("@Sala_nord", selectedValue == "Nord" ? true : false);
                cmd.Parameters.AddWithValue("@Sala_est", selectedValue == "Est" ? true : false);
                cmd.Parameters.AddWithValue("@Sala_sud", selectedValue == "Sud" ? true : false);
                cmd.Parameters.AddWithValue("@Ridotto", selectedValue == "Ridotto" ? true : false);
                cmd.ExecuteNonQuery();


                stampaRegistrazione.InnerHtml = "Utente Registrato ";




            }
            catch
            {
                Response.Write("Errore");
              
            }
            finally
            {
                conn.Close();
            }

        }


        protected void Button2_Click(object sender, EventArgs e)
        {



        }


        protected void Button3_Click(object sender, EventArgs e)
        {



        }






        protected void Button4_Click(object sender, EventArgs e)
        {



        }






    }