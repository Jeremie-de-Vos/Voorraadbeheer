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
        private int ID;

        //Main
        public Admin(int Id)
        {
            InitializeComponent();
            ID = Id;

            account_Setup();
            Datagrid_Setup();

            Werknemer_Wijzig_cb.SelectedIndex = 0;
        }

        //General-Events
        private void Close_btn_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }
        private void DataGrid_Werknemers_SelectionChanged(object sender, EventArgs e)
        {
            string id = DataGrid_Werknemers.SelectedCells[0].Value.ToString();
            int ID;
            Int32.TryParse(id, out ID);

            StaticInfo_Setup(ID);
        }

        //Nieuw Account
        private void New_Acc_btn_Click(object sender, EventArgs e)
        {
            Add_Medewerker frm1 = new Add_Medewerker(this);
            frm1.Show();
            this.Hide();
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

        //Refreshe
        public void RefreshList()
        {
            string result;
            Datagrid_Setup();
            for (int i = 0; i < DATA.Medewerkers.Count; i++)
                MessageBox.Show(DATA.Medewerkers[i].Naam);
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
                        MessageBox.Show(rowIndex.ToString());
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

        //Wijzigen werknemers
        string id_naam;
        string wijziging;
        string voorheen;
        string naar;

        private void Werknemer_Wijzig_cb_SelectedIndexChanged(object sender, EventArgs e)
        {
            string caseSwitch = Werknemer_Wijzig_cb.Text;
            switch (caseSwitch)
            {
                case "None":
                    Wijzig_txt.Visible = false;
                    WijzigSomething_cb.Visible = false;
                    break;
                case "Wachtwoord":
                    Wijzig_txt.Visible = true;
                    WijzigSomething_cb.Visible = false;
                    break;
                case "Login naam":
                    Wijzig_txt.Visible = true;
                    WijzigSomething_cb.Visible = false;
                    break;
                case "Achternaam":
                    Wijzig_txt.Visible = true;
                    WijzigSomething_cb.Visible = false;
                    break;
                case "Functie":
                    Wijzig_txt.Visible = false;
                    WijzigSomething_cb.Visible = true;
                    break;
                case "Naam":
                    Wijzig_txt.Visible = true;
                    WijzigSomething_cb.Visible = false;
                    break;
                case "Email":
                    Wijzig_txt.Visible = true;
                    WijzigSomething_cb.Visible = false;
                    break;
                case "Tel":
                    Wijzig_txt.Visible = true;
                    WijzigSomething_cb.Visible = false;
                    break;
            }
        }
        private void Weknemers_Apply_btn_Click(object sender, EventArgs e)
        {
            string id = DataGrid_Werknemers.SelectedCells[0].Value.ToString();
            int ID;
            Int32.TryParse(id, out ID);

            for (int i = 0; i < DATA.Medewerkers.Count; i++)
                if (DATA.Medewerkers[i].ID == ID)
                {
                    id_naam = DATA.Medewerkers[i].ID + "-" + DATA.Medewerkers[i].Naam;
                    wijziging = Werknemer_Wijzig_cb.Text;
                    //voorheen?
                    string caseSwitch = Werknemer_Wijzig_cb.Text;
                    switch (caseSwitch)
                    {
                        case "None":
                            break;
                        case "Wachtwoord":
                            naar = Wijzig_txt.Text;
                            break;
                        case "Login naam":
                            naar = Wijzig_txt.Text;
                            break;
                        case "Achternaam":
                            naar = Wijzig_txt.Text;
                            break;
                        case "Functie":
                            naar = Werknemer_Wijzig_cb.Text;
                            break;
                        case "Naam":
                            naar = Wijzig_txt.Text;
                            break;
                        case "Email":
                            naar = Wijzig_txt.Text;
                            break;
                        case "Tel":
                            naar = Wijzig_txt.Text;
                            break;
                    }
                }

            Confirmation frm = new Confirmation(this,id_naam,wijziging,voorheen,naar);
            frm.Show();
            this.Hide();
        }
    }
}
