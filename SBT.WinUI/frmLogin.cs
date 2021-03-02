using SBT.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SBT.WinUI
{
    public partial class frmLogin : Form
    {
        APIService _service = new APIService("Korisnici");
        public frmLogin()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private async void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                KorisniciModel  korisnik = await _service.Authenticate<KorisniciModel>(txtUsername.Text, txtPassword.Text);
                bool userIsAdmin = false;
                if (korisnik != null)
                {
                    foreach (var item in korisnik.KorisniciUloge)
                    {
                        if (item.Uloga.Naziv == "admin")
                        {
                            userIsAdmin = true;
                        }
                    }
                    if (userIsAdmin)
                    {
                        MessageBox.Show("Dobrodosli " + korisnik.Ime + " " + korisnik.Prezime);
                        DialogResult = DialogResult.OK;
                    } else
                    {
                        MessageBox.Show("Samo administratori imaju pristup desktop aplikaciji", "Autentifikacija", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Pogresan username ili password", "Autentifikacija", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Authentikacija", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
