using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;

namespace MedManager.Models
{
    public class MedManagerContext : DbContext
    {
        
        public MedManagerContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<MedTakeModel> Take { get; set; }
    }

}
