using Core.Entities;
using System.Linq.Expressions;

namespace Core.DataAccess
{
    /// <summary>
    /// IEntity class'ından miras alan Entity nesneleri için üretilecek Dal sınıflarında kullanılmak üzere oluşturulmuştur.
    /// </summary>
    /// <typeparam name="T">EntityNesnesi</typeparam>
    public interface IEntityRepository<TEntity> where TEntity : class, IEntity, new()
    {
        List<TEntity> GetAll(Expression<Func<TEntity, bool>>? filter = null);
        TEntity Get(Expression<Func<TEntity, bool>> filter);
        void Add(TEntity entity);
        void Update(TEntity entity);
        void Delete(TEntity entity);
    }
}
