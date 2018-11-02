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
    public partial class Form1 : Form
    {
        string nombre_usuario;
        string pass_usuario;
        int usuario, pass;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (usuario != 0 && pass !=0) 
            {
                menu_principal menu = new menu_principal();
                menu.Show();
            }
            else
                MessageBox.Show("Ingresa un Usuario/Contraseña");
            

        }

        private void textBox_contraseña_TextChanged(object sender, EventArgs e)
        {
            pass = textBox_contraseña.Text.ToString().Length;
        }

        private void textBox_usuario_TextChanged(object sender, EventArgs e)
        {
            usuario = textBox_usuario.Text.ToString().Length;
        }
    }
}
