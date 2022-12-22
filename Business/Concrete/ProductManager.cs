using Business.Abstract;
using Entities.Concrete;
using DataAccess.Abstract;
using Entities.DTOs;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using Business.Constants;
using FluentValidation;
using Business.ValidationRules.FluentValidation;

namespace Business.Concrete
{
    public class ProductManager : IProductService
    {
        IProductDal _productDal;
        public ProductManager(IProductDal productDal)
        {
            _productDal = productDal;
        }

        public IResult Add(Product product)
        {
            try
            {
                var context=new ValidationContext<Product>(product);
                ProductValidator productValidatior=new ProductValidator();
                var result=productValidatior.Validate(context);
                if (!result.IsValid) throw new ValidationException(result.Errors);

                _productDal.Add(product);
                return new SuccessResult(Messages.ProductAdded);
            }
            catch (Exception ex)
            {
                return new ErrorResult(Messages.ProductCouldNotBeAdded);
            }
        }

        public IResult Delete(int id)
        {
            try
            {
                var entityToDelete = _productDal.Get(x => x.ProductId == id);
                _productDal.Delete(entityToDelete);
                return new SuccessResult(Messages.ProductDeleted);
            }
            catch (Exception ex)
            {
                return new ErrorResult(Messages.ProductCouldNotBeDeleted);
            }
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
            try
            {
                if (product.ProductName.Length < 5) return new ErrorResult(Messages.ProductNameInvalid);
                _productDal.Update(product);
                return new SuccessResult(Messages.ProductUpdated);
            }
            catch (Exception ex)
            {
                return new ErrorResult(Messages.ProductCouldNotBeDeleted);
            }
        }
    }
}
