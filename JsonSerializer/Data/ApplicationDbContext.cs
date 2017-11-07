using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using JsonSerilizerASP.Models;

namespace JsonSerilizerASP.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<PropertyData> Properties { get; set; }

        public ApplicationDbContext(DbContextOptions options)
            : base(options)
        {
            
        }
    }
}
