using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Whatsappv2
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void rjButton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void rjButton1_Click(object sender, EventArgs e)
        {
            if (this.txtUsuario.Texts != "")
            {
                Chat form = new Chat(this.txtUsuario.Texts);
                form.Show();
                this.Hide();
            }
            else
            {
                DialogResult error = MessageBox.Show("Inserte un nombre de usuario", "Error", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            }

        }

        private void txtUsuario_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && this.txtUsuario.Texts != "")
            {
                rjButton1_Click (sender, e );
            }
        }
    }
}
