using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Voorraadbeheer_Grafische
{
    public partial class Confirmation : Form
    {
        Form fm;
        public Confirmation(Form frm,string id_Name, string wijziging, string voorheen,string naar)
        {
            InitializeComponent();
            fm = frm;

            ID_Naam_lbl.Text = id_Name;
            Wijzigign_lbl.Text = wijziging;
            Voorheen_lbl.Text = voorheen;
            Naar_lbl.Text = naar;
        }

        private void Accepteer_lbl_Click(object sender, EventArgs e)
        {
            fm.Show();
            this.Close();
        }
        private void Close_btn_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Verandering zal niet worden opgeslagen!");
            fm.Show();
            this.Close();
        }
    }
}
