using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DapperPOC.Models;
using Microsoft.EntityFrameworkCore;

namespace DapperPOC.Data
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options)
        {

        }
        public DbSet<Company> Companies { get; set; }
    }
}
