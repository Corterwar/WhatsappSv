using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CustomControls;
using CustomControls.RJControls;

namespace Whatsappv2
{
    public partial class Chat : Form
    {
        private string usuario;
        private ClienteChat2 cliente;

        public Chat(string usuario)
        {
            InitializeComponent();
            this.usuario = usuario;
            if (this.lblEstado.Text == "Online")
            {
                this.btnConectar.Visible = false;
                this.lblIp.Visible = true;
                this.txtEnviar.Enabled = true;
                this.btnEnviar.Enabled = true;
            }
            else
            {
                this.lblIp.Visible = false;
                this.btnConectar.Visible = true;
                this.txtEnviar.Enabled = false;
                this.btnEnviar.Enabled = false;
            }
        }

        private void rjButton4_Click(object sender, EventArgs e)
        {
            if(txtEnviar.Enabled == true)
            {
                this.txtEnviar.Texts = "/Quit";
                this.cliente.EnviarMensaje(txtEnviar.Texts);

            }
            this.lblIp.Visible = false;
            this.btnConectar.Visible = true;
            this.lblEstado.Text = "Offline";
            this.btnEstado.BackColor = Color.Red;
            Form login = new Login();
            login.Show();
            this.Close();
        }


        private void AddMessage(string user, string message, string currentUser)
        {
            // Contenedor de la burbuja
            Panel container = new Panel();
            container.AutoSize = true;
            container.MaximumSize = new Size(chatPanel.Width - 40, 0);

            // Nombre del usuario
            Label lblUser = new Label();
            lblUser.Text = user;
            lblUser.Font = new Font("Segoe UI", 9, FontStyle.Bold);
            lblUser.ForeColor = (user == currentUser) ? Color.RoyalBlue : Color.ForestGreen;
            lblUser.AutoSize = true;

            // Burbuja de mensaje usando tu RJTextBox
            var bubble = new CustomControls.RJControls.RJTextBox
            {
                Texts = message,
                Multiline = true,
                IsReadOnly = true,
                BorderSize = 0,
                BorderRadius = 15,
                Font = new Font("Segoe UI", 10),
                ForeColor = Color.Black,
                BackColor = (user == currentUser) ? Color.LightBlue : Color.LightGray,
                Enabled = false,
                
            };

            // Ajustar tamaño de la burbuja según el texto
            int maxWidth = 250;
            using (Graphics g = this.CreateGraphics())
            {
                SizeF size = g.MeasureString(bubble.Texts, bubble.Font, maxWidth);
                bubble.Width = (int)size.Width + 25;
                bubble.Height = (int)size.Height + 25;
            }


            // Alinear izquierda/derecha
            if (user == currentUser)
            {
                bubble.Left = container.MaximumSize.Width - bubble.Width;
                lblUser.Left = container.MaximumSize.Width - lblUser.Width + 50;
            }
            else if (user == "Sistema")
            {
                bubble.BorderSize = 0;
                bubble.BorderColor = Color.FromArgb(36, 35, 58);
                bubble.BackColor = Color.FromArgb(36, 35, 58);
                bubble.Left = (chatPanel.Width - bubble.Width) / 2; // Centrar
                lblUser.ForeColor = Color.DarkGray;
                lblUser.Left = (chatPanel.Width - bubble.Width) / 2;
            }
            else
            {
                bubble.Left = 20;
                lblUser.Left = 20;
            }

            // Posiciones dentro del contenedor
            lblUser.Top = 0;
            bubble.Top = lblUser.Bottom - 5;

            // Agregar al contenedor
            container.Controls.Add(lblUser);
            container.Controls.Add(bubble);
            container.Height = bubble.Bottom;

            // Posición vertical en el chat
            int top = 10;
            if (chatPanel.Controls.Count > 0)
                top = chatPanel.Controls[chatPanel.Controls.Count - 1].Bottom + 10;
            container.Top = top;

            chatPanel.Controls.Add(container);
            chatPanel.ScrollControlIntoView(container);
        }

        private void MostrarMensaje(string mensaje)
        {
            if (InvokeRequired)
            {
                this.Invoke(new Action<string>(MostrarMensaje), mensaje);
                return;
            }

            string user;
            string text;

            if (mensaje.StartsWith("***") && mensaje.EndsWith("***"))
            {
                user = "Sistema";
                text = mensaje.Trim('*').Trim();
            }
            else if (mensaje.Contains(":"))
            {
                int index = mensaje.IndexOf(":");
                user = mensaje.Substring(0, index);
                text = mensaje.Substring(index + 1).Trim();
            }
            else
            {
                user = "Sistema";
                text = mensaje;
            }

            AddMessage(user, text, this.usuario); // Este método ahora se ejecuta en el hilo de la UI
        }
        private void rjButton2_Click(object sender, EventArgs e)
        {
            if (this.txtEnviar.Enabled == true)
            {
                this.txtEnviar.Texts = "/Listar";
                this.cliente.EnviarMensaje(txtEnviar.Texts);
                this.txtEnviar.Texts = "";
            }

        }

        private void btnDesconectar_Click(object sender, EventArgs e)
        {
            if(this.txtEnviar.Enabled == true)
            {
                this.txtEnviar.Texts = "/Quit";
                this.cliente.EnviarMensaje(txtEnviar.Texts);
                this.txtEnviar.Texts = "";
                this.txtEnviar.Enabled = false;
                this.btnEnviar.Enabled = false;

                this.lblEstado.Text = "Offline";
                this.btnEstado.BackColor = Color.Red;
                this.lblIp.Visible = false;
                this.btnConectar.Visible = true;
            }

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void btnConectar_Click(object sender, EventArgs e)
        {
            mdConectar modal = new mdConectar();
            if (modal.ShowDialog() == DialogResult.OK)
            {
                string ip = modal.Ip;
                string puerto = modal.Puerto;

                cliente = new ClienteChat2();
                cliente.OnMensajeRecibido += MostrarMensaje;
                cliente.OnError += MostrarError;

                cliente.Conectar(ip, Convert.ToInt32(puerto), this.usuario);

                if (cliente.Conectado)
                {
                    MostrarMensaje("*** Conectado al servidor ***");
                    this.lblIp.Text = ip;
                    this.lblEstado.Text = "Online";
                    this.lblIp.Visible = true;
                    this.btnEstado.BackColor = Color.Green;
                    this.txtEnviar.Enabled = true;
                    this.btnEnviar.Enabled = true;
                }

            }
        }
        

        private void MostrarError(string error)
        {
            if (InvokeRequired)
            {
                this.Invoke(new Action<string>(MostrarError), error);
            }
            else
            {
                MessageBox.Show(error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                if (this.txtEnviar.Enabled == true)
                {
                    this.txtEnviar.Texts = "/Quit";
                    this.cliente.EnviarMensaje(txtEnviar.Texts);
                    this.txtEnviar.Texts = "";
                    this.txtEnviar.Enabled = false;
                    this.btnEnviar.Enabled = false;

                    this.lblEstado.Text = "Offline";
                    this.btnEstado.BackColor = Color.Red;
                    this.lblIp.Visible = false;
                    this.btnConectar.Visible = true;
                }
            }
        }

        private void rjButton1_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtEnviar.Texts))
            {
                cliente.EnviarMensaje(txtEnviar.Texts);
                txtEnviar.Texts = "";
            }
        }

        private void txtEnviar_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && this.txtEnviar.Texts != ""){
                cliente.EnviarMensaje(txtEnviar.Texts);
                txtEnviar.Texts = "";
            }
        }
    }
}
