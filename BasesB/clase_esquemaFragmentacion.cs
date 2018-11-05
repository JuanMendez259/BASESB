using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasesB
{
    public class clase_esquemaFragmentacion
    {
        public int c_idFragmento { get; set; }
        public string c_nomFragmento { get; set; }
        public string c_nomTabla { get; set; }
        public string c_tipoFragmento { get; set; }
        public int c_sitio { get; set; }
        public string c_condicion { get; set; }

        public clase_esquemaFragmentacion(int p_idFrag, string p_nomFrag, string p_nomTabla, string p_tipoFrag, int p_sitio, string p_condicion)
        {
            this.c_idFragmento = p_idFrag;
            this.c_nomFragmento = p_nomFrag;
            this.c_nomTabla = p_nomTabla;
            this.c_tipoFragmento = p_tipoFrag;
            this.c_sitio = p_sitio;
            this.c_condicion = p_condicion;
        }
        public clase_esquemaFragmentacion()
        {

        }
    }
}
