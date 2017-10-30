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
    public partial class Add_Medewerker : Form
    {
        public Form fm;
        public Add_Medewerker(Form fm1)
        {
            InitializeComponent();
            fm = fm1;
            Functie_cb.SelectedIndex = 0;
        }

        int IDcounter = 10;

        private void Add()
        {
            int output;
            if (Int32.TryParse(Telefoonnr_txt.Text, out output))
            {
            }
            else
            {
                MessageBox.Show("This is not a good telephone number!!");
            }

                IDcounter++;
            DATA.Medewerkers.Add(new Medewerker(
                IDcounter,
                Naam_txt.Text,
                Achternaam_txt.Text,
                Email_txt.Text,
                Geslacht_cb.Text,
                DATA.Func(Functie_cb.Text),
                LoginNaam_txt.Text,
                Wachtwoord_txt.Text,
                "img path",
                output,

                DateTime.Now.ToShortDateString().ToString(),
                "",
                ""));
            fm.Refresh();
            fm.Show();
            this.Close();
        }

        //General-events
        private void Close_btn_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Verandering zal niet worden opgeslagen!");
            fm.Show();
            this.Close();
        }
        private void Accepteer_lbl_Click(object sender, EventArgs e)
        {
            Add();
        }
    }
}
