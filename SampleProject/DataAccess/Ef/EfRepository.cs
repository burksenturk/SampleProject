using Microsoft.EntityFrameworkCore;
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
    public class EfRepository<TEntity> : IRepository<TEntity> where TEntity : class,IBaseEntity,new()
    {
        private readonly DbContext _context;

        public EfRepository(DbContext context)
        {
            _context = context;
        }

        public async Task<BaseResponse<TEntity>> Create(TEntity entity)
        {
            try
            {
                var Entryed = _context.Entry(entity);
                Entryed.State = EntityState.Added;
                await _context.SaveChangesAsync();
                return new BaseResponse<TEntity>() { Status = true, Data = Entryed.Entity };
            }
            catch (Exception ex)
            {

                return new BaseResponse<TEntity>() { Status = false, Data = null, ErrorMessage = ex.ToString() };

            }
        }

        public async Task<BaseResponse<TEntity>> Delete(TEntity entity)
        {
            try
            {
                var Entryed = _context.Entry(entity);
                Entryed.State = EntityState.Deleted;
                await _context.SaveChangesAsync();
                return new BaseResponse<TEntity>() { Status = true, Data = Entryed.Entity };
            }
            catch (Exception ex)
            {

                return new BaseResponse<TEntity>() { Status = false, Data = null, ErrorMessage = ex.ToString() };

            }
        }

        public async Task<BaseResponse<TEntity>> Get(Expression<Func<TEntity, bool>> filter, params Expression<Func<TEntity, object>>[] inculudes)
        {
            try
            {
                IQueryable<TEntity> query = _context.Set<TEntity>();
                if (inculudes.Length > 0)
                {
                    foreach (var item in inculudes)
                    {
                        query = query.Include(item);
                    }
                }

                var result = await query.AsNoTracking().FirstOrDefaultAsync(filter);

                if (result == null)
                {
                    return new BaseResponse<TEntity>() { Status = false, Data = null, ErrorMessage = "ilgili sorguya ait kayıt bulunamadı!" };
                }
                else
                {
                    return new BaseResponse<TEntity>() { Status = true, Data = result };

                }
            }
            catch (Exception ex)
            {
                return new BaseResponse<TEntity>() { Status = false, Data = null, ErrorMessage = ex.ToString() };

            }
        }


        public async Task<BaseResponse<List<TEntity>>> GetAllByFilter(Expression<Func<TEntity, bool>> filter = null, params Expression<Func<TEntity, object>>[] inculudes )
        {
            try
            {
                IQueryable<TEntity> query = _context.Set<TEntity>();
                if (inculudes.Length > 0)
                {
                    foreach (var item in inculudes)
                    {
                        query = query.Include(item);
                    }
                }
                if (filter != null)
                {
                    query = query.Where(filter);
                }

                var result = await query.AsNoTracking().ToListAsync();

                if (result == null)
                {
                    return new BaseResponse<List<TEntity>>() { Status = false, Data = null, ErrorMessage = "ilgili sorguya ait kayıt bulunamadı!" };
                }
                else
                {
                    return new BaseResponse<List<TEntity>>() { Status = true, Data = result };

                }
            }
            catch (Exception ex)
            {
                return new BaseResponse<List<TEntity>>() { Status = false, Data = null, ErrorMessage = ex.ToString() };

            }
        }

        public async Task<BaseResponse<TEntity>> Update(TEntity entity)
        {
            try
            {
                var Entryed = _context.Entry(entity);
                Entryed.State = EntityState.Modified;
                await _context.SaveChangesAsync();
                return new BaseResponse<TEntity>() { Status = true, Data = Entryed.Entity };
            }
            catch (Exception ex)
            {

                return new BaseResponse<TEntity>() { Status = false, Data = null, ErrorMessage = ex.ToString() };

            }
        }
    }
}
