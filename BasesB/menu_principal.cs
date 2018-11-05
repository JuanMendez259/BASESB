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
        string tipo_usuario;
        List<TabPage> AllTabPages;

        public menu_principal(string tipo_user)
        {
            InitializeComponent();
            tipo_usuario = tipo_user;
            AllTabPages = new List<TabPage>();
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void registroVendedor_Click(object sender, EventArgs e)
        {

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

        private void menu_principal_Load(object sender, EventArgs e)
        {
            if (tipo_usuario == "VENDEDOR")
                pictureBox_admins.Enabled = false;


        }
    }
}
