using AutoMapper;
using SampleProject.Core.Entity;
using SampleProject.Core.Model.Request.City;
using SampleProject.Core.Model.Request.Country;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleProject.Business.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CityCreateRequest, City>();
            CreateMap<CityUpdateRequest, City>();
            CreateMap<CountryCreateRequest, Country>();
            CreateMap<CountryUpdateRequest, Country>();
        }
    }
}
