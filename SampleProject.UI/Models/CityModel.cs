using SampleProject.Core.Entity;

namespace SampleProject.UI.Models
{
    public class CityModel
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public int CountryId { get; set; }

        public  Country Country { get; set; }
    }
}
