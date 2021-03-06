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
using System.Windows.Forms.DataVisualization.Charting;

namespace Voorraadbeheer_Grafische
{
    public partial class Admin : Form
    {
        //Variable-Main
        public static int ID;
        public static Login lg;
        public Admin(int Id)
        {
            InitializeComponent();
            ID = Id;

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
            Datagrid_Medewerker_Setup();
            Datagrid_VoorraadDetail_Setup();
        }

        //Setup
        private void account_Setup()
        {
            //Update acc info
            for (int i = 0; i < DATA.Medewerkers.Count; i++)
                if (ID == DATA.Medewerkers[i].ID)
                {
                    GebruikersNaam_lbl.Text = DATA.Medewerkers[i].Naam + " " + DATA.Medewerkers[i].Achternaam;
                    DATA.Medewerkers[i].LaatstIngelogd = DateTime.Today.ToShortDateString().ToString();
                    DATA.Medewerkers[i].LaatstVersie = "Grafische";
                }
            Datagrid_VoorraadDetail_Setup();
        }

        //Medewerker
        private void Datagrid_Medewerker_Setup()
        {
            //Setup medewerkers Datagrid
            Searchbar_txt.Text = null;
            DataGrid_Werknemers.Rows.Clear();
            for (int i = 0; i < DATA.Medewerkers.Count; i++)
                DataGrid_Werknemers.Rows.Add(
                    DATA.Medewerkers[i].ID,
                    DATA.Medewerkers[i].Naam,
                    DATA.Medewerkers[i].Achternaam,
                    DATA.Medewerkers[i].Email,
                    DATA.Medewerkers[i].Telnr,
                    DATA.Medewerkers[i].Functie.ToString());

            DataGrid_Werknemers.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }
        private void StaticInfo_Medewerker_Setup(int Id)
        {
            //Update static info from Selected Medewerker in DataGrid
            for (int i = 0; i < DATA.Medewerkers.Count; i++)
                if (Id == DATA.Medewerkers[i].ID)
                {
                    LoginNaam_lbl.Text = DATA.Medewerkers[i].LoginNaam;
                    Wachtwoord_lbl.Text = DATA.Medewerkers[i].Wachtwoord;
                    LaatsteActief_lbl.Text = DATA.Medewerkers[i].LaatstIngelogd;
                    Versie_lbl.Text = DATA.Medewerkers[i].LaatstVersie;
                    AanmaakAcc_lbl.Text = DATA.Medewerkers[i].AanmaaktDatum;
                }
        }
        private void DataGrid_Werknemers_SelectionChanged(object sender, EventArgs e)
        {
            if(DataGrid_Werknemers.SelectedCells.Count > 0)
            {
                int value;
                //Get id from selected DataRow
                string input = DataGrid_Werknemers.SelectedCells[0].Value.ToString();
                if (int.TryParse(input, out value))
                {
                    //Update info
                    DATA.SelectedID_werknemers = value;
                    StaticInfo_Medewerker_Setup(value);
                }
            }
        }

        //Voorraad
        private void Datagrid_VoorraadDetail_Setup()
        {
            //Update Voorraad info in DataGrid
            Searchbar_txt.Text = null;
            Datagrid_Artikellen.Rows.Clear();
            for (int i = 0; i < DATA.Artikellen.Count; i++)
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

            Datagrid_Artikellen.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }
        private void StaticInfo_VoorraadDetail_Setup(int Id)
        {
            //Update Static info from the selected DataRow
            for (int i = 0; i < DATA.Artikellen.Count; i++)
                if (Id == DATA.Artikellen[i].ID)
                {
                    //calculate
                    double EenProcent = (DATA.Artikellen[i].Inkoopprijs / 100.00);
                    double TotalBTW = (100 - DATA.Artikellen[i].BTW * EenProcent);

                    double IncBTw = ((DATA.Artikellen[i].Inkoopprijs/100.00) * (100.00 + DATA.Artikellen[i].BTW));

                    //set info
                    art_Btw_lbl.Text = DATA.Artikellen[i].BTW.ToString()+"%";                                       //Btw
                    art_IncBtw_lbl.Text = IncBTw.ToString();                                                        //IncBtw
                    art_ExBtw_lbl.Text = DATA.Artikellen[i].Inkoopprijs.ToString();                                 //ExBtw
                    art_Winst_lbl.Text = ((TotalBTW * EenProcent)- DATA.Artikellen[i].Inkoopprijs).ToString();      //Winst


                    art_LaatstGewijzigd_lbl.Text = DATA.Artikellen[i].LaatstGewijzigd;                              //LaatstGewijzigd
                    art_Door_lbl.Text = DATA.Artikellen[i].GewijzigdDoor;                                           //Door
                }
        }
        private void Datagrid_Artikellen_SelectionChanged(object sender, EventArgs e)
        {
            if (Datagrid_Artikellen.SelectedCells.Count > 0)
            {
                int value;
                //Get id from selected DataRow
                string input = Datagrid_Artikellen.SelectedCells[0].Value.ToString();
                if (int.TryParse(input, out value))
                {
                    //Update info
                    DATA.SelectedID_Voorraad_Details = value;
                    StaticInfo_VoorraadDetail_Setup(value);
                }
            }
        }

        //Search
        private void Search()
        {
            //Get Search txt
            string search_txt = Searchbar_txt.Text.ToLower();

            //Medewerker tab
            if (tabControl.SelectedIndex == 0)
            {
                DataGrid_Werknemers.Rows.Clear();
                String searchValue = search_txt;

                //if medewerker contains search txt
                for (int i = 0; i < DATA.Medewerkers.Count; i++)
                    //Update Datagrid info
                    if (DATA.Medewerkers[i].Naam.ToLower().Contains(searchValue))
                    {
                        DataGrid_Werknemers.Rows.Add(
                        DATA.Medewerkers[i].ID,
                        DATA.Medewerkers[i].Naam,
                        DATA.Medewerkers[i].Achternaam,
                        DATA.Medewerkers[i].Email,
                        DATA.Medewerkers[i].Telnr,
                        DATA.Medewerkers[i].Functie.ToString());
                    }
            }
            else
            //Medewerker tab
            if (tabControl.SelectedIndex == 1)
            {
                Datagrid_Artikellen.Rows.Clear();
                String searchValue = search_txt;

                //if medewerker contains search txt
                for (int i = 0; i < DATA.Artikellen.Count; i++)
                    //Update Datagrid info
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
            DataGrid_Werknemers.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }
        private void Search_btn_Click(object sender, EventArgs e)
        {
            Search();
        }
        private void Searchbar_txt_KeyDown(object sender, KeyEventArgs e)
        {
            //if enter
            if (e.KeyCode == Keys.Enter)
            {
                Search();
            }
        }
        private void Searchbar_txt_TextChanged(object sender, EventArgs e)
        {
            Search();
        }

        //Nieuw Account - Wijzigen werknemers - Delete Account
        private void New_Acc_btn_Click(object sender, EventArgs e)
        {
            //make new account
            Add_Change_Medewerker frm1 = new Add_Change_Medewerker(this,Function.Nieuw, ID);
            frm1.Show();
            this.Hide();
        }
        private void Wijzig_btn_Click(object sender, EventArgs e)
        {
            Add_Change_Medewerker frm1 = new Add_Change_Medewerker(this, Function.Wijzig, ID);
            frm1.Show();
            this.Hide();
        }
        private void Delete_Medew_Acc_Click(object sender, EventArgs e)
        {
            DialogResult dr;
            dr = MessageBox.Show("Wil je dit account echt verwijderen?", "Confirm", MessageBoxButtons.YesNo);
            if (dr == DialogResult.Yes)
            {
                string id = DataGrid_Werknemers.SelectedCells[0].Value.ToString();
                int ID = Int32.Parse(id);
                DATA.SelectedID_werknemers = ID;


                for (int i = 0; i < DATA.Medewerkers.Count; i++)
                    if (DATA.Medewerkers[i].ID == ID)
                    {
                        DATA.Medewerkers.Remove(DATA.Medewerkers[i]);
                        DATA.Save_Medewerkers(DATA.Medewerkers);
                        Datagrid_Medewerker_Setup();
                    }
            }
        }

        //Nieuw Artikel - Wijzigen Artikel - Delete Artikel
        private void newArt_btn_Click(object sender, EventArgs e)
        {
            Add_Change_Artikel frm1 = new Add_Change_Artikel(this, Function.Nieuw, ID);
            frm1.Show();
            this.Hide();
        }
        private void Wijzig_art_btn_Click(object sender, EventArgs e)
        {
            Add_Change_Artikel frm1 = new Add_Change_Artikel(this, Function.Wijzig, ID);
            frm1.Show();
            this.Hide();
        }
        private void Delete_art_btn_Click(object sender, EventArgs e)
        {
            DialogResult dr;
            dr = MessageBox.Show("Wil je dit ARTIKEL echt verwijderen?", "Confirm", MessageBoxButtons.YesNo);
            if (dr == DialogResult.Yes)
            {
                string id = Datagrid_Artikellen.SelectedCells[0].Value.ToString();
                int ID = Int32.Parse(id);
                DATA.SelectedID_Voorraad_Details = ID;


                for (int i = 0; i < DATA.Artikellen.Count; i++)
                    if (DATA.Artikellen[i].ID == ID)
                    {
                        DATA.Artikellen.Remove(DATA.Artikellen[i]);
                        DATA.Save_Artikellen(DATA.Artikellen);
                        Datagrid_VoorraadDetail_Setup();
                    }
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

        //General-Events
        private void Close_btn_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }
    }
}
