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
    public partial class Add_Change_Medewerker : Form
    {
        //Variable
        public Function func;
        public int AccLogin;
        public bool accepeted = false;
        public Admin fm;

        //Main
        public Add_Change_Medewerker(Admin fm1, Function Functie,int loginID)
        {
            InitializeComponent();
            func = Functie;
            AccLogin = loginID;

            if (Functie == Function.Nieuw)
            {
                Functie_cb.SelectedIndex = 0;
                label2.Text = "Medewerker Toevoegen";
                Accepteer_lbl.Text = "Add";

            }
            else if (Functie == Function.Wijzig)
            {
                label2.Text = "Medewerker Wijzigen";
                Accepteer_lbl.Text = "Apply";
                setup(DATA.SelectedID_werknemers);
            }
            fm = fm1;
        }

        //Change-Add
        private void Add()
        {
            DATA.IDcounter++;

            int output;
            if (Int32.TryParse(Telefoonnr_txt.Text, out output))
            {
            }


            DATA.Medewerkers.Add(new Medewerker(
            DATA.IDcounter,
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

            Admin frm2 = new Admin(DATA.LoginID);
            frm2.Show();

            this.Close();
        }
        private void setup(int id)
        {
            for (int i = 0; i < DATA.Medewerkers.Count; i++)
                if (DATA.Medewerkers[i].ID == id)
                {

                    Naam_txt.Text = DATA.Medewerkers[i].Naam;
                    Achternaam_txt.Text = DATA.Medewerkers[i].Achternaam;
                    Email_txt.Text = DATA.Medewerkers[i].Email;
                    Telefoonnr_txt.Text = DATA.Medewerkers[i].Telnr.ToString();
                    LoginNaam_txt.Text = DATA.Medewerkers[i].LoginNaam;
                    Wachtwoord_txt.Text = DATA.Medewerkers[i].Wachtwoord;

                    //Functie
                    if (DATA.Medewerkers[i].Functie == Medwerker_Function.Admin)
                        Functie_cb.SelectedIndex = 3;
                    else if (DATA.Medewerkers[i].Functie == Medwerker_Function.Magazijn)
                        Functie_cb.SelectedIndex = 2;
                    else if (DATA.Medewerkers[i].Functie == Medwerker_Function.Winkel)
                        Functie_cb.SelectedIndex = 1;

                    //Gender
                    if (DATA.Medewerkers[i].Geslacht == "Man")
                        Geslacht_cb.SelectedIndex = 0;
                    else if (DATA.Medewerkers[i].Geslacht == "Vrouw")
                        Geslacht_cb.SelectedIndex = 1;
                }
        }
        private void ApllyChange(int id)
        {
            for (int i = 0; i < DATA.Medewerkers.Count; i++)
                if (DATA.Medewerkers[i].ID == id)
                {

                    DATA.Medewerkers[i].Naam = Naam_txt.Text;
                    DATA.Medewerkers[i].Achternaam = Achternaam_txt.Text;
                    DATA.Medewerkers[i].Email = Email_txt.Text;
                    DATA.Medewerkers[i].Telnr = Int32.Parse(Telefoonnr_txt.Text);
                    DATA.Medewerkers[i].LoginNaam = LoginNaam_txt.Text;
                    DATA.Medewerkers[i].Wachtwoord = Wachtwoord_txt.Text;

                    DATA.Medewerkers[i].Functie = DATA.Func(Functie_cb.Text);
                    DATA.Medewerkers[i].Geslacht = Geslacht_cb.Text;



                    MessageBox.Show("Succesfully changed!");
                    Admin frm2 = new Admin(DATA.LoginID);
                    frm2.Show();

                    this.Close();
                }
        }
        private void CheckFieldInputs(Function function)
        {
            string naam = Naam_txt.Text;
            string achternaam = Achternaam_txt.Text;
            string email = Email_txt.Text;
            string telefoonnr = Telefoonnr_txt.Text;

            string loginnaam = LoginNaam_txt.Text;
            string wachtwoord = Wachtwoord_txt.Text;
            Medwerker_Function func = DATA.Func(Functie_cb.Text);
            string geslacht = Geslacht_cb.Text;

            if (naam != String.Empty && achternaam != String.Empty && email != String.Empty && telefoonnr != String.Empty && loginnaam != String.Empty && wachtwoord != String.Empty && geslacht != String.Empty)
            {
                for (int i = 0; i < DATA.Medewerkers.Count; i++)
                    if (DATA.Artikellen[i].Naam.ToLower() == naam.ToLower())
                    {
                        Message_lbl.Text = "Er bestaat al een Medewerker met deze naam!";
                        accepeted = false;
                        if(DATA.Medewerkers[i].LoginNaam.ToLower() == loginnaam.ToLower() && function == Function.Nieuw)
                        {
                            Message_lbl.Text = "Er bestaat al een Medewerker met deze login naam!";
                            accepeted = false;
                        }
                    }
                    else
                        accepeted = true;

                if (accepeted)
                    if (function == Function.Nieuw)
                        Add();
                    else if (function == Function.Wijzig)
                        ApllyChange(DATA.SelectedID_werknemers);
            }
            else if (naam == String.Empty)
                Message_lbl.Text = "Er is nog geen NAAM ingevuld!";
            else if (achternaam == String.Empty)
                Message_lbl.Text = "Er is nog geen ACHTERNAAM ingevuld!";
            else if (email == String.Empty)
                Message_lbl.Text = "Er is nog geen EMAIL ADRES ingevuld!";
            else if (telefoonnr == String.Empty)
                Message_lbl.Text = "Er is nog geen TELEFOON NR ingevuld!";
            else if (loginnaam == String.Empty)
                Message_lbl.Text = "Er is nog geen LOGIN NAAM ingevuld!";
            else if (wachtwoord == String.Empty)
                Message_lbl.Text = "Er is nog geen WACHTWOORD ingevuld!";
            else if (Functie_cb.Text == "None")
                Message_lbl.Text = "Er is nog geen FUNCTIE ingevuld!";
            else if (geslacht == String.Empty)
                Message_lbl.Text = "Er is nog geen GESLACHT ingevuld!";
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
            if (func == Function.Nieuw)
                CheckFieldInputs(Function.Nieuw);
            else if (func == Function.Wijzig)
            {
                CheckFieldInputs(Function.Wijzig);
            }
        }

        private void Telefoonnr_txt_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
                Message_lbl.Text = "Dat is geen nummer!";
            }
            else
                Message_lbl.Text = "";
        }
    }
}
public enum Function
{
    Wijzig,
    Nieuw
}
