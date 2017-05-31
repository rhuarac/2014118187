using _2014118187_ENT.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2014118187_PER.Entities
{
    public class TecladoConfiguration : EntityTypeConfiguration<Teclado>
    {
         public TecladoConfiguration()
        {
            ToTable("Teclado");
            HasKey(c => c.TecladoId);
        }
    }
}
