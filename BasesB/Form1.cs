using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace BasesB
{
    public partial class login : Form
    {
        string nombre_usuario;
        string pass_usuario;
        string tipo_usuario;
        bool inicia_sesion;
        int usuario, pass

       /* //pc escritorio
        private OleDbConnection conn_sitio1 = new OleDbConnection
            (@"Provider=SQLNCLI11;Server=DESKTOP-3MOFSQA\SQLEXPRESS;Database=SITIO_1;Trusted_Connection=yes;");
        */
        //laptop
        private OleDbConnection conn_sitio1 = new OleDbConnection
            (@"Provider=SQLNCLI11;Server=DESKTOP-8J1BUON\SQLEXPRESS;Database=SITIO_1;Trusted_Connection=yes;");

        
        public login()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            nombre_usuario = textBox_usuario.Text;
            pass_usuario = textBox_contraseña.Text;
            tipo_usuario = comboBox_TipoUsuario.SelectedItem.ToString();
            bool inicia;

            if (usuario != 0 && pass !=0) 
            {
                checa_login();
                if (inicia_sesion)
                {
                    menu_principal menu = new menu_principal(tipo_usuario);
                    menu.Show();
                }
                else
                    MessageBox.Show("Error al iniciar Sesión, checa USUARIO/CONTRASEÑA");
            }
            else
            {
                MessageBox.Show("Ingresa un Usuario/Contraseña");
            }
                
            
        }
        public void checa_login()
        {

            conn_sitio1.Open();
            
            if (conn_sitio1.State != ConnectionState.Open) { return; }
            string query = "SELECT nombre,tipo_usuario,contraseña"+
                           " FROM USUARIO"+
                           " WHERE nombre="+ "'"+nombre_usuario+"'" +
                           " AND tipo_usuario=" +"'"+ tipo_usuario+"'" +
                           " AND contraseña=" +"'"+ pass_usuario+"'";

            OleDbCommand consulta = new OleDbCommand(string.Format(query), conn_sitio1);
            OleDbDataReader reader = consulta.ExecuteReader();

            while (reader.Read())
            {
                if (nombre_usuario == reader["nombre"].ToString())
                    if (tipo_usuario == reader["tipo_usuario"].ToString())
                        if (pass_usuario == reader["contraseña"].ToString())
                        {
                            inicia_sesion = true;
                        }
            }
            conn_sitio1.Close();
            textBox_usuario.Clear();
            textBox_contraseña.Clear();
            comboBox_TipoUsuario.SelectedIndex = -1;

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
