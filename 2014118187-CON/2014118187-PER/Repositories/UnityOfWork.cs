using _2014118187_ENT.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2014118187_PER.Repositories
{
    public class UnityOfWork: IUnityofWork
    {
        private readonly _2014118187DbContext _Context;
        private static UnityOfWork _Instance;
        private static readonly object _Lock = new object();

        public IATMRepository ATM { get; private set; }

        public IBasedeDatosRepository BasedeDatos { get; private set; }

        public ICuentaRepository Cuenta { get; private set; }

        public IPantallaRepository Pantalla { get; private set; }

        public IRanuraDepositoRepository RanuraDeposito { get; private set; }

        public IRetiroRepository Retiro { get; private set; }

        public ITecladoRepository Teclado { get; private set; }

        public IDispensadorEfectivoRepository DispensadorEfectivo { get; private set; }


        public UnityOfWork(_2014118187DbContext context)
        {
            _Context= context;

            ATM = new ATMRepository(_Context);
            Teclado = new TecladoRepository(_Context);
            Pantalla = new PantallaRepository(_Context);
            Retiro = new RetiroRepository(_Context);
            DispensadorEfectivo = new DispensadorEfectivoRepository(_Context);
            RanuraDeposito = new RanuraDepositoRepository(_Context);
            Cuenta = new CuentaRepository(_Context);
            BasedeDatos = new BasedeDatosRepository(_Context);

        }
        
        


        public void Dispose()
        {
            _Context.Dispose();
        }

        public int SaveChanges()
        {
           return  _Context.SaveChanges();
        }


        public void StateModified(object Entity)
        {
            _Context.Entry(Entity).State = System.Data.Entity.EntityState.Modified;
        }




        public static UnityOfWork Instance { get; set; }
    }
}
