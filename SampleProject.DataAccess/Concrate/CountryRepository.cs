using SampleProject.Core.DataAccess.Ef;
using SampleProject.Core.Entity;
using SampleProject.DataAccess.Abstract;
using SampleProject.DataAccess.Concrate.Ef.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleProject.DataAccess.Concrate
{
    public class CountryRepository : EfRepository<Country>, ICountryRepository
    {
        private SampleProjectContext _context;

        public CountryRepository(SampleProjectContext context) : base(context)
        {
            _context = context;
        }
    }
}
