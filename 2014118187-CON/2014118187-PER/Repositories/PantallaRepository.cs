using _2014118187_ENT.Entities;
using _2014118187_ENT.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2014118187_PER.Repositories
{
    public class PantallaRepository : Repository<Pantalla>, IPantallaRepository
    {
        public PantallaRepository(_2014118187DbContext context)
            : base(context)
        {

        }
    }
}
