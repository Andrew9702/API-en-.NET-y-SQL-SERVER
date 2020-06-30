using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace RestApiASP.Models
{
    public class BaseContext : DbContext
    {
        public BaseContext(DbContextOptions<BaseContext> options)
            : base(options)
        {
        }

        public DbSet<Libro> Libros { get; set; }

        public DbSet<Revista> Revistas { get; set; }
    }
}
