using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2014118187_ENT.Entities
{
    public class BasedeDatos
    {
        public int BasedeDatosId { get; set; }
        public bool AutentificarCuenta { get; set; }
        public decimal ObtenerSaldoDisponible { get; set; }
        public decimal ObtenerSaldoTotal { get; set; }
        public decimal Debitar { get; set; }
        public decimal Acreditar { get; set; }
        //Cuenta
        public int CuentaId { get; set; }
        public List<Cuenta> Cuentas { get; set; }
        //ATM
        public int ATMId { get; set; }
        public ATM ATM { get; set; }
        //Retiro
        public int RetiroId { get; set; }
        public Retiro Retiro { get; set; }

        //Creacion de Lista

        public BasedeDatos()
        {
            Cuentas = new List<Cuenta>();
        }
    }
}
