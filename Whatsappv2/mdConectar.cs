using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Whatsappv2
{
    public partial class mdConectar : Form
    {
        public string Ip { get; set; }
        public string Puerto { get; set; }
        public mdConectar()
        {
            InitializeComponent();
        }

        private void rjButton2_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void btnConectar_Click(object sender, EventArgs e)
        {
            if(this.txtIp.Texts != "" && this.txtrPuerto.Texts != "")
            {
                Ip = txtIp.Texts;
                Puerto = txtrPuerto.Texts;
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private void txtIp_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void txtIp_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && this.txtIp.Texts != "" && this.txtrPuerto.Texts != "")
            {
                this.btnConectar_Click(sender,e);
            }
        }

        private void txtrPuerto_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && this.txtIp.Texts != "" && this.txtrPuerto.Texts != "")
            {
                this.btnConectar_Click(sender, e);
            }
        }
    }
}
