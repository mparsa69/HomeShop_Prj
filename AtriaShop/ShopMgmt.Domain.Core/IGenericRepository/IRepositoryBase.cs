using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ShopMgmt.Domain.Core.IGenericRepository
{
    public interface IRepositoryBase<TKey,T> where T:class
    {
        void Create(T entity);
        void Update(T entity);
        T Get(TKey id);
        List<T> GetAll();
        bool Exists(Expression<Func<T,bool>> expression);
    }
}
