using SampleProject.Core.Entity;
using System.Collections.Generic;

namespace SampleProject.UI.Models
{
    public class CityUpdateModel
    {
        public List<CountryModel> Countries { get; set; }
        public City City { get; set; }
    }
}
