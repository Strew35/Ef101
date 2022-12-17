using Business.Abstract;
using Core.DataAccess;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Abstract;

namespace Business.Concrete
{
    public class ProductManager : IProductService
    {
        IProductDal _productDal;
        public ProductManager(IProductDal productDal)
        {
            _productDal = productDal;
        }
        public List<Product> GetAll()
            => _productDal.GetAll();

        public List<Product> GetByCategoryId(int id) 
            => _productDal.GetAll(x => x.CategoryID == id);

        public List<Product> GetByUnitPrice(decimal min, decimal max)
            => _productDal.GetAll(x => min <= x.UnitPrice && x.UnitPrice <= max);
    }
}
