using Business.Abstract;
using Entities.Concrete;
using DataAccess.Abstract;
using Entities.DTOs;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using Business.Constants;

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
            if (product.ProductName.Length < 5) return new ErrorResult(Messages.ProductNameInvalid);
            _productDal.Add(product);
            return new SuccessResult(Messages.ProductAdded);
        }

        public IResult Delete(int id)
        {
            var entityToDelete = _productDal.Get(x => x.ProductId == id);
            _productDal.Delete(entityToDelete);
            return new SuccessResult(Messages.ProductDeleted);
        }

        public IDataResult<List<Product>> GetAll()
            => new SuccessDataResult<List<Product>>(_productDal.GetAll(), Messages.ProductsListed);

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
            if (product.ProductName.Length < 5) return new ErrorResult(Messages.ProductNameInvalid);
            _productDal.Update(product);
            return new SuccessResult(Messages.ProductUpdated);
        }
    }
}
