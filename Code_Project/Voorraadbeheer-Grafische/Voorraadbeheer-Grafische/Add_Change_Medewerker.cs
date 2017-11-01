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
            else
            {
                MessageBox.Show("This is not a good telephone number!!");
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

                    //functie
                    //gender
                }
        }
        private void Change(int id)
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
                    //add gender



                    MessageBox.Show("Succesfully changed!");
                    Admin frm2 = new Admin(DATA.LoginID);
                    frm2.Show();

                    this.Close();
                }
        }
        private void CheckFieldInputs()
        {
            //Naam                  Bestaat er al een acc met deze naam?
            //Achternaam            Not null
            //Email                 Not null, Contains @
            //Tel nr                Tryparse?
            //Login naam            Bestaat er al een acc met deze inlog naam?
            //Wachtwoord            Zitten hier eisen aan?!
            //Functie               Staat het niet op None?
            //Geslacht              Staat dit niet op None?

            //call this before Change has been called!
            //if all ok call "Change(DATA.SelectedId)"
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
                Add();
            else if (func == Function.Wijzig)
            {
                Change(DATA.SelectedID_werknemers);
            }
        }
    }
}
public enum Function
{
    Wijzig,
    Nieuw
}
