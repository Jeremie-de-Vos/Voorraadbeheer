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
    public partial class Winkel_Beheer : Form
    {
        //Variable
        public static int ID;
        public int selectedrow;
        public static Login lg;

        //Main
        public Winkel_Beheer(int id)
        {
            InitializeComponent();
            ID = id;

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

            account_Setup();
            Datagrid_VoorraadDetail_Setup();
            Null_Voorraad_Checkbox.Checked = true;
        }

        //Setup
        private void account_Setup()
        {
            //Setting up acc info
            for (int i = 0; i < DATA.Medewerkers.Count; i++)
                if (ID == DATA.Medewerkers[i].ID)
                {
                    GebruikersNaam_lbl.Text = DATA.Medewerkers[i].Naam + " " + DATA.Medewerkers[i].Achternaam;
                    DATA.Medewerkers[i].LaatstIngelogd = DateTime.Today.ToShortDateString().ToString();
                    DATA.Medewerkers[i].LaatstVersie = "Grafische";
                }
        }

        //Voorraad
        private void Datagrid_VoorraadDetail_Setup()
        {
            //Check null voorrraad and filter
            Datagrid_Artikellen.Rows.Clear();

            //If null
            if (Null_Voorraad_Checkbox.Checked)
            {
                for (int i = 0; i < DATA.Artikellen.Count; i++)
                    Datagrid_Artikellen.Rows.Add(
                        DATA.Artikellen[i].ID,
                        DATA.Artikellen[i].Naam,
                        DATA.Artikellen[i].Merk,
                        DATA.Artikellen[i].Maat,
                        DATA.Artikellen[i].Voorraad,
                        DATA.Artikellen[i].Categorie,
                        DATA.Artikellen[i].Inkoopprijs
                        );
            }
            else
            {
                //if not null
                for (int i = 0; i < DATA.Artikellen.Count; i++)
                    if (DATA.Artikellen[i].Voorraad != 0)
                    {
                        Datagrid_Artikellen.Rows.Add(
                            DATA.Artikellen[i].ID,
                            DATA.Artikellen[i].Naam,
                            DATA.Artikellen[i].Merk,
                            DATA.Artikellen[i].Maat,
                            DATA.Artikellen[i].Voorraad,
                            DATA.Artikellen[i].Categorie,
                            DATA.Artikellen[i].Inkoopprijs
                            );
                    }
            }
            Datagrid_Artikellen.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            DATA.Save_Artikellen(DATA.Artikellen);
        }

        //Search
        private void Search()
        {
            string search_txt = Searchbar_txt.Text.ToLower();
            Datagrid_Artikellen.Rows.Clear();
            String searchValue = search_txt;

            //Check if null voorraad
            if (Null_Voorraad_Checkbox.Checked)
            {
                for (int i = 0; i < DATA.Artikellen.Count; i++)
                    if (DATA.Artikellen[i].Naam.ToLower().Contains(searchValue))
                    {
                        Datagrid_Artikellen.Rows.Add(
                        DATA.Artikellen[i].ID,
                        DATA.Artikellen[i].Naam,
                        DATA.Artikellen[i].Merk,
                        DATA.Artikellen[i].Maat,
                        DATA.Artikellen[i].Voorraad,
                        DATA.Artikellen[i].Categorie,
                        DATA.Artikellen[i].Inkoopprijs);
                    }
            }
            else
            {
                for (int i = 0; i < DATA.Artikellen.Count; i++)
                    if (DATA.Artikellen[i].Naam.ToLower().Contains(searchValue) && DATA.Artikellen[i].Voorraad != 0)
                    {
                        Datagrid_Artikellen.Rows.Add(
                        DATA.Artikellen[i].ID,
                        DATA.Artikellen[i].Naam,
                        DATA.Artikellen[i].Merk,
                        DATA.Artikellen[i].Maat,
                        DATA.Artikellen[i].Voorraad,
                        DATA.Artikellen[i].Categorie,
                        DATA.Artikellen[i].Inkoopprijs);
                    }
            }
            Datagrid_Artikellen.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }
        private void Searchbar_txt_TextChanged(object sender, EventArgs e)
        {
            Search();
        }

        //General events
        private void Close_btn_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }
        private void Null_Voorraad_Checkbox_CheckedChanged(object sender, EventArgs e)
        {
            Search();
        }

        //Change voorraad - events
        private void Voorraad_txt_KeyPress(object sender, KeyPressEventArgs e)
        {
            //allow minus and dot  and numbers
            if (!char.IsControl(e.KeyChar) && (!char.IsDigit(e.KeyChar))
                    && (e.KeyChar != '.') && (e.KeyChar != '-'))
                e.Handled = true;

            //only allow minus sign at the beginning
            if (e.KeyChar == '-' && (sender as TextBox).Text.Length > 0)
                e.Handled = true;
        }
        private void Voorraad_txt_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                //Get art id and info
                if (Datagrid_Artikellen.SelectedCells.Count > 0)
                {
                    int ID;
                    string Selected = Datagrid_Artikellen.SelectedCells[0].Value.ToString();
                    if (int.TryParse(Selected, out ID))
                    {
                        int choice;
                        string input = Voorraad_txt.Text;

                        //Check if it is a number!
                        if (Int32.TryParse(input, out choice))
                        {
                            //Get and show result
                            for (int i = 0; i < DATA.Artikellen.Count; i++)
                            {
                                if (DATA.Artikellen[i].ID == ID)
                                {
                                    //Calculate Output
                                    int voorrraad = DATA.Artikellen[i].Voorraad;
                                    int Output = voorrraad += Int32.Parse(input);

                                    if (Output <= -1)
                                    {
                                        MessageBox.Show("De voorraad zal staan op " + Output + " maar dat is niet toegestaan!");
                                    }
                                    else
                                    {
                                        //Change has been accepted
                                        DATA.Artikellen[i].Voorraad += Int32.Parse(input);
                                    }
                                }
                            }
                        }
                    }
                }
                Datagrid_VoorraadDetail_Setup();
            }
        }

        //Logout
        private void Loguit_btn_Click(object sender, EventArgs e)
        {
            lg.Show();
            this.Close();
        }
        private void Loguit_btn_MouseEnter(object sender, EventArgs e)
        {
            Loguit_btn.ForeColor = Color.CadetBlue;
            Loguit_btn.Font = new Font(Loguit_btn.Font, FontStyle.Bold);
        }
        private void Loguit_btn_MouseLeave(object sender, EventArgs e)
        {
            Loguit_btn.ForeColor = Color.Black;
            Loguit_btn.Font = new Font(Loguit_btn.Font, FontStyle.Regular);
        }
    }
}
