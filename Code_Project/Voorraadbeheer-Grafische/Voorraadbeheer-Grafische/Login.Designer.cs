namespace Voorraadbeheer_Grafische
{
    partial class Login
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
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.Close_btn = new System.Windows.Forms.Button();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.label2 = new System.Windows.Forms.Label();
            this.Warning_lbl = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.Naam_txt = new System.Windows.Forms.TextBox();
            this.Wachtwoor_txt = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.Login_btn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(73, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(115, 37);
            this.label1.TabIndex = 3;
            this.label1.Text = "Gimpies";
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::Voorraadbeheer_Grafische.Properties.Resources.icons8_User_48;
            this.pictureBox2.Location = new System.Drawing.Point(90, 84);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(40, 42);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 4;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Voorraadbeheer_Grafische.Properties.Resources.User;
            this.pictureBox1.Location = new System.Drawing.Point(12, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(55, 54);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // Close_btn
            // 
            this.Close_btn.BackgroundImage = global::Voorraadbeheer_Grafische.Properties.Resources.Close_Window;
            this.Close_btn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.Close_btn.Location = new System.Drawing.Point(660, 12);
            this.Close_btn.Name = "Close_btn";
            this.Close_btn.Size = new System.Drawing.Size(45, 45);
            this.Close_btn.TabIndex = 1;
            this.Close_btn.TabStop = false;
            this.Close_btn.UseVisualStyleBackColor = true;
            this.Close_btn.Click += new System.EventHandler(this.button2_Click);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.BackColor = System.Drawing.Color.Black;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(54, 132);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(599, 2);
            this.flowLayoutPanel1.TabIndex = 5;
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.BackColor = System.Drawing.Color.Black;
            this.flowLayoutPanel2.Location = new System.Drawing.Point(54, 331);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(599, 2);
            this.flowLayoutPanel2.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(153, 92);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(115, 37);
            this.label2.TabIndex = 7;
            this.label2.Text = "Login";
            // 
            // Warning_lbl
            // 
            this.Warning_lbl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.Warning_lbl.Location = new System.Drawing.Point(188, 350);
            this.Warning_lbl.Name = "Warning_lbl";
            this.Warning_lbl.Size = new System.Drawing.Size(350, 17);
            this.Warning_lbl.TabIndex = 8;
            this.Warning_lbl.Text = "U kunt nog (3) keer proberen voor de applicatie afsluit";
            this.Warning_lbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(86, 155);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(111, 22);
            this.label3.TabIndex = 9;
            this.label3.Text = "Naam:";
            // 
            // Naam_txt
            // 
            this.Naam_txt.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Naam_txt.Location = new System.Drawing.Point(86, 181);
            this.Naam_txt.Name = "Naam_txt";
            this.Naam_txt.Size = new System.Drawing.Size(165, 26);
            this.Naam_txt.TabIndex = 1;
            // 
            // Wachtwoor_txt
            // 
            this.Wachtwoor_txt.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Wachtwoor_txt.Location = new System.Drawing.Point(86, 245);
            this.Wachtwoor_txt.Name = "Wachtwoor_txt";
            this.Wachtwoor_txt.PasswordChar = '*';
            this.Wachtwoor_txt.Size = new System.Drawing.Size(165, 26);
            this.Wachtwoor_txt.TabIndex = 2;
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(86, 219);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(144, 22);
            this.label4.TabIndex = 11;
            this.label4.Text = "Wachtwoord:";
            // 
            // Login_btn
            // 
            this.Login_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Login_btn.Location = new System.Drawing.Point(306, 292);
            this.Login_btn.Name = "Login_btn";
            this.Login_btn.Size = new System.Drawing.Size(117, 33);
            this.Login_btn.TabIndex = 3;
            this.Login_btn.Text = "Login";
            this.Login_btn.UseVisualStyleBackColor = true;
            this.Login_btn.Click += new System.EventHandler(this.Login_btn_Click);
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(717, 387);
            this.ControlBox = false;
            this.Controls.Add(this.Login_btn);
            this.Controls.Add(this.Wachtwoor_txt);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.Naam_txt);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.Warning_lbl);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.flowLayoutPanel2);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.Close_btn);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Login";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Close_btn;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label Warning_lbl;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox Naam_txt;
        private System.Windows.Forms.TextBox Wachtwoor_txt;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button Login_btn;
    }
}

