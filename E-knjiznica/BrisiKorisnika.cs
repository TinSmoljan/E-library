
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
    public partial class BrisiKorisnika : Form
    {
        string connectionString;
        Thread th;

        public BrisiKorisnika()
        {
            InitializeComponent();
            connectionString = ConfigurationManager.ConnectionStrings["E_knjiznica.Properties.Settings.E_KnjiznicaConnectionString"].ConnectionString;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            NpgsqlConnection connection = new NpgsqlConnection(connectionString);
            string query = "DELETE FROM korisnik WHERE oib='" + this.OIB.Text + "';";
            connection.Open();
            NpgsqlCommand command = new NpgsqlCommand(query, connection);
            NpgsqlDataReader reader;
            reader = command.ExecuteReader();
            connection.Close();
            MessageBox.Show("Korisnik izbrisan");
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
            Application.Run(new Korisnici());
        }
    }
}
