using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Turnos.Models
{
    public class TurnosContext : DbContext
    {
        public TurnosContext(DbContextOptions<TurnosContext>opciones) :base (opciones)
        {

        }
        public DbSet<Especialidad> Especialidad { get; set; }
    }
}
