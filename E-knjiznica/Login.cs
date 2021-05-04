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

    public partial class Login : Form
    {
        string connectionString;
        NpgsqlConnection connection;
        DataTable table;
        Thread th;
        public static string password,ime;
        
        public Login()
        {
            InitializeComponent();
            connectionString = ConfigurationManager.ConnectionStrings["E_knjiznica.Properties.Settings.E_KnjiznicaConnectionString"].ConnectionString;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Prijavi();
        }
        private void Prijavi()
        { 
            int counter=0;
            using (connection = new NpgsqlConnection(connectionString))
            {
                using (NpgsqlDataAdapter reader = new NpgsqlDataAdapter("SELECT oib,ime FROM zaposlenik", connection))
                {
                    table = new DataTable();
                    reader.Fill(table);

                    foreach (DataRow red in table.Rows)
                    {
                        foreach (var x in red.ItemArray)
                        {
                            //int result = string.Compare(x.ToString().ToLower().Trim(), Username.Text.ToLower().Trim());
                            if (x.ToString() == Password.Text || x.ToString().ToLower().Trim()==Username.Text.ToLower().Trim())
                            {
                                counter+=1;
                            }
                            if (counter == 2)
                            {
                                posaljiUFormuAdmina();
                            }
                            //MessageBox.Show(x.ToString(),counter.ToString());
                            //MessageBox.Show(result.ToString(), x.ToString());
                            //MessageBox.Show(Username.Text, x.ToString());
                        }
                        counter = 0;
                    }
                }
                using (NpgsqlDataAdapter reader = new NpgsqlDataAdapter("SELECT oib,ime FROM korisnik", connection))
                {
                    table = new DataTable();
                    reader.Fill(table);

                    foreach (DataRow red in table.Rows)
                    {
                        foreach (var x in red.ItemArray)
                        {

                            if (x.ToString() == Password.Text || x.ToString().ToLower().Trim() == Username.Text.ToLower().Trim())
                            {
                                counter+=1;
                            }
                            if (counter == 2)
                            {
                                posaljiUFormuKorisnika();
                            }
                        }
                        counter = 0;
                    }
                }
            }

        }
        void posaljiUFormuAdmina()
        {
            /*this.Hide();
            PocetnaZaposlenika form2 = new PocetnaZaposlenika();
            form2.ShowDialog();*/

            this.Close();
            th = new Thread(openFormZaposlenik);
            th.SetApartmentState(ApartmentState.STA);
            th.Start();
            
        }
        void posaljiUFormuKorisnika()
        {
            /* this.Hide();
             PocetnaKorisnika form2 = new PocetnaKorisnika();
             form2.ShowDialog();*/
            this.Hide();
            th = new Thread(openFormKorsinik);
            th.SetApartmentState(ApartmentState.STA);
            th.Start();
            password = Password.Text;
            ime = Username.Text;

        }

        private void openFormZaposlenik(object obj)
        {
            Application.Run(new PocetnaZaposlenika());
        }

        private void openFormKorsinik(object obj)
        {

            Application.Run(new PocetnaKorisnika());
        }
    }
}
