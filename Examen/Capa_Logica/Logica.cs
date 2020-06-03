using Capa_Datos;
using System;
using System.Collections.Generic;
using System.Data.Odbc;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Capa_Logica
{
    public class Logica
    {
        Sentencias sn = new Sentencias();
        public OdbcDataReader consultageneral(string tabla)
        {
            return sn.consultageneral(tabla);
        }

        public OdbcDataReader consultaActivo()
        {
            return sn.consultaActivos();
        }
    }

}
