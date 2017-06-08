using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2014118187_ENT.Entities
{
    public class RanuraDeposito
    {

        public int RanuraDepositoId { get; set; }
        public int Cantidad { get; set; }

        //ATM
        public int ATMId { get; set; }
        public ATM ATM { get; set; }
    }
}
