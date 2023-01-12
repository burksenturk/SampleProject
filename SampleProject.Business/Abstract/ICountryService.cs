using SampleProject.Core.Entity;
using SampleProject.Core.Model;
using SampleProject.Core.Model.Request.Country;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace SampleProject.Business.Abstract
{
    public interface ICountryService
    {
        Task<BaseResponse<Country>> Create(CountryCreateRequest countryCreateRequest);
        Task<BaseResponse<Country>> Update(CountryUpdateRequest countryUpdateRequest);
        Task<BaseResponse<Country>> Delete(int Id);
        Task<BaseResponse<Country>> Get(Expression<Func<Country, bool>> filter);
        Task<BaseResponse<List<Country>>> GetAllByFilter(Expression<Func<Country, bool>> filter = null);
    }
}
