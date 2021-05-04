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
    public partial class ZaduzenjeKorisnika : Form
    {
        string connectionString;
        NpgsqlConnection connection;
        DataTable table;
        Thread th;
        public ZaduzenjeKorisnika()
        {
            InitializeComponent();
            connectionString = ConfigurationManager.ConnectionStrings["E_knjiznica.Properties.Settings.E_KnjiznicaConnectionString"].ConnectionString;
            ucitaj();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void ucitaj()
        {
            table = new DataTable();
            connection = new NpgsqlConnection(connectionString);
            NpgsqlCommand cmdDatabase = new NpgsqlCommand("SELECT * FROM zaduzenje WHERE id='"+Login.password+"';", connection);
            NpgsqlDataAdapter reader = new NpgsqlDataAdapter();
            reader.SelectCommand = cmdDatabase;
            reader.Fill(table);
            BindingSource bsource = new BindingSource();
            bsource.DataSource = table;
            dataGridView1.DataSource = bsource;
            reader.Update(table);
        }
    }
}
