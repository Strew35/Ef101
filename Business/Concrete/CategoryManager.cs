using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;

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
