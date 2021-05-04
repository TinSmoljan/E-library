using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace E_knjiznica
{
    public partial class PocetnaKorisnika : Form
    {
        Thread th;
        public PocetnaKorisnika()
        {
            InitializeComponent();

        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
            th = new Thread(vratiLogin);
            th.SetApartmentState(ApartmentState.STA);
            th.Start();
        }
        private void vratiLogin(object obj)
        {
            Application.Run(new Login());
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            th = new Thread(formaInformacija);
            th.SetApartmentState(ApartmentState.STA);
            th.Start();
        }
        private void formaInformacija(object obj)
        {
            Application.Run(new Informacije());
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
            th = new Thread(formaKnjiga);
            th.SetApartmentState(ApartmentState.STA);
            th.Start();
        }
        private void formaKnjiga(object obj)
        {
            Application.Run(new KnjigeKorisnik());
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
            th = new Thread(formaZaduzenjaKorisnika);
            th.SetApartmentState(ApartmentState.STA);
            th.Start();
        }
        private void formaZaduzenjaKorisnika(object obj)
        {
            Application.Run(new ZaduzenjeKorisnika());
        }
    }
}
