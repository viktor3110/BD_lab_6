using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab6.Models
{
    public class DiskRentalContext : DbContext
    {
        public DiskRentalContext(DbContextOptions<DiskRentalContext> options)
            : base(options)
        {
        }

        public DbSet<Client> Clients { get; set; }
        public DbSet<RentalRecord> RentalRecords { get; set; }
        public DbSet<Disc> Discs { get; set; }
        public DbSet<Employee> Employees { get; set; }
    }
}
