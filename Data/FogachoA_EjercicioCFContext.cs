using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using FogachoA_EjercicioCF.Models;

namespace FogachoA_EjercicioCF.Data
{
    public class FogachoA_EjercicioCFContext : DbContext
    {
        public FogachoA_EjercicioCFContext (DbContextOptions<FogachoA_EjercicioCFContext> options)
            : base(options)
        {
        }

        public DbSet<FogachoA_EjercicioCF.Models.Burguer> Burguer { get; set; } = default!;
    }
}
