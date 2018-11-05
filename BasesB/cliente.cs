using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasesB
{
    public class cliente
    {
        public int c_idCliente { get; set; }
        public string c_nomCliente { get; set; }
        public string c_apellidoP { get; set; }
        public string c_apellidoM { get; set; }
        public DateTime c_fechaNacimiento { get; set; }
        public string c_numContacto { get; set; }

        public cliente(int p_idCliente, string p_nomCliente, string p_apellidoP, string p_apellidoM, DateTime p_fechaNac, string p_numContacto)
        {
            this.c_idCliente = p_idCliente;
            this.c_nomCliente = p_nomCliente;
            this.c_apellidoP = p_apellidoP;
            this.c_apellidoM = p_apellidoM;
            this.c_fechaNacimiento = p_fechaNac;
            this.c_numContacto = p_numContacto;
        }
        public cliente()
        {

        }

    }
}
