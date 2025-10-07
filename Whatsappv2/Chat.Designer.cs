using System.Windows.Forms;

namespace Whatsappv2
{
    partial class Chat
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
            this.chatPanel = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnEnviar = new CustomControls.RJControls.RJButton();
            this.txtEnviar = new CustomControls.RJControls.RJTextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lblEstado = new System.Windows.Forms.Label();
            this.lblIp = new System.Windows.Forms.Label();
            this.btnConectar = new CustomControls.RJControls.RJButton();
            this.btnHome = new CustomControls.RJControls.RJButton();
            this.btnDesconectar = new CustomControls.RJControls.RJButton();
            this.btnListar = new CustomControls.RJControls.RJButton();
            this.rjTextBox1 = new CustomControls.RJControls.RJTextBox();
            this.btnEstado = new CustomControls.RJControls.RJButton();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // chatPanel
            // 
            this.chatPanel.AutoScroll = true;
            this.chatPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(35)))), ((int)(((byte)(58)))));
            this.chatPanel.Location = new System.Drawing.Point(179, 3);
            this.chatPanel.Name = "chatPanel";
            this.chatPanel.Size = new System.Drawing.Size(615, 387);
            this.chatPanel.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Roboto", 12F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.SystemColors.Control;
            this.label1.Location = new System.Drawing.Point(79, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 19);
            this.label1.TabIndex = 3;
            this.label1.Text = "Status: ";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(35)))), ((int)(((byte)(58)))));
            this.panel2.Controls.Add(this.btnEnviar);
            this.panel2.Controls.Add(this.txtEnviar);
            this.panel2.Location = new System.Drawing.Point(179, 389);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(615, 55);
            this.panel2.TabIndex = 2;
            // 
            // btnEnviar
            // 
            this.btnEnviar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(162)))), ((int)(((byte)(87)))));
            this.btnEnviar.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(162)))), ((int)(((byte)(87)))));
            this.btnEnviar.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.btnEnviar.BorderRadius = 26;
            this.btnEnviar.BorderSize = 0;
            this.btnEnviar.FlatAppearance.BorderSize = 0;
            this.btnEnviar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEnviar.ForeColor = System.Drawing.Color.White;
            this.btnEnviar.Image = global::Whatsappv2.Properties.Resources.expedido;
            this.btnEnviar.Location = new System.Drawing.Point(554, 1);
            this.btnEnviar.Name = "btnEnviar";
            this.btnEnviar.Size = new System.Drawing.Size(55, 50);
            this.btnEnviar.TabIndex = 1;
            this.btnEnviar.TextColor = System.Drawing.Color.White;
            this.btnEnviar.UseVisualStyleBackColor = false;
            this.btnEnviar.Click += new System.EventHandler(this.rjButton1_Click);
            // 
            // txtEnviar
            // 
            this.txtEnviar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(23)))), ((int)(((byte)(23)))));
            this.txtEnviar.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(225)))), ((int)(((byte)(241)))));
            this.txtEnviar.BorderFocusColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.txtEnviar.BorderRadius = 10;
            this.txtEnviar.BorderSize = 2;
            this.txtEnviar.Font = new System.Drawing.Font("Segoe UI", 15F);
            this.txtEnviar.ForeColor = System.Drawing.Color.White;
            this.txtEnviar.IsReadOnly = false;
            this.txtEnviar.Location = new System.Drawing.Point(20, 5);
            this.txtEnviar.Margin = new System.Windows.Forms.Padding(4);
            this.txtEnviar.Multiline = false;
            this.txtEnviar.Name = "txtEnviar";
            this.txtEnviar.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.txtEnviar.PasswordChar = false;
            this.txtEnviar.PlaceholderColor = System.Drawing.Color.DarkGray;
            this.txtEnviar.PlaceholderText = "";
            this.txtEnviar.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtEnviar.ShortcutsEnabled = true;
            this.txtEnviar.Size = new System.Drawing.Size(518, 43);
            this.txtEnviar.TabIndex = 0;
            this.txtEnviar.Texts = "";
            this.txtEnviar.UnderlinedStyle = true;
            this.txtEnviar.WordWrap = true;
            this.txtEnviar.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtEnviar_KeyDown);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Whatsappv2.Properties.Resources.servidor_de_datos;
            this.pictureBox1.Location = new System.Drawing.Point(12, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(46, 49);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // lblEstado
            // 
            this.lblEstado.AutoSize = true;
            this.lblEstado.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEstado.ForeColor = System.Drawing.Color.White;
            this.lblEstado.Location = new System.Drawing.Point(80, 33);
            this.lblEstado.Name = "lblEstado";
            this.lblEstado.Size = new System.Drawing.Size(46, 17);
            this.lblEstado.TabIndex = 0;
            this.lblEstado.Text = "Offline";
            this.lblEstado.Click += new System.EventHandler(this.label2_Click);
            // 
            // lblIp
            // 
            this.lblIp.AutoSize = true;
            this.lblIp.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIp.ForeColor = System.Drawing.Color.White;
            this.lblIp.Location = new System.Drawing.Point(12, 73);
            this.lblIp.Name = "lblIp";
            this.lblIp.Size = new System.Drawing.Size(101, 17);
            this.lblIp.TabIndex = 7;
            this.lblIp.Text = "192.168.200.200";
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
            this.btnConectar.Location = new System.Drawing.Point(12, 116);
            this.btnConectar.Name = "btnConectar";
            this.btnConectar.Size = new System.Drawing.Size(150, 40);
            this.btnConectar.TabIndex = 6;
            this.btnConectar.Text = "Conectar";
            this.btnConectar.TextColor = System.Drawing.Color.White;
            this.btnConectar.UseVisualStyleBackColor = false;
            this.btnConectar.Click += new System.EventHandler(this.btnConectar_Click);
            // 
            // btnHome
            // 
            this.btnHome.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(23)))), ((int)(((byte)(23)))));
            this.btnHome.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(23)))), ((int)(((byte)(23)))));
            this.btnHome.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.btnHome.BorderRadius = 20;
            this.btnHome.BorderSize = 2;
            this.btnHome.FlatAppearance.BorderSize = 0;
            this.btnHome.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHome.ForeColor = System.Drawing.Color.White;
            this.btnHome.Location = new System.Drawing.Point(12, 294);
            this.btnHome.Name = "btnHome";
            this.btnHome.Size = new System.Drawing.Size(150, 40);
            this.btnHome.TabIndex = 5;
            this.btnHome.Text = "Home";
            this.btnHome.TextColor = System.Drawing.Color.White;
            this.btnHome.UseVisualStyleBackColor = false;
            this.btnHome.Click += new System.EventHandler(this.rjButton4_Click);
            // 
            // btnDesconectar
            // 
            this.btnDesconectar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(23)))), ((int)(((byte)(23)))));
            this.btnDesconectar.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(23)))), ((int)(((byte)(23)))));
            this.btnDesconectar.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(225)))), ((int)(((byte)(241)))));
            this.btnDesconectar.BorderRadius = 20;
            this.btnDesconectar.BorderSize = 2;
            this.btnDesconectar.FlatAppearance.BorderSize = 0;
            this.btnDesconectar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDesconectar.ForeColor = System.Drawing.Color.White;
            this.btnDesconectar.Location = new System.Drawing.Point(12, 235);
            this.btnDesconectar.Name = "btnDesconectar";
            this.btnDesconectar.Size = new System.Drawing.Size(150, 40);
            this.btnDesconectar.TabIndex = 4;
            this.btnDesconectar.Text = "Desconectar";
            this.btnDesconectar.TextColor = System.Drawing.Color.White;
            this.btnDesconectar.UseVisualStyleBackColor = false;
            this.btnDesconectar.Click += new System.EventHandler(this.btnDesconectar_Click);
            // 
            // btnListar
            // 
            this.btnListar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(23)))), ((int)(((byte)(23)))));
            this.btnListar.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(23)))), ((int)(((byte)(23)))));
            this.btnListar.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(225)))), ((int)(((byte)(241)))));
            this.btnListar.BorderRadius = 20;
            this.btnListar.BorderSize = 2;
            this.btnListar.FlatAppearance.BorderSize = 0;
            this.btnListar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnListar.ForeColor = System.Drawing.Color.White;
            this.btnListar.Location = new System.Drawing.Point(12, 172);
            this.btnListar.Name = "btnListar";
            this.btnListar.Size = new System.Drawing.Size(150, 40);
            this.btnListar.TabIndex = 0;
            this.btnListar.Text = "Listar";
            this.btnListar.TextColor = System.Drawing.Color.White;
            this.btnListar.UseVisualStyleBackColor = false;
            this.btnListar.Click += new System.EventHandler(this.rjButton2_Click);
            // 
            // rjTextBox1
            // 
            this.rjTextBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(23)))), ((int)(((byte)(23)))));
            this.rjTextBox1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(225)))), ((int)(((byte)(241)))));
            this.rjTextBox1.BorderFocusColor = System.Drawing.Color.HotPink;
            this.rjTextBox1.BorderRadius = 0;
            this.rjTextBox1.BorderSize = 2;
            this.rjTextBox1.CausesValidation = false;
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
            this.rjTextBox1.ShortcutsEnabled = false;
            this.rjTextBox1.Size = new System.Drawing.Size(798, 447);
            this.rjTextBox1.TabIndex = 0;
            this.rjTextBox1.Texts = "";
            this.rjTextBox1.UnderlinedStyle = false;
            this.rjTextBox1.WordWrap = true;
            // 
            // btnEstado
            // 
            this.btnEstado.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnEstado.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnEstado.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.btnEstado.BorderRadius = 8;
            this.btnEstado.BorderSize = 0;
            this.btnEstado.Enabled = false;
            this.btnEstado.FlatAppearance.BorderSize = 0;
            this.btnEstado.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEstado.ForeColor = System.Drawing.Color.White;
            this.btnEstado.Location = new System.Drawing.Point(122, 35);
            this.btnEstado.Name = "btnEstado";
            this.btnEstado.Size = new System.Drawing.Size(15, 15);
            this.btnEstado.TabIndex = 8;
            this.btnEstado.TextColor = System.Drawing.Color.White;
            this.btnEstado.UseVisualStyleBackColor = false;
            // 
            // Chat
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(23)))), ((int)(((byte)(23)))));
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnEstado);
            this.Controls.Add(this.lblIp);
            this.Controls.Add(this.btnConectar);
            this.Controls.Add(this.lblEstado);
            this.Controls.Add(this.btnHome);
            this.Controls.Add(this.btnDesconectar);
            this.Controls.Add(this.btnListar);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.chatPanel);
            this.Controls.Add(this.rjTextBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Chat";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Chat";
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private CustomControls.RJControls.RJTextBox rjTextBox1;
        private System.Windows.Forms.Panel chatPanel;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private CustomControls.RJControls.RJButton btnEnviar;
        private CustomControls.RJControls.RJTextBox txtEnviar;
        private CustomControls.RJControls.RJButton btnListar;
        private CustomControls.RJControls.RJButton btnDesconectar;
        private CustomControls.RJControls.RJButton btnHome;
        private System.Windows.Forms.Label lblEstado;
        private CustomControls.RJControls.RJButton btnConectar;
        private Label lblIp;
        private CustomControls.RJControls.RJButton btnEstado;
    }
}