using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2014118187_ENT.Entities
{
    public class DispensadorEfectivo
    {
        public int DispensadorEfectivoId { get; set; }
        private int cont = 100;

        //ATM
        public int ATMId { get; set; }
        public ATM ATM { get; set; }

        //Retiro
        public int RetiroId { get; set; }
        public Retiro Retiro { get; set; }
    }
}
