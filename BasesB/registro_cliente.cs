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
    public partial class registro_cliente : Form
    {
        private bool error;

        /*DATOS DEL CLIENTE*/
        string nombre, apellidoP, apellidoM;
        DateTime fechaNacimiento;
        string celular;

        /*DATOS DEL DOMICILIO*/
        string calle, colonia, municipio;
        string numExt, numInt;
        string CP;
        string tel;
        bool dirActual;

        /*DATOS DEL RESULTADO DE EVALUACION*/
        string folioEVAR;
        DateTime fechaEVAR;
        string Asesor;
        string Vendedor;
        string Resultado;
        string Observaciones;

        /*VARIABLES DE CONEXCION*/
        private OleDbCommand comando;
        private OleDbDataAdapter adaptador;
        private DataSet datos;
        private OleDbDataReader Leer;
        private OleDbConnection conexion = new OleDbConnection
            (@"Provider=SQLNCLI11;Server=DESKTOP-3MOFSQA\SQLEXPRESS;Database=SHESAT;Trusted_Connection=yes;");

        public registro_cliente()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void textBox_calle_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox_nombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsLetter(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                MessageBox.Show("Solo se permiten letras", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = error = true;
                return;
            }
        }

        private void textBox_apeidoM_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsLetter(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                MessageBox.Show("Solo se permiten letras", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = error = true;
                return;
            }
        }

        private void textBox_apeidoP_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsLetter(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                MessageBox.Show("Solo se permiten letras", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = error = true;
                return;
            }
        }

        private void button_registrar_Click(object sender, EventArgs e)
        {
            

                
        }
        public void inserta_datosCliente()
        {
            try
            {
                /*DATOS DEL CLIENTE*/
                nombre = textBox_nombre.Text;
                apellidoP = textBox_apeidoP.Text;
                apellidoM = textBox_apeidoM.Text;
                //fechaNacimiento = dateTime_nacimiento
                celular = textBox_numContacto.Text;

                /*DATOS DEL DOMICILIO*/
                calle = textBox_calle.Text;
                colonia = textBox_colonia.Text;
                numExt = textBox_numExt.Text;
                numInt = textBox_numInt.Text;
                CP = textBox_CP.Text;
                tel = textBox_tel.Text;
                //dirActual = checkBox_dirActual.CheckState.


                /*DATOS DEL RESULTADO DE EVALUACION*/
                folioEVAR = textBox_EVAR.Text;
                //fechaEVAR = dateTimePicker_fechaEVAR;
                Asesor = textBox_Asesor.Text;
                Vendedor = comboBox_Vendedor.SelectedItem.ToString();
                Resultado = comboBoxResultado.SelectedItem.ToString();
                Observaciones = textBox_Observaciones.Text;

                conexion.Open();
                if (conexion.State != ConnectionState.Open)
                {
                    return;
                }
                comando = new OleDbCommand(
                    "INSERT INTO Informacion_Cliente.Cliente(nombre, apellidoP, apellidoM, fechaNacimiento, celular) VALUES" +
                    "('" + nombre + "','" + apellidoP + "'," + apellidoM + "'," + fechaNacimiento + "'," + celular + "')", conexion);
                comando.ExecuteNonQuery();
                conexion.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo realizar la consulta" + ex.Message);
                conexion.Close();
            }
        }
        public void inserta_datosDomicilio()
        {
            try
            {
                /*DATOS DEL DOMICILIO*/
                calle = textBox_calle.Text;
                colonia = textBox_colonia.Text;
                municipio = textBox_municipio.Text;
                numExt = textBox_numExt.Text;
                numInt = textBox_numInt.Text;
                CP = textBox_CP.Text;
                tel = textBox_tel.Text;

                if (checkBox_dirActual.Checked == false)
                    dirActual = false;
                else
                    dirActual = true;

                conexion.Open();
                if (conexion.State != ConnectionState.Open)
                {
                    return;
                }
                comando = new OleDbCommand(
                    "INSERT INTO Informacion_Cliente.Domicilio(calle, numInt, numExt, colonia, municipio, numLocal, CP, dirActual) VALUES" +
                    "('" + calle + "','" + numInt + "'," + numExt + "'," + colonia + "'," + municipio + "'," + tel + "'," + CP + "'," + dirActual + "')", conexion);
                comando.ExecuteNonQuery();
                conexion.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo realizar la consulta" + ex.Message);
                conexion.Close();
            }
        }

        private void textBox_numContacto_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsNumber(e.KeyChar))
                e.Handled = false;
            else
            if (char.IsControl(e.KeyChar))
                e.Handled = false;
            else
                e.Handled = true;
        }

        private void textBox_CP_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                MessageBox.Show("Solo se permiten numeros", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = error = true;
                return;
            }
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                MessageBox.Show("Solo se permiten numeros", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = error = true;
                return;
            }
        }

        private void registro_cliente_Load(object sender, EventArgs e)
        {

        }
    }
}
