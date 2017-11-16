namespace Voorraadbeheer_Grafische
{
    partial class Add_Change_Medewerker
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
            this.Accepteer_lbl = new System.Windows.Forms.Button();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.label2 = new System.Windows.Forms.Label();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.Close_btn = new System.Windows.Forms.Button();
            this.Naam_txt = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.Achternaam_txt = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.Email_txt = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.Telefoonnr_txt = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.Wachtwoord_txt = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.LoginNaam_txt = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.Functie_cb = new System.Windows.Forms.ComboBox();
            this.Geslacht_cb = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.Message_lbl = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // Accepteer_lbl
            // 
            this.Accepteer_lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Accepteer_lbl.Location = new System.Drawing.Point(579, 427);
            this.Accepteer_lbl.Name = "Accepteer_lbl";
            this.Accepteer_lbl.Size = new System.Drawing.Size(74, 33);
            this.Accepteer_lbl.TabIndex = 9;
            this.Accepteer_lbl.Text = "Add";
            this.Accepteer_lbl.UseVisualStyleBackColor = true;
            this.Accepteer_lbl.Click += new System.EventHandler(this.Accepteer_lbl_Click);
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.BackColor = System.Drawing.Color.Black;
            this.flowLayoutPanel2.Location = new System.Drawing.Point(54, 420);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(599, 2);
            this.flowLayoutPanel2.TabIndex = 22;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(153, 92);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(264, 37);
            this.label2.TabIndex = 21;
            this.label2.Text = "Medewerker Toevoegen";
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.BackColor = System.Drawing.Color.Black;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(54, 132);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(599, 2);
            this.flowLayoutPanel1.TabIndex = 20;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(73, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(115, 37);
            this.label1.TabIndex = 18;
            this.label1.Text = "Gimpies";
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::Voorraadbeheer_Grafische.Properties.Resources.icons8_Add_Property_Filled_100;
            this.pictureBox2.Location = new System.Drawing.Point(90, 84);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(40, 42);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 19;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Voorraadbeheer_Grafische.Properties.Resources.User;
            this.pictureBox1.Location = new System.Drawing.Point(12, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(55, 54);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 17;
            this.pictureBox1.TabStop = false;
            // 
            // Close_btn
            // 
            this.Close_btn.BackgroundImage = global::Voorraadbeheer_Grafische.Properties.Resources.Close_Window;
            this.Close_btn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.Close_btn.Location = new System.Drawing.Point(660, 12);
            this.Close_btn.Name = "Close_btn";
            this.Close_btn.Size = new System.Drawing.Size(45, 45);
            this.Close_btn.TabIndex = 16;
            this.Close_btn.TabStop = false;
            this.Close_btn.UseVisualStyleBackColor = true;
            this.Close_btn.Click += new System.EventHandler(this.Close_btn_Click);
            // 
            // Naam_txt
            // 
            this.Naam_txt.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Naam_txt.Location = new System.Drawing.Point(54, 174);
            this.Naam_txt.Name = "Naam_txt";
            this.Naam_txt.Size = new System.Drawing.Size(165, 26);
            this.Naam_txt.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(54, 148);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(111, 22);
            this.label3.TabIndex = 24;
            this.label3.Text = "Naam:";
            // 
            // Achternaam_txt
            // 
            this.Achternaam_txt.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Achternaam_txt.Location = new System.Drawing.Point(54, 241);
            this.Achternaam_txt.Name = "Achternaam_txt";
            this.Achternaam_txt.Size = new System.Drawing.Size(165, 26);
            this.Achternaam_txt.TabIndex = 2;
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(54, 215);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(111, 22);
            this.label4.TabIndex = 26;
            this.label4.Text = "Achternaam:";
            // 
            // Email_txt
            // 
            this.Email_txt.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Email_txt.Location = new System.Drawing.Point(54, 307);
            this.Email_txt.Name = "Email_txt";
            this.Email_txt.Size = new System.Drawing.Size(165, 26);
            this.Email_txt.TabIndex = 3;
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(54, 281);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(111, 22);
            this.label5.TabIndex = 28;
            this.label5.Text = "Email:";
            // 
            // Telefoonnr_txt
            // 
            this.Telefoonnr_txt.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Telefoonnr_txt.Location = new System.Drawing.Point(54, 377);
            this.Telefoonnr_txt.Name = "Telefoonnr_txt";
            this.Telefoonnr_txt.Size = new System.Drawing.Size(165, 26);
            this.Telefoonnr_txt.TabIndex = 4;
            this.Telefoonnr_txt.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Telefoonnr_txt_KeyPress);
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(54, 351);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(111, 22);
            this.label6.TabIndex = 30;
            this.label6.Text = "Telefoon nr:";
            // 
            // label7
            // 
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(279, 281);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(111, 22);
            this.label7.TabIndex = 36;
            this.label7.Text = "Functie:";
            // 
            // Wachtwoord_txt
            // 
            this.Wachtwoord_txt.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Wachtwoord_txt.Location = new System.Drawing.Point(279, 241);
            this.Wachtwoord_txt.Name = "Wachtwoord_txt";
            this.Wachtwoord_txt.Size = new System.Drawing.Size(165, 26);
            this.Wachtwoord_txt.TabIndex = 6;
            // 
            // label8
            // 
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(279, 215);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(111, 22);
            this.label8.TabIndex = 34;
            this.label8.Text = "Wachtwoord:";
            // 
            // LoginNaam_txt
            // 
            this.LoginNaam_txt.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LoginNaam_txt.Location = new System.Drawing.Point(279, 174);
            this.LoginNaam_txt.Name = "LoginNaam_txt";
            this.LoginNaam_txt.Size = new System.Drawing.Size(165, 26);
            this.LoginNaam_txt.TabIndex = 5;
            // 
            // label9
            // 
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(279, 148);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(111, 22);
            this.label9.TabIndex = 32;
            this.label9.Text = "Login Naam:";
            // 
            // Functie_cb
            // 
            this.Functie_cb.FormattingEnabled = true;
            this.Functie_cb.Items.AddRange(new object[] {
            "None",
            "Winkel",
            "Magazijn",
            "Admin"});
            this.Functie_cb.Location = new System.Drawing.Point(279, 306);
            this.Functie_cb.Name = "Functie_cb";
            this.Functie_cb.Size = new System.Drawing.Size(165, 24);
            this.Functie_cb.TabIndex = 7;
            // 
            // Geslacht_cb
            // 
            this.Geslacht_cb.FormattingEnabled = true;
            this.Geslacht_cb.Items.AddRange(new object[] {
            "Man",
            "Vrouw"});
            this.Geslacht_cb.Location = new System.Drawing.Point(279, 380);
            this.Geslacht_cb.Name = "Geslacht_cb";
            this.Geslacht_cb.Size = new System.Drawing.Size(165, 24);
            this.Geslacht_cb.TabIndex = 8;
            // 
            // label10
            // 
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(279, 355);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(111, 22);
            this.label10.TabIndex = 38;
            this.label10.Text = "Geslacht:";
            // 
            // Message_lbl
            // 
            this.Message_lbl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.Message_lbl.Location = new System.Drawing.Point(105, 429);
            this.Message_lbl.Name = "Message_lbl";
            this.Message_lbl.Size = new System.Drawing.Size(468, 17);
            this.Message_lbl.TabIndex = 40;
            this.Message_lbl.Text = "label11";
            this.Message_lbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Add_Change_Medewerker
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(717, 472);
            this.Controls.Add(this.Message_lbl);
            this.Controls.Add(this.Geslacht_cb);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.Functie_cb);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.Wachtwoord_txt);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.LoginNaam_txt);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.Telefoonnr_txt);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.Email_txt);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.Achternaam_txt);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.Naam_txt);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.Accepteer_lbl);
            this.Controls.Add(this.flowLayoutPanel2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.Close_btn);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Add_Change_Medewerker";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Add_Medewerker";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Accepteer_lbl;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button Close_btn;
        private System.Windows.Forms.TextBox Naam_txt;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox Achternaam_txt;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox Email_txt;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox Telefoonnr_txt;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox Wachtwoord_txt;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox LoginNaam_txt;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox Functie_cb;
        private System.Windows.Forms.ComboBox Geslacht_cb;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label Message_lbl;
    }
}