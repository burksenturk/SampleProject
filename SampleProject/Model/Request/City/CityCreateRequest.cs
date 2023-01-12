using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleProject.Core.Model.Request.City
{
    public class CityCreateRequest
    {
        public string Name { get; set; }
        public int CountryId { get; set; }
    }
}
