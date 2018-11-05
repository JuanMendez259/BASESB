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
        public List<cliente> aux_cliente;
        public List<clase_esquemaFragmentacion> aux_esquema;
        string[] atri;

        /*DATOS DEL CLIENTE*/
        int idCliente;
        string nombre, apellidoP, apellidoM;
        string fechaNacimiento;
        string celular;

        /*DATOS DEL DOMICILIO*/
        int idDomicilio;
        string calle, colonia, municipio;
        string numExt, numInt;
        string CP;
        string tel;
        int dirActual;

        /*DATOS DEL RESULTADO DE EVALUACION*/
        int idEVAR;
        string folioEVAR;
        string fechaEVAR;
        string Asesor;
        string Vendedor;
        string Resultado;
        string Observaciones;

        /*VARIABLES DE CONEXCION*/
        private OleDbCommand comando;
        private OleDbDataAdapter adaptador;
        private DataSet datos;
        private OleDbDataReader Leer;

        /*VARIABLES ESQUEMA LOCALIZACION*/
        int idFragmento;
        string nomFragmento;
        string nomTabla;
        string tipoFragmentacion;
        int sitio;
        string condicion;

        /*VARIABLES ATRIBUTOS*/
        int idFragAtributos;
        string nomAtributo;

        private OleDbCommand command;
        private OleDbDataReader reader;

        private OleDbConnection conexion = new OleDbConnection
            (@"Provider=SQLNCLI11;Server=DESKTOP-3MOFSQA\SQLEXPRESS;Database=SHESAT;Trusted_Connection=yes;");

        private OleDbConnection conn_sitio1 = new OleDbConnection
            (@"Provider=SQLNCLI11;Server=DESKTOP-3MOFSQA\SQLEXPRESS;Database=SITIO_1;Trusted_Connection=yes;");

        private OleDbConnection conn_sitio_central = new OleDbConnection
            (@"Provider=SQLNCLI11;Server=DESKTOP-3MOFSQA\SQLEXPRESS;Database=SITIO_CENTRAL;Trusted_Connection=yes;");

        private OleDbConnection conn_esquemaFragmentacion = new OleDbConnection
            (@"Provider=SQLNCLI11;Server=DESKTOP-3MOFSQA\SQLEXPRESS;Database=ESQUEMA_FRAGMENTACION;Trusted_Connection=yes;");


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
        private void abrirConexion_db()
        {
            try
            {
                conn_esquemaFragmentacion.Open();
                //MessageBox.Show("ABIERTA");
            }
            catch (Exception error)
            {
                MessageBox.Show("" + error.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Stop);
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
            inserta_datosCliente();
            inserta_datosDomicilio();



        }

        public void checa_localizacion(string var)
        {
            List<clase_esquemaFragmentacion> lista = clase_consultas.consulta_esquema(var);
            List<int> cto = new List<int>();
            //string[] atri;
            aux_esquema = new List<clase_esquemaFragmentacion>();
            aux_esquema = lista;
            cto= clase_consultas.cuenta_atributos(aux_esquema);
            atri= clase_consultas.consulta_atributos(aux_esquema, cto);
        }

        private void cerrarConexion_db()
        {
            conexion.Close();
            //MessageBox.Show("cerrada");
        }
        public void saca_idCliente()
        {
            string query;

            conn_sitio1.Open();
            if(conn_sitio1.State!= ConnectionState.Open) { return; }
            string sto = aux_esquema[0].c_nomFragmento;

            query = "SELECT IDCLIENTE FROM CLIENTE1 WHERE NOMBRE="+ "'"+ nombre +"'" +
                    " AND APELLIDOP=" + "'" + apellidoP + "'"+ 
                    " AND APELLIDOM=" + "'" + apellidoM + "'"+
                    " AND NUMCONTACTO=" + "'" + celular+ "'";

            //comando = new OleDbCommand(query, conn_sitio1);
            //adaptador = new OleDbDataAdapter(comando);

            OleDbCommand consulta = new OleDbCommand(string.Format(query), conn_sitio1);
            OleDbDataReader reader = consulta.ExecuteReader();

            while (reader.Read())
            {
                idCliente = Convert.ToInt32(reader["IDCLIENTE"]);
            }
            conn_sitio1.Close();

            //return idCliente;
        }
        public void inserta_datosCliente()
        {
            int op;
            string var = "CLIENTE";
            string[] fecha_Nacimiento;
            try
            {
                checa_localizacion(var);
                /*DATOS DEL CLIENTE*/
                nombre = textBox_nombre.Text;
                apellidoP = textBox_apeidoP.Text;
                apellidoM = textBox_apeidoM.Text;

                fechaNacimiento = dateTime_nacimiento.Value.ToString();
                fecha_Nacimiento = fechaNacimiento.Split(' ');
                fechaNacimiento = fecha_Nacimiento[0];

                celular = textBox_numContacto.Text;

                string sto = aux_esquema[0].c_nomFragmento;
                string datos=null;

                for (int i=1; i< atri.Count(); i++)
                {
                    datos = datos + "," + atri[i];
                }
                if (datos.StartsWith(","))
                    datos = datos.Substring(1);


                conn_sitio1.Open();
                if (conn_sitio1.State != ConnectionState.Open)
                {
                    return;
                }
                string query;
                query = "INSERT INTO " + sto + "("+ datos +") VALUES" +
                    "('" + nombre + "','" + apellidoP + "','" +apellidoM + "','" + fechaNacimiento + "','" + celular + "')";

                comando = new OleDbCommand(query, conn_sitio1);
                comando.ExecuteNonQuery();
                MessageBox.Show("Se inserto con exito");
                conn_sitio1.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo realizar la consulta" + ex.Message);
                conn_sitio1.Close();
            }
        }
        public void inserta_datosDomicilio()
        {
            string var = "DOMICILIO";
            //string sto = aux_esquema[0].c_nomFragmento;
            //string nomFrag = null;
            //nomFrag = aux_esquema[0].c_nomFragmento; 
            
            try
            {
                checa_localizacion(var);
                saca_idCliente();
                /*DATOS DEL DOMICILIO*/
                calle = textBox_calle.Text;
                colonia = textBox_colonia.Text;
                municipio = textBox_municipio.Text;
                numExt = textBox_numExt.Text;
                numInt = textBox_numInt.Text;
                CP = textBox_CP.Text;
                tel = textBox_tel.Text;

                //si es falso se va al sitio2 
                if (checkBox_dirActual.Checked == false)
                {
                    dirActual = 0;
                    MessageBox.Show("va al sitio2");
                }
                    
                else //si es verdadero se va al sitio1
                {
                    conn_sitio1.Open();
                    dirActual = 1;
                    string sto = aux_esquema[0].c_nomFragmento;
                    string datos = null;

                    for (int i = 1; i < atri.Count(); i++)
                    {
                        datos = datos + "," + atri[i];
                    }
                    if (datos.StartsWith(","))
                        datos = datos.Substring(1);

                    
                    if (conn_sitio1.State != ConnectionState.Open)
                    {
                        return;
                    }
                    string query = null;
                    query =
                        "INSERT INTO " + sto + "(" + datos + ") VALUES" +
                        "("+ idCliente + " ,CONVERT(BIT," + "'"+dirActual+"'"+")" + " ,'" + calle + "' ," + "'" +numInt + "' ," + "'"+numExt + "' ," + "'"+CP + "' ," +"'"+ colonia + "' ," + "'"+municipio + "')";
                    comando = new OleDbCommand(query, conn_sitio1);
                    comando.ExecuteNonQuery();
                    conn_sitio1.Close();
                    MessageBox.Show("Se ingreso Correctamente Domicilio");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo realizar la consulta " + ex.Message);
                conexion.Close();
            }
            //conexion.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void inserta_resEVAR()
        {
            try
            {
                /*DATOS DEL RESULTADO DE EVALUACION*/
                folioEVAR = textBox_EVAR.Text;
                //fechaEVAR = dateTimePicker_fechaEVAR.Value.Date;
                fechaEVAR = dateTimePicker_fechaEVAR.Value.ToString();
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
                    "INSERT INTO Informacion_Sistema.Res_Cliente(folioEVAR, FechaEVAR, Asesor, Resultado, Observaciones) VALUES" +
                    "('" + folioEVAR + "','" + fechaEVAR + "'," + Asesor + "'," + Resultado + "'," + Observaciones + "')", conexion);
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
