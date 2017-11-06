using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Voorraadbeheer_Grafische
{
    public partial class Login : Form
    {
        public static Login frm;
        private int Maxlogintry = 3;
        private int Currlogintry = 1;

        public Login()
        {
            InitializeComponent();
            frm = this;
            Naam_txt.Focus();

            //Load - Data
            //Artikellen
            if (File.Exists(DATA.SavePath_Art))
                DATA.Art_Rawdata();
            //DATA.Artikellen = DATA.Load_Artikellen();
            else
                DATA.Art_Rawdata();
            //Medewerkers
            if (File.Exists(DATA.SavePath_Medewerkers))
                DATA.Medewerkers = DATA.Load_Medewerkers();
            else
                DATA.Mede_Rawdata();
        }

        public void Check_fields()
        {
            if (Naam_txt.Text == "" && Wachtwoor_txt.Text == "")
                Warning_lbl.Text = "Vul eerst alles in om door te gaan!";
            else if (Naam_txt.Text == "")
                Warning_lbl.Text = "Er is geen naam ingevoerd!";
            else if (Wachtwoor_txt.Text == "")
                Warning_lbl.Text = "Er is nog geen wachtwoord ingevoerd!";

            if (Naam_txt.Text != "" && Wachtwoor_txt.Text != "")
                CheckLogin();
        }
        public void CheckLogin()
        {
            bool tst = true;
            for (int i = 0; i < DATA.Medewerkers.Count; i++)
            {
                //Check login naam + wachtwoord
                if (Naam_txt.Text == DATA.Medewerkers[i].LoginNaam && Wachtwoor_txt.Text == DATA.Medewerkers[i].Wachtwoord)
                {
                    Warning_lbl.Text = "Succes!!!!";
                    if (DATA.Medewerkers[i].Functie.ToString() == "Admin")
                    {
                        DATA.LoginID = DATA.Medewerkers[i].ID;
                        Admin frm = new Admin(DATA.Medewerkers[i].ID);
                        frm.Show();
                        this.Hide();
                    }
                    else if (DATA.Medewerkers[i].Functie.ToString() == "Winkel")
                    {
                        MessageBox.Show("Winkel");
                        DATA.LoginID = DATA.Medewerkers[i].ID;
                        Winkel_Beheer frm = new Winkel_Beheer(DATA.Medewerkers[i].ID);
                        frm.Show();
                        this.Hide();
                    }
                    else if (DATA.Medewerkers[i].Functie.ToString() == "Magazijn")
                    {
                        MessageBox.Show("Magazijn");
                    }
                }
                else
                    tst = false;
            }
            if (Currlogintry >= Maxlogintry+1 && !tst)
            {
                MessageBox.Show("Wachtwoord fout.\nEr is te vaak geprobeerd in te loggen");
                Environment.Exit(0);
            }
            else
            {
                Currlogintry++;
                Warning_lbl.Text = "Geen juiste combinatie! U kunt nog (" + (Maxlogintry - Currlogintry + 1) + ") keer proberen";
                Naam_txt.Text = null;
                Wachtwoor_txt.Text = null;
            }
        }

        //events
        private void button2_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }//close
        private void Login_btn_Click(object sender, EventArgs e)
        {
            Check_fields();
        }
    }
}
