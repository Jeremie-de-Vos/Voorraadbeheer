﻿using System;
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
        public Login()
        {
            InitializeComponent();
            frm = this;

            //Load - Data
            //Artikellen
            if (File.Exists(DATA.SavePath_Art))
                DATA.Artikellen = DATA.Load_Artikellen();
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
            for (int i = 0; i < DATA.Medewerkers.Count; i++)
            {
                //Check login naam + wachtwoord
                if (Naam_txt.Text == DATA.Medewerkers[i].LoginNaam && Wachtwoor_txt.Text == DATA.Medewerkers[i].Wachtwoord)
                {
                    Warning_lbl.Text = "Succes!!!!";
                    if (DATA.Medewerkers[i].Functie.ToString() == "Admin")
                    {
                        Admin frm = new Admin(DATA.Medewerkers[i].ID);
                        frm.Show();
                    }
                    else if (DATA.Medewerkers[i].Functie.ToString() == "Winkel")
                    {
                        MessageBox.Show("Winkel");
                    }
                    else if (DATA.Medewerkers[i].Functie.ToString() == "Magazijn")
                    {
                        MessageBox.Show("Magazijn");
                    }
                }
                //Check Login Naam
                else 
                    Warning_lbl.Text = "Geen juiste combinatie!";

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
