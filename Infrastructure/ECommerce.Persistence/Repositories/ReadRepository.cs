using ECommerce.Application.Repositories;
using ECommerce.Domain.Entities.Common;
using ECommerce.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace ECommerce.Persistence.Repositories
{
    public class ReadRepository<T> : IReadRepository<T> where T : BaseEntity
    {
        private readonly ECommerceDbContext context;

        public ReadRepository(ECommerceDbContext context)
        {
            this.context = context;
        }

        public DbSet<T> Table => context.Set<T>();

        public IQueryable<T> GetAll()
        {
            return Table;
        }

        public IQueryable<T> GetWhere(Expression<Func<T, bool>> method)
        {
           return Table.Where(method);
        }

        public async Task<T> GetByIdAsync(string id) => await Table.FindAsync(Guid.Parse(id));
            //Table.FirstOrDefaultAsync(t => t.Id == Guid.Parse(id));

        public async Task<T> GetSingleAsync(Expression<Func<T, bool>> method) => await Table.FirstOrDefaultAsync(method);

    }
}
