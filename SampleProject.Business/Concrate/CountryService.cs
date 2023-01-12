using AutoMapper;
using SampleProject.Business.Abstract;
using SampleProject.Core.Entity;
using SampleProject.Core.Model;
using SampleProject.Core.Model.Request.Country;
using SampleProject.DataAccess.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SampleProject.Business.Concrate
{
    public class CountryService : ICountryService
    {
        private readonly ICountryRepository _countryRepository;
        private readonly IMapper _mapper;

        public CountryService(ICountryRepository countryRepository, IMapper mapper)
        {
            _countryRepository = countryRepository;
            _mapper = mapper;
        }

        public async Task<BaseResponse<Country>> Create(CountryCreateRequest countryCreateRequest)
        {
            Country country = _mapper.Map<Country>(countryCreateRequest);
            var result = await _countryRepository.Create(country);
            return result;
        }

        public async Task<BaseResponse<Country>> Delete(int Id)
        {
            var result = await _countryRepository.Get(x => x.Id == Id);
            return await _countryRepository.Delete(result.Data);
        }

        public async Task<BaseResponse<Country>> Get(Expression<Func<Country, bool>> filter)
        {
            return await _countryRepository.Get(filter);
        }

        public async Task<BaseResponse<List<Country>>> GetAllByFilter(Expression<Func<Country, bool>> filter)
        {
            return await _countryRepository.GetAllByFilter(filter);
        }


        public async Task<BaseResponse<Country>> Update(CountryUpdateRequest countryUpdateRequest)
        {
            Country country = _mapper.Map<Country>(countryUpdateRequest);
            return await _countryRepository.Update(country);

        }
    }
}
