using SampleProject.Core.Entity;
using SampleProject.Core.Model.Request.City;
using SampleProject.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SampleProject.Business.Abstract
{
    public interface ICityService
    {
        Task<BaseResponse<City>> Create(CityCreateRequest cityCreateRequest);
        Task<BaseResponse<City>> Update(CityUpdateRequest cityUpdateRequest);
        Task<BaseResponse<City>> Delete(int Id);
        Task<BaseResponse<City>> Get(Expression<Func<City, bool>> filter, params Expression<Func<City, object>>[] inculudes);
        Task<BaseResponse<List<City>>> GetAllByFilter(Expression<Func<City, bool>> filter = null, params Expression<Func<City, object>>[] inculudes);
    }
}
