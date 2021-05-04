using System;
using System.Collections.Generic;
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
    public partial class Knjige : Form
    {
        string connectionString;
        NpgsqlConnection connection;
        DataTable table;
        Thread th;

        public Knjige()
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
            NpgsqlDataAdapter reader = new NpgsqlDataAdapter("SELECT * FROM knjiga", connection);
            table = new DataTable();
            reader.Fill(table);
            BindingSource bsource = new BindingSource();
            bsource.DataSource = table;
            dataGridView1.DataSource = bsource;
            reader.Update(table);

        }

    
    }
}
