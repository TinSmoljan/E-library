using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;
using Npgsql;
using NpgsqlTypes;
using System.Threading;

namespace E_knjiznica
{
    public partial class Informacije : Form
    {
        string connectionString;
        NpgsqlConnection connection;
        DataTable table1,table2;
        Thread th;
        public Informacije()
        {
            InitializeComponent();
            connectionString = ConfigurationManager.ConnectionStrings["E_knjiznica.Properties.Settings.E_KnjiznicaConnectionString"].ConnectionString;
            ucitaj();
            
        }
        private void ucitaj()
        {
            connection = new NpgsqlConnection(connectionString);
            Oib.Text = Login.password;
            Ime.Text = Login.ime;
            string query1, query2;
            query1 = "SELECT prezime FROM korisnik where oib='" + Login.password + "';";
            query2 = "SELECT adresa FROM korisnik where oib='" + Login.password + "';";
 
            NpgsqlCommand comand1 = new NpgsqlCommand(query1, connection);
            table1 = new DataTable();
            NpgsqlDataAdapter reader = new NpgsqlDataAdapter(comand1);
            reader.Fill(table1);
            foreach (DataRow red in table1.Rows)
            {
                foreach (var x in red.ItemArray)
                {
                    Prezime.Text = x.ToString();

                }
            }
            NpgsqlCommand comand2 = new NpgsqlCommand(query2, connection);
            table2 = new DataTable();
            NpgsqlDataAdapter reader2 = new NpgsqlDataAdapter(comand2);
            reader.Fill(table2);
            foreach (DataRow red2 in table2.Rows)
            {
                foreach (var y in red2.ItemArray)
                {
                    Adresa.Text = y.ToString();

                }
            }
        }

    }
}
