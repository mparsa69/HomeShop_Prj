using ShopMgmt.Domain.Core.IGenericRepository;
using ShopMgmt.Infrastructure.Database.SqlServer.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopMgmt.Ifrastructure.Repositories.EfCore.GenericRepo
{
    public class RepositoryBase<TKey, T> : IRepositoryBase<TKey, T> where T:class
    {
        private readonly AppDbContext _dbContext;

        public RepositoryBase(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Create(T entity)
        {
            _dbContext.Add<T>(entity);
            _dbContext.SaveChanges();
        }

        public bool Exists(System.Linq.Expressions.Expression<Func<T, bool>> expression)
        {
            return _dbContext.Set<T>().Any(expression);
        }

        public T Get(TKey id)
        {
            return _dbContext.Find<T>(id); 
        }

        public List<T> GetAll()
        {
            return _dbContext.Set<T>().ToList();
        }

        public void Update(T entity)
        {
            _dbContext.Update<T>(entity);
            _dbContext.SaveChanges();
        }
    }
}
