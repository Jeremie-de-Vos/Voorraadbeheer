namespace Voorraadbeheer_Grafische
{
    partial class Winkel_Beheer
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.Search_btn = new System.Windows.Forms.Button();
            this.Searchbar_txt = new System.Windows.Forms.TextBox();
            this.Loguit_btn = new System.Windows.Forms.Label();
            this.GebruikersNaam_lbl = new System.Windows.Forms.Label();
            this.Admin_lbl = new System.Windows.Forms.Label();
            this.CompanyName_lbl = new System.Windows.Forms.Label();
            this.CompanyLogo_pb = new System.Windows.Forms.PictureBox();
            this.Close_btn = new System.Windows.Forms.Button();
            this.Null_Voorraad_Checkbox = new System.Windows.Forms.CheckBox();
            this.Datagrid_Artikellen = new System.Windows.Forms.DataGridView();
            this.ID_art_colum = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Naam_art_colum = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Merk_art_colum = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Maat_art_colum = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Voorraad_art_colum = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Categorie_Colum_Admin = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Prijs_Colum_Admin = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Voorraad_txt = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CompanyLogo_pb)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Datagrid_Artikellen)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Voorraadbeheer_Grafische.Properties.Resources.Search_Filled;
            this.pictureBox1.Location = new System.Drawing.Point(12, 86);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(23, 24);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 20;
            this.pictureBox1.TabStop = false;
            // 
            // Search_btn
            // 
            this.Search_btn.Location = new System.Drawing.Point(225, 86);
            this.Search_btn.Name = "Search_btn";
            this.Search_btn.Size = new System.Drawing.Size(71, 24);
            this.Search_btn.TabIndex = 2;
            this.Search_btn.Text = "Zoeken";
            this.Search_btn.UseVisualStyleBackColor = true;
            // 
            // Searchbar_txt
            // 
            this.Searchbar_txt.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Searchbar_txt.Location = new System.Drawing.Point(36, 86);
            this.Searchbar_txt.Name = "Searchbar_txt";
            this.Searchbar_txt.Size = new System.Drawing.Size(183, 24);
            this.Searchbar_txt.TabIndex = 1;
            this.Searchbar_txt.TextChanged += new System.EventHandler(this.Searchbar_txt_TextChanged);
            // 
            // Loguit_btn
            // 
            this.Loguit_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Loguit_btn.Location = new System.Drawing.Point(971, 40);
            this.Loguit_btn.Name = "Loguit_btn";
            this.Loguit_btn.Size = new System.Drawing.Size(49, 19);
            this.Loguit_btn.TabIndex = 19;
            this.Loguit_btn.Text = "Loguit";
            // 
            // GebruikersNaam_lbl
            // 
            this.GebruikersNaam_lbl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.GebruikersNaam_lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GebruikersNaam_lbl.Location = new System.Drawing.Point(892, 16);
            this.GebruikersNaam_lbl.Name = "GebruikersNaam_lbl";
            this.GebruikersNaam_lbl.Size = new System.Drawing.Size(201, 24);
            this.GebruikersNaam_lbl.TabIndex = 18;
            this.GebruikersNaam_lbl.Text = "Jeremie de Vos";
            this.GebruikersNaam_lbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Admin_lbl
            // 
            this.Admin_lbl.AutoSize = true;
            this.Admin_lbl.Location = new System.Drawing.Point(105, 54);
            this.Admin_lbl.Name = "Admin_lbl";
            this.Admin_lbl.Size = new System.Drawing.Size(50, 17);
            this.Admin_lbl.TabIndex = 17;
            this.Admin_lbl.Text = "Winkel";
            // 
            // CompanyName_lbl
            // 
            this.CompanyName_lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CompanyName_lbl.Location = new System.Drawing.Point(73, 25);
            this.CompanyName_lbl.Name = "CompanyName_lbl";
            this.CompanyName_lbl.Size = new System.Drawing.Size(137, 37);
            this.CompanyName_lbl.TabIndex = 16;
            this.CompanyName_lbl.Text = "Gimpies";
            // 
            // CompanyLogo_pb
            // 
            this.CompanyLogo_pb.Image = global::Voorraadbeheer_Grafische.Properties.Resources.User;
            this.CompanyLogo_pb.Location = new System.Drawing.Point(12, 12);
            this.CompanyLogo_pb.Name = "CompanyLogo_pb";
            this.CompanyLogo_pb.Size = new System.Drawing.Size(55, 54);
            this.CompanyLogo_pb.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.CompanyLogo_pb.TabIndex = 15;
            this.CompanyLogo_pb.TabStop = false;
            // 
            // Close_btn
            // 
            this.Close_btn.BackgroundImage = global::Voorraadbeheer_Grafische.Properties.Resources.Close_Window;
            this.Close_btn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.Close_btn.Location = new System.Drawing.Point(1099, 12);
            this.Close_btn.Name = "Close_btn";
            this.Close_btn.Size = new System.Drawing.Size(45, 45);
            this.Close_btn.TabIndex = 12;
            this.Close_btn.TabStop = false;
            this.Close_btn.UseVisualStyleBackColor = true;
            this.Close_btn.Click += new System.EventHandler(this.Close_btn_Click);
            // 
            // Null_Voorraad_Checkbox
            // 
            this.Null_Voorraad_Checkbox.AutoSize = true;
            this.Null_Voorraad_Checkbox.Location = new System.Drawing.Point(12, 134);
            this.Null_Voorraad_Checkbox.Name = "Null_Voorraad_Checkbox";
            this.Null_Voorraad_Checkbox.Size = new System.Drawing.Size(117, 21);
            this.Null_Voorraad_Checkbox.TabIndex = 3;
            this.Null_Voorraad_Checkbox.Text = "Null Voorraad";
            this.Null_Voorraad_Checkbox.UseVisualStyleBackColor = true;
            this.Null_Voorraad_Checkbox.CheckedChanged += new System.EventHandler(this.Null_Voorraad_Checkbox_CheckedChanged);
            // 
            // Datagrid_Artikellen
            // 
            this.Datagrid_Artikellen.AllowUserToAddRows = false;
            this.Datagrid_Artikellen.AllowUserToDeleteRows = false;
            this.Datagrid_Artikellen.BackgroundColor = System.Drawing.SystemColors.Control;
            this.Datagrid_Artikellen.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Datagrid_Artikellen.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID_art_colum,
            this.Naam_art_colum,
            this.Merk_art_colum,
            this.Maat_art_colum,
            this.Voorraad_art_colum,
            this.Categorie_Colum_Admin,
            this.Prijs_Colum_Admin});
            this.Datagrid_Artikellen.Location = new System.Drawing.Point(225, 147);
            this.Datagrid_Artikellen.Name = "Datagrid_Artikellen";
            this.Datagrid_Artikellen.ReadOnly = true;
            this.Datagrid_Artikellen.RowTemplate.Height = 24;
            this.Datagrid_Artikellen.Size = new System.Drawing.Size(743, 439);
            this.Datagrid_Artikellen.TabIndex = 22;
            this.Datagrid_Artikellen.SelectionChanged += new System.EventHandler(this.Datagrid_Artikellen_SelectionChanged);
            // 
            // ID_art_colum
            // 
            this.ID_art_colum.HeaderText = "ID";
            this.ID_art_colum.Name = "ID_art_colum";
            this.ID_art_colum.ReadOnly = true;
            // 
            // Naam_art_colum
            // 
            this.Naam_art_colum.HeaderText = "Naam";
            this.Naam_art_colum.Name = "Naam_art_colum";
            this.Naam_art_colum.ReadOnly = true;
            // 
            // Merk_art_colum
            // 
            this.Merk_art_colum.HeaderText = "Merk";
            this.Merk_art_colum.Name = "Merk_art_colum";
            this.Merk_art_colum.ReadOnly = true;
            // 
            // Maat_art_colum
            // 
            this.Maat_art_colum.HeaderText = "Maat";
            this.Maat_art_colum.Name = "Maat_art_colum";
            this.Maat_art_colum.ReadOnly = true;
            // 
            // Voorraad_art_colum
            // 
            this.Voorraad_art_colum.HeaderText = "Voorraad";
            this.Voorraad_art_colum.Name = "Voorraad_art_colum";
            this.Voorraad_art_colum.ReadOnly = true;
            // 
            // Categorie_Colum_Admin
            // 
            this.Categorie_Colum_Admin.HeaderText = "Categorie";
            this.Categorie_Colum_Admin.Name = "Categorie_Colum_Admin";
            this.Categorie_Colum_Admin.ReadOnly = true;
            // 
            // Prijs_Colum_Admin
            // 
            this.Prijs_Colum_Admin.HeaderText = "Inkoopprijs";
            this.Prijs_Colum_Admin.Name = "Prijs_Colum_Admin";
            this.Prijs_Colum_Admin.ReadOnly = true;
            // 
            // Voorraad_txt
            // 
            this.Voorraad_txt.Location = new System.Drawing.Point(12, 210);
            this.Voorraad_txt.Name = "Voorraad_txt";
            this.Voorraad_txt.Size = new System.Drawing.Size(143, 22);
            this.Voorraad_txt.TabIndex = 4;
            this.Voorraad_txt.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Voorraad_txt_KeyDown);
            this.Voorraad_txt.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Voorraad_txt_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 190);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(112, 17);
            this.label1.TabIndex = 24;
            this.label1.Text = "Wijzig Voorraad:";
            // 
            // Winkel_Beheer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1156, 622);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Voorraad_txt);
            this.Controls.Add(this.Datagrid_Artikellen);
            this.Controls.Add(this.Null_Voorraad_Checkbox);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.Search_btn);
            this.Controls.Add(this.Searchbar_txt);
            this.Controls.Add(this.Loguit_btn);
            this.Controls.Add(this.GebruikersNaam_lbl);
            this.Controls.Add(this.Admin_lbl);
            this.Controls.Add(this.CompanyName_lbl);
            this.Controls.Add(this.CompanyLogo_pb);
            this.Controls.Add(this.Close_btn);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Winkel_Beheer";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Winkel_Beheer";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CompanyLogo_pb)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Datagrid_Artikellen)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button Search_btn;
        private System.Windows.Forms.TextBox Searchbar_txt;
        private System.Windows.Forms.Label Loguit_btn;
        private System.Windows.Forms.Label GebruikersNaam_lbl;
        private System.Windows.Forms.Label Admin_lbl;
        private System.Windows.Forms.Label CompanyName_lbl;
        private System.Windows.Forms.PictureBox CompanyLogo_pb;
        private System.Windows.Forms.Button Close_btn;
        private System.Windows.Forms.CheckBox Null_Voorraad_Checkbox;
        private System.Windows.Forms.DataGridView Datagrid_Artikellen;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID_art_colum;
        private System.Windows.Forms.DataGridViewTextBoxColumn Naam_art_colum;
        private System.Windows.Forms.DataGridViewTextBoxColumn Merk_art_colum;
        private System.Windows.Forms.DataGridViewTextBoxColumn Maat_art_colum;
        private System.Windows.Forms.DataGridViewTextBoxColumn Voorraad_art_colum;
        private System.Windows.Forms.DataGridViewTextBoxColumn Categorie_Colum_Admin;
        private System.Windows.Forms.DataGridViewTextBoxColumn Prijs_Colum_Admin;
        private System.Windows.Forms.TextBox Voorraad_txt;
        private System.Windows.Forms.Label label1;
    }
}