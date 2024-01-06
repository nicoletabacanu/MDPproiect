using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using proiect.Models;

namespace proiect.Data
{
    public class proiectContext : DbContext
    {
        public proiectContext (DbContextOptions<proiectContext> options)
            : base(options)
        {
        }

        public DbSet<proiect.Models.Pacient> Pacient { get; set; } = default!;

        public DbSet<proiect.Models.Doctor>? Doctor { get; set; }

        public DbSet<proiect.Models.Programare>? Programare { get; set; }

        public DbSet<proiect.Models.Review>? Review { get; set; }
    }
}
