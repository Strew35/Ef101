using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Business;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;

namespace Business.Concrete
{
    public class ProductManager : IProductService
    {
        IProductDal _productDal;
        ICategoryService _categoryService;
        public ProductManager(IProductDal productDal, ICategoryService categoryService)
        {
            _productDal = productDal;
            _categoryService = categoryService;
        }

        [ValidationAspect(typeof(ProductValidator))]
        public IResult Add(Product product)
        {
            IResult result = BusinessRules.Run(
                CheckIfProductCountOfCategoryControl(product.CategoryId),
                CheckIfProductNameDuplicationControl(product.ProductName),
                CheckIfCategoryLimitControl()
                );
            if (result.Success == false)
            {
                return result;
            }

            _productDal.Add(product);
            return new SuccessResult(Messages.ProductAdded);
        }

        public IResult Delete(int id)
        {
            Product entityToDelete = _productDal.Get(x => x.ProductId == id);
            _productDal.Delete(entityToDelete);
            return new SuccessResult(Messages.ProductDeleted);
        }

        public IDataResult<List<Product>> GetAll()
            => /*DateTime.Now.Hour==11? new ErrorDataResult<List<Product>>( Messages.MaintanceTime):*/new SuccessDataResult<List<Product>>(_productDal.GetAll(), Messages.ProductsListed);

        public IDataResult<List<Product>> GetByCategoryId(int id)
            => new SuccessDataResult<List<Product>>(_productDal.GetAll(x => x.CategoryId == id), Messages.ProductsListed);

        public IDataResult<Product> GetById(int productId)
            => new SuccessDataResult<Product>(_productDal.Get(x => x.ProductId == productId), Messages.ProductListed);

        public IDataResult<List<Product>> GetByUnitPrice(decimal min, decimal max)
            => new SuccessDataResult<List<Product>>(_productDal.GetAll(x => min <= x.UnitPrice && x.UnitPrice <= max), Messages.ProductsListed);

        public IDataResult<List<ProductDetailDto>> GetProductDetails()
            => new SuccessDataResult<List<ProductDetailDto>>(_productDal.GetProductDetails(), Messages.ProductsListed);

        public IResult Update(Product product)
        {
            var result = BusinessRules.Run(
                CheckIfProductCountOfCategoryControl(product.CategoryId),
                CheckIfProductNameDuplicationControl(product.ProductName),
                CheckIfCategoryLimitControl()
                );
            if (result.Success==false)
            {
                return result;
            }

            _productDal.Update(product);
            return new SuccessResult(Messages.ProductUpdated);
        }

        private IResult CheckIfProductCountOfCategoryControl(int categoryId)
        {
            uint maximumProductCountInCategory = 10;
            return _productDal.GetAll(x => x.CategoryId == categoryId).Count <= maximumProductCountInCategory
                ? new SuccessResult()
                : new ErrorResult(Messages.ProductCountOfCategoryError);
        }
        private IResult CheckIfProductNameDuplicationControl(string productName)
        {
            return !_productDal.GetAll(x => x.ProductName == productName).Any()
                ? new SuccessResult()
                : new ErrorResult(Messages.ProductNameDuplicationError);
        }
        private IResult CheckIfCategoryLimitControl()
        {
            return _categoryService.GetAll().Data.Select(x => x.CategoryId).Count() < 2
                ? new SuccessResult()
                : new ErrorResult(Messages.CategoryLimitExceed);
        }
    }
}
