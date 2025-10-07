namespace Whatsappv2
{
    partial class mdConectar
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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.rjButton2 = new CustomControls.RJControls.RJButton();
            this.btnConectar = new CustomControls.RJControls.RJButton();
            this.txtrPuerto = new CustomControls.RJControls.RJTextBox();
            this.txtIp = new CustomControls.RJControls.RJTextBox();
            this.rjTextBox1 = new CustomControls.RJControls.RJTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(35)))), ((int)(((byte)(58)))));
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(115, 105);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(136, 17);
            this.label1.TabIndex = 12;
            this.label1.Text = "Conectarse a servidor";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(35)))), ((int)(((byte)(58)))));
            this.pictureBox1.Image = global::Whatsappv2.Properties.Resources.servidor_de_datos;
            this.pictureBox1.Location = new System.Drawing.Point(126, 29);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(109, 64);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 11;
            this.pictureBox1.TabStop = false;
            // 
            // rjButton2
            // 
            this.rjButton2.BackColor = System.Drawing.Color.DarkRed;
            this.rjButton2.BackgroundColor = System.Drawing.Color.DarkRed;
            this.rjButton2.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.rjButton2.BorderRadius = 0;
            this.rjButton2.BorderSize = 0;
            this.rjButton2.FlatAppearance.BorderSize = 0;
            this.rjButton2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rjButton2.ForeColor = System.Drawing.Color.White;
            this.rjButton2.Location = new System.Drawing.Point(338, 0);
            this.rjButton2.Name = "rjButton2";
            this.rjButton2.Size = new System.Drawing.Size(32, 29);
            this.rjButton2.TabIndex = 14;
            this.rjButton2.Text = "X";
            this.rjButton2.TextColor = System.Drawing.Color.White;
            this.rjButton2.UseVisualStyleBackColor = false;
            this.rjButton2.Click += new System.EventHandler(this.rjButton2_Click);
            // 
            // btnConectar
            // 
            this.btnConectar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(23)))), ((int)(((byte)(23)))));
            this.btnConectar.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(23)))), ((int)(((byte)(23)))));
            this.btnConectar.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(162)))), ((int)(((byte)(87)))));
            this.btnConectar.BorderRadius = 20;
            this.btnConectar.BorderSize = 2;
            this.btnConectar.FlatAppearance.BorderSize = 0;
            this.btnConectar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnConectar.ForeColor = System.Drawing.Color.White;
            this.btnConectar.Location = new System.Drawing.Point(114, 274);
            this.btnConectar.Name = "btnConectar";
            this.btnConectar.Size = new System.Drawing.Size(150, 40);
            this.btnConectar.TabIndex = 13;
            this.btnConectar.Text = "Conectar";
            this.btnConectar.TextColor = System.Drawing.Color.White;
            this.btnConectar.UseVisualStyleBackColor = false;
            this.btnConectar.Click += new System.EventHandler(this.btnConectar_Click);
            // 
            // txtrPuerto
            // 
            this.txtrPuerto.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(35)))), ((int)(((byte)(58)))));
            this.txtrPuerto.BorderColor = System.Drawing.Color.MediumSlateBlue;
            this.txtrPuerto.BorderFocusColor = System.Drawing.Color.HotPink;
            this.txtrPuerto.BorderRadius = 10;
            this.txtrPuerto.BorderSize = 2;
            this.txtrPuerto.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtrPuerto.ForeColor = System.Drawing.Color.White;
            this.txtrPuerto.IsReadOnly = false;
            this.txtrPuerto.Location = new System.Drawing.Point(65, 215);
            this.txtrPuerto.Margin = new System.Windows.Forms.Padding(4);
            this.txtrPuerto.Multiline = false;
            this.txtrPuerto.Name = "txtrPuerto";
            this.txtrPuerto.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.txtrPuerto.PasswordChar = false;
            this.txtrPuerto.PlaceholderColor = System.Drawing.Color.DarkGray;
            this.txtrPuerto.PlaceholderText = "Puerto";
            this.txtrPuerto.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtrPuerto.ShortcutsEnabled = true;
            this.txtrPuerto.Size = new System.Drawing.Size(250, 31);
            this.txtrPuerto.TabIndex = 10;
            this.txtrPuerto.Texts = "";
            this.txtrPuerto.UnderlinedStyle = false;
            this.txtrPuerto.WordWrap = true;
            this.txtrPuerto.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtrPuerto_KeyDown);
            // 
            // txtIp
            // 
            this.txtIp.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(35)))), ((int)(((byte)(58)))));
            this.txtIp.BorderColor = System.Drawing.Color.MediumSlateBlue;
            this.txtIp.BorderFocusColor = System.Drawing.Color.HotPink;
            this.txtIp.BorderRadius = 10;
            this.txtIp.BorderSize = 2;
            this.txtIp.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtIp.ForeColor = System.Drawing.Color.White;
            this.txtIp.IsReadOnly = false;
            this.txtIp.Location = new System.Drawing.Point(65, 167);
            this.txtIp.Margin = new System.Windows.Forms.Padding(4);
            this.txtIp.Multiline = false;
            this.txtIp.Name = "txtIp";
            this.txtIp.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.txtIp.PasswordChar = false;
            this.txtIp.PlaceholderColor = System.Drawing.Color.DarkGray;
            this.txtIp.PlaceholderText = "Direccion IP";
            this.txtIp.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtIp.ShortcutsEnabled = true;
            this.txtIp.Size = new System.Drawing.Size(250, 31);
            this.txtIp.TabIndex = 9;
            this.txtIp.Texts = "";
            this.txtIp.UnderlinedStyle = false;
            this.txtIp.WordWrap = true;
            this.txtIp.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtIp_KeyDown);
            this.txtIp.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtIp_KeyPress);
            // 
            // rjTextBox1
            // 
            this.rjTextBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(35)))), ((int)(((byte)(58)))));
            this.rjTextBox1.BorderColor = System.Drawing.Color.MediumSlateBlue;
            this.rjTextBox1.BorderFocusColor = System.Drawing.Color.HotPink;
            this.rjTextBox1.BorderRadius = 0;
            this.rjTextBox1.BorderSize = 2;
            this.rjTextBox1.Enabled = false;
            this.rjTextBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rjTextBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.rjTextBox1.IsReadOnly = true;
            this.rjTextBox1.Location = new System.Drawing.Point(0, 0);
            this.rjTextBox1.Margin = new System.Windows.Forms.Padding(4);
            this.rjTextBox1.Multiline = true;
            this.rjTextBox1.Name = "rjTextBox1";
            this.rjTextBox1.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.rjTextBox1.PasswordChar = false;
            this.rjTextBox1.PlaceholderColor = System.Drawing.Color.DarkGray;
            this.rjTextBox1.PlaceholderText = "";
            this.rjTextBox1.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.rjTextBox1.ShortcutsEnabled = true;
            this.rjTextBox1.Size = new System.Drawing.Size(370, 370);
            this.rjTextBox1.TabIndex = 1;
            this.rjTextBox1.Texts = "";
            this.rjTextBox1.UnderlinedStyle = false;
            this.rjTextBox1.WordWrap = true;
            // 
            // mdConectar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(370, 370);
            this.Controls.Add(this.rjButton2);
            this.Controls.Add(this.btnConectar);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.txtrPuerto);
            this.Controls.Add(this.txtIp);
            this.Controls.Add(this.rjTextBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "mdConectar";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "mdConectar";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private CustomControls.RJControls.RJTextBox rjTextBox1;
        private CustomControls.RJControls.RJButton rjButton2;
        private CustomControls.RJControls.RJButton btnConectar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private CustomControls.RJControls.RJTextBox txtrPuerto;
        private CustomControls.RJControls.RJTextBox txtIp;
    }
}