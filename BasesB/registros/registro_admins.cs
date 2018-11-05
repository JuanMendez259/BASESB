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

namespace BasesB.Logins
{
    public partial class registro_admins : Form
    {
        string nombre, tipoUsuario, pass, numCelular;
        private OleDbConnection conn_sitio1 = new OleDbConnection
            (@"Provider=SQLNCLI11;Server=DESKTOP-3MOFSQA\SQLEXPRESS;Database=SITIO_1;Trusted_Connection=yes;");
        private OleDbCommand comando;

        private void button1_Click(object sender, EventArgs e)
        {
            nombre = textBox_nombre.Text;
            tipoUsuario = comboBox_tipoUsuario.SelectedItem.ToString();
            pass = textBox_pass.Text;
            numCelular = textBox_celular.Text;

            try
            {
                if (pass == textBox_VPass.Text)//si las contraseñas cohinciden
                {
                    conn_sitio1.Open();
                    if (conn_sitio1.State != ConnectionState.Open)
                    {
                        return;
                    }
                    string query;

                    query = "INSERT INTO USUARIO (nombre, tipo_usuario, contraseña, numCelular)" +
                               "VALUES(" + "'"+ nombre+"'" +"," + "'" + tipoUsuario + "'" + "," + "'" + pass + "'," + "'" + numCelular + "'"+" )";

                    comando = new OleDbCommand(query, conn_sitio1);
                    comando.ExecuteNonQuery();
                    MessageBox.Show("Se inserto con exito");
                    limpia_formulario();
                    conn_sitio1.Close();
                }
                else
                    MessageBox.Show("No cohinciden las contraseñas");
                
            }
            catch(Exception de)
            {
                MessageBox.Show("No se pudo realizar la consulta" + de.Message);
                conn_sitio1.Close();
            }
        }
        public void limpia_formulario()
        {
            textBox_nombre.Clear();
            textBox_celular.Clear();
            textBox_pass.Clear();
            textBox_VPass.Clear();
            comboBox_tipoUsuario.SelectedIndex = 0;
        }

        public registro_admins()
        {
            InitializeComponent();
        }


        private void registro_admins_Load(object sender, EventArgs e)
        {

        }
    }
}
