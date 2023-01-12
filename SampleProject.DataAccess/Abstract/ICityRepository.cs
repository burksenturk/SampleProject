using SampleProject.Core.DataAccess.Ef;
using SampleProject.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleProject.DataAccess.Abstract
{
    public interface ICityRepository : IRepository<City>
    {

    }
}
