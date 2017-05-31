using _2014118187_ENT.Entities;
using _2014118187_ENT.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2014118187_PER.Repositories
{
    public class CuentaRepository : Repository<Cuenta>, ICuentaRepository
    {
        public CuentaRepository(_2014118187DbContext context): base(context)
        {

        }
    }
}
