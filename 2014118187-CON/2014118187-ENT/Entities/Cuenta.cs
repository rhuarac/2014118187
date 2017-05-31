using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2014118187_ENT.Entities
{
    public class Cuenta
    {
        public int NumeroCuenta { get; set; }
        public int Pin { get; set; }

        //Base de Datos
        public int BaseDatosId { get; set; }
        public BasedeDatos BasedeDatos { get; set; }
    }
}
