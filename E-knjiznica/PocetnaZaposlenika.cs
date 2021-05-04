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
    public partial class PocetnaZaposlenika : Form
    {
        Thread th;
        public PocetnaZaposlenika()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
            th = new Thread(openFormKorisnici);
            th.SetApartmentState(ApartmentState.STA);
            th.Start();
        }
        private void openFormKorisnici(object obj)
        {
            Application.Run(new Korisnici());
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Close();
            th = new Thread(openFormKnjige);
            th.SetApartmentState(ApartmentState.STA);
            th.Start();
        }
        private void openFormKnjige(object obj)
        {
            Application.Run(new Knjige());
        }

        private void button5_Click(object sender, EventArgs e)
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
            th = new Thread(openFormDodajKorisnika);
            th.SetApartmentState(ApartmentState.STA);
            th.Start();
        }
        private void openFormDodajKorisnika(object obj)
        {
            Application.Run(new NoviKorisnik());
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
            th = new Thread(openFormZaduzenja);
            th.SetApartmentState(ApartmentState.STA);
            th.Start();
        }
        private void openFormZaduzenja(object obj)
        {
            Application.Run(new Zaduzenja());
        }
    }   
}
