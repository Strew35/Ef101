using Business.Abstract;
using Entities.Concrete;
using DataAccess.Abstract;
using Entities.DTOs;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;

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
            _productDal.Add(product);
            return new Result(true);
        }

        public IResult Delete(int id)
        {
            var entityToDelete = _productDal.Get(x => x.ProductId == id);
            _productDal.Delete(entityToDelete);
            return new Result(true);
        }

        public List<Product> GetAll()
            => _productDal.GetAll();

        public List<Product> GetByCategoryId(int id)
            => _productDal.GetAll(x => x.CategoryId == id);

        public Product GetById(int productId)
            => _productDal.Get(x => x.ProductId == productId);

        public List<Product> GetByUnitPrice(decimal min, decimal max)
            => _productDal.GetAll(x => min <= x.UnitPrice && x.UnitPrice <= max);

        public List<ProductDetailDto> GetProductDetails()
            => _productDal.GetProductDetails();

        public IResult Update(Product product)
        {
            _productDal.Update(product);
            return new Result(true);
        }
    }
}
