using SampleProject.Core.Entity;
using SampleProject.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SampleProject.Core.DataAccess.Ef
{
    public interface IRepository<T> where T : class,IBaseEntity,new()
    {
        Task<BaseResponse<T>> Get(Expression<Func<T, bool>> filter, params Expression<Func<T, object>>[] inculudes);
        Task<BaseResponse<List<T>>> GetAllByFilter(Expression<Func<T, bool>> filter = null, params Expression<Func<T, object>>[] inculudes);
        Task<BaseResponse<T>> Create(T entity);
        Task<BaseResponse<T>> Update(T entity);
        Task<BaseResponse<T>> Delete(T entity);
    }
}
