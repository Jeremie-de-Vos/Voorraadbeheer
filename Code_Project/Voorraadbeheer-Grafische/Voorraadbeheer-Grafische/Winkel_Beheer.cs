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
    public partial class Winkel_Beheer : Form
    {
        //Variable
        public static int ID;
        public int selectedrow;

        //Main
        public Winkel_Beheer(int id)
        {
            InitializeComponent();
            ID = id;

            account_Setup();
            Datagrid_VoorraadDetail_Setup();
            Null_Voorraad_Checkbox.Checked = true;
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

        //Voorraad
        private void Datagrid_VoorraadDetail_Setup()
        {
            Datagrid_Artikellen.Rows.Clear();
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

            Datagrid_Artikellen.ClearSelection();
            Datagrid_Artikellen.Rows[selectedrow].Selected = true;
            Datagrid_Artikellen.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }
        private void Datagrid_Artikellen_SelectionChanged(object sender, EventArgs e)
        {
            if (Datagrid_Artikellen.SelectedCells.Count > 0)
            {
                //int value;
               // string input = Datagrid_Artikellen.SelectedCells[0].Value.ToString();
               // if (int.TryParse(input, out value))
               // {
               //     DATA.SelectedID_Voorraad_Details = value;
                //}
            }
        }

        //Search
        private void Search()
        {
            string search_txt = Searchbar_txt.Text.ToLower();
            Datagrid_Artikellen.Rows.Clear();
            String searchValue = search_txt;

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

        //Change voorraad
        private void Voorraad_txt_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && (!char.IsDigit(e.KeyChar))
                    && (e.KeyChar != '.') && (e.KeyChar != '-'))
                e.Handled = true;

            // only allow minus sign at the beginning
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
                        if (Int32.TryParse(input, out choice))
                        {
                            //Get and show result
                            for (int i = 0; i < DATA.Artikellen.Count; i++)
                            {
                                if (DATA.Artikellen[i].ID == ID)
                                {
                                    //Calculate Output
                                    int Output = DATA.Artikellen[i].Voorraad += Int32.Parse(input);

                                    if (Output <= -1)
                                    {
                                        MessageBox.Show("De voorraad zal staan op " + Output + " maar dat is niet toegestaan!");
                                    }
                                    else
                                    {
                                        //Change has been accepted
                                        MessageBox.Show("hi");
                                    }
                                }
                            }
                        }
                    }
                }
                Datagrid_VoorraadDetail_Setup();
            }
        }
    }
}
