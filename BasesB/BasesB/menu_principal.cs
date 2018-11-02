using BasesB.Logins;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BasesB
{
    public partial class menu_principal : Form
    {
        public menu_principal()
        {
            InitializeComponent();
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void registroVendedor_Click(object sender, EventArgs e)
        {
            registro_vendedor vendedor = new registro_vendedor();
            vendedor.Show();
        }

        private void pictureBox_admins_Click(object sender, EventArgs e)
        {
            registro_admins admin = new registro_admins();
            admin.Show();
        }

        private void picturebox_registro_clientes_Click(object sender, EventArgs e)
        {
            registro_cliente cliente = new registro_cliente();
            cliente.Show();
        }
    }
}
