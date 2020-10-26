using Leilao.Data.Context;
using Leilao.Domain.Entities.Standard;
using Leilao.Domain.Helppers;
using Leilao.Domain.Interfaces.Repositories.Standard;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Leilao.Data.Repositories.Standard
{
    public class Repository<Entity> : IRepository<Entity> where Entity : BaseEntity
    {
        protected readonly PublicSaleContext _context;
        protected DbSet<Entity> _dataset;

        public Repository(PublicSaleContext context)
        {
            _context = context;            
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            try
            {
                var result = await _dataset.SingleOrDefaultAsync(p => p.Id.Equals(id));
                if (result == null)
                {
                    return false;
                }

                _dataset.Remove(result);
                await _context.SaveChangesAsync();
                return true;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> ExistAsync(Guid id)
        {
            return await _dataset.AnyAsync(p => p.Id.Equals(id));
        }

        public async Task<Entity> InsertAsync(Entity item)
        {
            try
            {
                if (item.Id == Guid.Empty)
                {
                    item.Id = Guid.NewGuid();
                }

                item.CreateAt = Helpers.GetDateTimeBrasilian();
                item.UpdateAt = Helpers.GetDateTimeBrasilian();
                _dataset.Add(item);

                await _context.SaveChangesAsync();

            }
            catch (Exception ex)
            {
                throw ex;
            }

            return item;
        }

        public async Task<Entity> SelectAsync(Guid id)
        {
            try
            {
                return await _dataset.SingleOrDefaultAsync(p => p.Id.Equals(id));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<IEnumerable<Entity>> SelectAsync()
        {
            try
            {
                return await _dataset.ToListAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<IEnumerable<Entity>> SelectAsync(Expression<Func<Entity, bool>> condition)
        {
            try
            {
                return await _dataset.Where(condition).ToListAsync<Entity>();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Entity> UpdateAsync(Entity item)
        {
            try
            {
                var result = await _dataset.SingleOrDefaultAsync(p => p.Id.Equals(item.Id));
                if (result == null)
                {
                    return null;
                }

                item.UpdateAt = Helpers.GetDateTimeBrasilian();
                item.CreateAt = result.CreateAt;

                _context.Entry(result).CurrentValues.SetValues(item);
                await _context.SaveChangesAsync();

            }
            catch (Exception ex)
            {
                throw ex;
            }

            return item;
        }
    }
}
