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
    public partial class NoviKorisnik : Form
    {
        string connectionString;
        Thread th;

        public NoviKorisnik()
        {
            InitializeComponent();
            connectionString = ConfigurationManager.ConnectionStrings["E_knjiznica.Properties.Settings.E_KnjiznicaConnectionString"].ConnectionString;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
            th = new Thread(povratakNazad);
            th.SetApartmentState(ApartmentState.STA);
            th.Start();
        }
        private void povratakNazad(object obj)
        {
            Application.Run(new PocetnaZaposlenika());
        }

        private void button1_Click(object sender, EventArgs e)
        {
            NpgsqlConnection connection = new NpgsqlConnection(connectionString);
            string query = "insert into korisnik (oib,Ime,prezime,adresa) values('" + this.OIB.Text + "','" + this.Ime.Text + "','" + this.Prezime.Text + "','" + this.Adresa.Text + "');";
            connection.Open();
            NpgsqlCommand command = new NpgsqlCommand(query, connection);
            NpgsqlDataReader reader;
            reader = command.ExecuteReader();
            connection.Close();
            MessageBox.Show("Korisnik dodan");
           
        }
    }
}
