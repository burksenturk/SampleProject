using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleProject.Core.Entity
{
    public class City : BaseEntity
    {
        public string Name { get; set; }

        public int CountryId { get; set; }

        public virtual Country Country { get; set; }

    }
}
