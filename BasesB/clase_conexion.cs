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
    public class clase_conexion
    {
        /*VARIABLES DE CONEXCION*/
        private OleDbCommand comando;
        private OleDbDataAdapter adaptador;
        private DataSet datos;
        private OleDbDataReader Leer;
        private OleDbConnection conn_sitio1, conn_sitio_central, conn_esquemaFragmentacion;/* = new OleDbConnection
            (@"Provider=SQLNCLI11;Server=DESKTOP-3MOFSQA\SQLEXPRESS;Database=SHESAT;Trusted_Connection=yes;");*/

        public static OleDbConnection conexion_sitio1()
        {
            string conexion_sitio1;

            conexion_sitio1 = @"Data Source=DESKTOP-3MOFSQA\SQLEXPRESS;Initial Catalog=ESQUEMA_LOCALIZACION;Integrated Security=True";
            //conexion_sitio1 = @"Provider=SQLNCLI11;Server=DESKTOP-3MOFSQA\SQLEXPRESS;Database=ESQUEMA_LOCALIZACION;Trusted_Connection=yes;";
            OleDbConnection conexion = new OleDbConnection(conexion_sitio1);
            conexion.Open();

            return conexion;
        }

        public clase_conexion()
        {
            
        }
        
    }
}
