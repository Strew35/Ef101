using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface ICategoryDal:IEntityRepository<Category>
    {
        List<Category> GetAll();
        void Add(Category product);
        void Update(Category product);
        void Delete(Category product);
        List<Category> GetAllByCategory(int categoryID);
    }
}
