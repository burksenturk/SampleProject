using AutoMapper;
using SampleProject.Business.Abstract;
using SampleProject.Core.Entity;
using SampleProject.Core.Model;
using SampleProject.Core.Model.Request.City;
using SampleProject.DataAccess.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SampleProject.Business.Concrate
{
    public class CityService : ICityService
    {
        private readonly ICityRepository _cityRepository;
        private readonly IMapper _mapper;

        public CityService(ICityRepository cityRepository, IMapper mapper)
        {
            _cityRepository = cityRepository;
            _mapper = mapper;
        }

        public async Task<BaseResponse<City>> Create(CityCreateRequest cityCreateRequest)
        {
            City city = _mapper.Map<City>(cityCreateRequest);
            var result = await _cityRepository.Create(city);
            return result;
        }

        public async Task<BaseResponse<City>> Delete(int Id)
        {
            var result = await _cityRepository.Get(x=>x.Id == Id);
            return await _cityRepository.Delete(result.Data);
        }

        public async Task<BaseResponse<City>> Get(Expression<Func<City, bool>> filter, params Expression<Func<City, object>>[] inculudes)
        {
            return await _cityRepository.Get(filter, inculudes);
        }

        public async Task<BaseResponse<List<City>>> GetAllByFilter(Expression<Func<City, bool>> filter = null, params Expression<Func<City, object>>[] inculudes)
        {
            return await _cityRepository.GetAllByFilter(filter, inculudes);
        }


        public async Task<BaseResponse<City>> Update(CityUpdateRequest cityUpdateRequest)
        {
            City city = _mapper.Map<City>(cityUpdateRequest);
            return await _cityRepository.Update(city);

        }
    }
}
