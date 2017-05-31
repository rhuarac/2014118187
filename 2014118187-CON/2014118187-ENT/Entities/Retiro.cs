using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2014118187_ENT.Entities
{
    public class Retiro
    {
        public int RetiroId { get; set; }

        //Pantalla
        public int PantallaId { get; set; }
        public Pantalla Pantalla { get; set; }

        //Teclado
        public int TecladoId { get; set; }
        public Teclado Teclado { get; set; }

        //DispensadorEfectivo
        public int DispensadorEfectivoId { get; set; }
        public DispensadorEfectivo DispensadorEfectivo { get; set; }

        //Retiro
        public int BasedeDatosId { get; set; }
        public BasedeDatos BasedeDatos { get; set; }

        //ATM
        public int ATMId { get; set; }
        public ATM ATM { get; set; }
    }
}
