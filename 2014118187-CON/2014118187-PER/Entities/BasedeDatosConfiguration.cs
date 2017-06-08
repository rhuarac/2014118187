using _2014118187_ENT.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2014118187_PER.Entities
{
    public class BasedeDatosConfiguration : EntityTypeConfiguration<BasedeDatos>
    {
        public BasedeDatosConfiguration()
        {
            ToTable("Base de Datos");
            HasKey(c => c.BasedeDatosId);
            Property(c => c.AutentificarCuenta);
            Property(c => c.ObtenerSaldoDisponible);
            Property(c => c.ObtenerSaldoTotal);
            Property(c => c.Debitar);
            Property(c => c.Acreditar);






        }
    }
}
