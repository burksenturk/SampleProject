using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using SampleProject.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleProject.DataAccess.Concrate.Ef.Contexts
{
    public class SampleProjectContext : DbContext
    {
        public SampleProjectContext() : base()
        {

        }

        public SampleProjectContext(DbContextOptions<SampleProjectContext> options) : base(options) { }

        public DbSet<City> Cities { get; set; }
        public DbSet<Country> Countries { get; set; }
    }
}
