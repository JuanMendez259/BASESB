using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;

namespace BasesB
{
    public class clase_consultas
    {
        public int cont_atributos;
        public string[,] arr_atributos;

        public static List<clase_esquemaFragmentacion> consulta_esquema(string op)
        {
            List<clase_esquemaFragmentacion> lista = new List<clase_esquemaFragmentacion>();

            using (OleDbConnection con = clase_conexion.conexion_esquema())
            {
                String cad_consulta;
                cad_consulta = "SELECT * " +
                                " FROM ESQUEMA_LOCALIZACION";
                OleDbCommand consulta = new OleDbCommand(string.Format(cad_consulta), con);
                OleDbDataReader reader = consulta.ExecuteReader();

                while (reader.Read())
                {
                    clase_esquemaFragmentacion e = new clase_esquemaFragmentacion();

                    e.c_idFragmento=        Convert.ToInt32(reader["IDFRAGMENTO"]);
                    e.c_nomFragmento =      reader["NOMBRE_FRAG"].ToString();
                    e.c_nomTabla =          reader["NOMBRE_TABLA"].ToString();
                    e.c_tipoFragmento =     reader["TIPO_FRAG"].ToString();
                    e.c_sitio =             Convert.ToInt32(reader["SITIO"]);
                    e.c_condicion =         reader["CONDICION"].ToString();

                    if(e.c_nomTabla == op)
                        lista.Add(e);
                }
                con.Close();
            }
                return lista;
        }

        public static string[] consulta_atributos(List<clase_esquemaFragmentacion> op, List<int> cuenta)
        {
            string[] atributos;
            int idFrag = op[0].c_idFragmento;
            string cad="";
            int cont = 0;
            //int cuenta = cuenta[0];
            atributos = new string[cuenta[0]];
                 
            using (OleDbConnection con = clase_conexion.conexion_esquema())
            {
            String cad_consulta2;
            cad_consulta2 = "SELECT A.IDFRAGMENTO, A.NOMBRE_ATRIBUTO " +
                            " FROM ATRIBUTOS AS A, ESQUEMA_LOCALIZACION AS E " +
                            " WHERE E.IDFRAGMENTO = A.IDFRAGMENTO" +
                            " AND E.IDFRAGMENTO="+ idFrag;
            OleDbCommand consulta2 = new OleDbCommand(string.Format(cad_consulta2), con);
            OleDbDataReader reader2 = consulta2.ExecuteReader();
                
            while (reader2.Read())
            {  
                atributos[cont]= reader2["NOMBRE_ATRIBUTO"].ToString();
                cont++;
            }
            con.Close();
            }
            
            return atributos;
        }

        public static List<int> cuenta_atributos(List<clase_esquemaFragmentacion> op)
        {
            List<int> cuenta = new List<int>();
            string[] atributos;
            string cad = "";
            int num_atributos, cont = 0;
            int idFrag = op[0].c_idFragmento;

            using (OleDbConnection con = clase_conexion.conexion_esquema())
            {
                String cad_consulta;
                cad_consulta = "SELECT COUNT(A.NOMBRE_ATRIBUTO) AS 'CUENTA' " +
                                " FROM ATRIBUTOS AS A " +
                                " WHERE A.IDFRAGMENTO =" + idFrag;
                OleDbCommand consulta = new OleDbCommand(string.Format(cad_consulta), con);
                OleDbDataReader reader = consulta.ExecuteReader();

                while (reader.Read())
                {
                    num_atributos = Convert.ToInt32(reader["CUENTA"]);
                    cuenta.Add(num_atributos);
                }
                con.Close();
            }
                return cuenta;
        }

    }
}
