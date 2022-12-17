using Entities.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    /// <summary>
    /// IEntity class'ından miras alan Entity nesneleri için üretilecek Dal sınıflarında kullanılmak üzere oluşturulmuştur.
    /// </summary>
    /// <typeparam name="T">EntityNesnesi</typeparam>
    public interface IEntityRepository<T> where T:class,IEntity,new()
    {
        List<T> GetAll(Expression<Func<T,bool>> filter=null);
        T Get(Expression<Func<T, bool>> filter);
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}
