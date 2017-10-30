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
    public partial class Admin : Form
    {
        //Variable
        public static int ID;

        //Main
        public Admin(int Id)
        {
            InitializeComponent();
            ID = Id;

            account_Setup();
            Datagrid_Setup();
        }

        //Setup
        private void account_Setup()
        {
            for (int i = 0; i < DATA.Medewerkers.Count; i++)
                if (ID == DATA.Medewerkers[i].ID)
                {
                    GebruikersNaam_lbl.Text = DATA.Medewerkers[i].Naam + " " + DATA.Medewerkers[i].Achternaam;
                    DATA.Medewerkers[i].LaatstIngelogd = DateTime.Today.ToShortDateString().ToString();
                    DATA.Medewerkers[i].LaatstVersie = "Grafische";
                }
        }
        private void Datagrid_Setup()
        {
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
        private void StaticInfo_Setup(int Id)
        {
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

        //Search
        private void Search()
        {
            string search_txt = Searchbar_txt.Text.ToLower();

            if (tabControl.SelectedIndex == 0)
            {
                String searchValue = search_txt;
                int rowIndex = -1;
                foreach (DataGridViewRow row in DataGrid_Werknemers.Rows)
                {
                    if (row.Cells[1].Value.ToString().ToLower().Contains(searchValue))
                    {
                        rowIndex = row.Index;
                        DataGrid_Werknemers.Rows[rowIndex].Selected = true;
                        break;
                    }
                }
            }
        }
        private void Search_btn_Click(object sender, EventArgs e)
        {
            Search();
        }
        private void Searchbar_txt_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Search();
            }
        }
        private void Searchbar_txt_TextChanged(object sender, EventArgs e)
        {
            Search();
        }

        //General-Events
        private void Close_btn_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }
        private void DataGrid_Werknemers_SelectionChanged(object sender, EventArgs e)
        {
            string id = DataGrid_Werknemers.SelectedCells[0].Value.ToString();
            int ID = Int32.Parse(id);
            DATA.SelectedID = ID;
            StaticInfo_Setup(ID);
        }

        //Nieuw Account - Wijzigen werknemers
        private void New_Acc_btn_Click(object sender, EventArgs e)
        {
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
    }
}
