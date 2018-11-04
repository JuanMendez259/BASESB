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
    public class conexion
    {
        /*VARIABLES DE CONEXCION*/
        private OleDbCommand comando;
        private OleDbDataAdapter adaptador;
        private DataSet datos;
        private OleDbDataReader Leer;
        private OleDbConnection conn;/* = new OleDbConnection
            (@"Provider=SQLNCLI11;Server=DESKTOP-3MOFSQA\SQLEXPRESS;Database=SHESAT;Trusted_Connection=yes;");*/

        public conexion()
        {
            conn = new OleDbConnection
            (@"Provider=SQLNCLI11;Server=DESKTOP-3MOFSQA\SQLEXPRESS;Database=SHESAT;Trusted_Connection=yes;");
        }
    }
}
