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
    public partial class Add_Change_Artikel : Form
    {
        //Variable
        public Function func;
        public int AccLogin;
        public bool accepeted = false;
        string accname;
        public Admin fm;

        //Main
        public Add_Change_Artikel(Admin fm1, Function Functie, int loginID)
        {
            InitializeComponent();
            func = Functie;
            AccLogin = loginID;

            if (Functie == Function.Nieuw)
            {
                //Functie_cb.SelectedIndex = 0;
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

            for (int i = 0; i < DATA.Medewerkers.Count; i++)
                if (DATA.Medewerkers[i].ID == DATA.LoginID)
                {
                    accname = DATA.Medewerkers[i].Naam;
                }
        }

        //Change - Add
        private void Add()
        {
            DATA.IDcounter++;

            DATA.Artikellen.Add(new Artikel(
                DATA.IDcounter,
                Naam_txt.Text,
                Merk_txt.Text,
                DATA.Cat(Categorie_cb.Text),
                double.Parse(InkoopPrijs_txt.Text),
                Int32.Parse(Btw_txt.Text),
                0,
                0,
                0,
                Maat_txt.Text,
                Int32.Parse(Voorraad_txt.Text),
                "",
                accname
                ));

            Admin frm2 = new Admin(DATA.LoginID);
            frm2.Show();

            this.Close();
        }
        private void setup(int id)
        {
            for (int i = 0; i < DATA.Artikellen.Count; i++)
            {
                if (DATA.Artikellen[i].ID == id)
                {
                    Naam_txt.Text = DATA.Artikellen[i].Naam;
                    Merk_txt.Text = DATA.Artikellen[i].Merk;
                    InkoopPrijs_txt.Text = DATA.Artikellen[i].Inkoopprijs.ToString();
                    Btw_txt.Text = DATA.Artikellen[i].BTW.ToString();
                    Maat_txt.Text = DATA.Artikellen[i].Maat;
                    Voorraad_txt.Text = DATA.Artikellen[i].Voorraad.ToString();

                    //Categorie
                    if (DATA.Artikellen[i].Categorie == Art_Categorie.Zaal)
                        Categorie_cb.SelectedIndex = 0;
                    else if (DATA.Artikellen[i].Categorie == Art_Categorie.Straat)
                        Categorie_cb.SelectedIndex = 1;
                    else if (DATA.Artikellen[i].Categorie == Art_Categorie.Veld)
                        Categorie_cb.SelectedIndex = 2;
                }
            }
        }
        private void ApplyChange(int id)
        {
            for (int i = 0; i < DATA.Artikellen.Count; i++)
                if (DATA.Artikellen[i].ID == id)
                {
                    DATA.Artikellen[i].Naam = Naam_txt.Text;
                    DATA.Artikellen[i].Merk = Merk_txt.Text;
                    DATA.Artikellen[i].Categorie = DATA.Cat(Categorie_cb.Text);
                    DATA.Artikellen[i].Inkoopprijs = Int32.Parse(InkoopPrijs_txt.Text);
                    DATA.Artikellen[i].BTW = Int32.Parse(Btw_txt.Text);
                    DATA.Artikellen[i].Maat = Maat_txt.Text;
                    DATA.Artikellen[i].Voorraad = Int32.Parse(Voorraad_txt.Text);

                    DATA.Artikellen[i].LaatstGewijzigd = DateTime.Now.ToString();
                    DATA.Artikellen[i].GewijzigdDoor = accname;

                    MessageBox.Show("Succesfully changed!");
                    Admin frm2 = new Admin(DATA.LoginID);
                    frm2.Show();

                    this.Close();
                }
        }
        private void CheckFieldInputs(Function function)
        {
            //Set
            string naam = Naam_txt.Text;
            string merk = Merk_txt.Text;
            Art_Categorie categorie = DATA.Cat(Categorie_cb.Text);
            string inkoopprijs = InkoopPrijs_txt.Text;
            string btw = Btw_txt.Text;
            string maat = Maat_txt.Text;
            string voorraad = Voorraad_txt.Text;

            //Check inputfields
            if (naam != String.Empty && merk != String.Empty && inkoopprijs != String.Empty && btw != String.Empty && maat != String.Empty && voorraad != String.Empty)
            {
                for (int i = 0; i < DATA.Artikellen.Count; i++)
                    if (DATA.Artikellen[i].Naam.ToLower() == naam.ToLower() && function == Function.Nieuw)
                    {
                        Message_lbl.Text = "Er bestaat al een artikel met deze naam!";
                        accepeted = false;
                    }
                    else
                        accepeted = true;

                if (accepeted)
                    if (function == Function.Nieuw)
                        Add();
                    else if (function == Function.Wijzig)
                        ApplyChange(DATA.SelectedID_werknemers);
            }
            else if (naam == String.Empty)
                Message_lbl.Text = "Er is nog geen NAAM ingevuld!";
            else if (merk == String.Empty)
                Message_lbl.Text = "Er is nog geen MERK ingevuld!";
            else if (inkoopprijs == String.Empty)
                Message_lbl.Text = "Er is nog geen INKOOP PRIJS gegeven!";
            else if (btw == String.Empty)
                Message_lbl.Text = "Er is nog geen BTW gegeven!";
            else if (maat == String.Empty)
                Message_lbl.Text = "Er is nog geen MAAT ingevuld!";
            else if (voorraad == String.Empty)
                Message_lbl.Text = "Er is nog geen VOORRAAD gegeven!";
        }

        //Events
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

        //Numbers - events
        private void InkoopPrijs_txt_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar) || e.KeyChar == (char)Keys.Back || e.KeyChar == '.'))
            { e.Handled = true; }
            TextBox txtDecimal = sender as TextBox;
            if (e.KeyChar == '.' && txtDecimal.Text.Contains("."))
            {
                e.Handled = true;
            }
        }

        private void Btw_txt_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
                Message_lbl.Text = "Dat is geen nummer!";
            }
            else
                Message_lbl.Text = "";
        }
        private void Maat_txt_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
                Message_lbl.Text = "Dat is geen nummer!";
            }
            else
                Message_lbl.Text = "";
        }
        private void Voorraad_txt_KeyPress(object sender, KeyPressEventArgs e)
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
public enum Function1
{
    Wijzig,
    Nieuw
}
