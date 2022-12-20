using Business.Abstract;
using Business.Constants;
using Core.Concrete.EntityFramework;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class CategoryManager : ICategoryService
    {
        ICategoryDal _categoryDal;
        public CategoryManager(ICategoryDal categoryDal)
        {
            _categoryDal = categoryDal;
        }
        public IDataResult<List<Category>> GetAll()
            => new SuccessDataResult<List<Category>>(_categoryDal.GetAll(), Messages.CategoriesListed);

        public IDataResult<Category> GetById(int id)
            => new SuccessDataResult<Category>(_categoryDal.Get(x => x.CategoryId == id), Messages.CategoryListed);
    }
}
