using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryProductDal : IProductDal
    {
        List<Product> _products;
        public InMemoryProductDal()
        {
            _products = new()
            {
                new(){ProductID=1,ProductName="Elma",UnitPrice=100,CategoryID=1,UnitsInStock=10},
                new(){ProductID=2,ProductName="Armut",UnitPrice=100,CategoryID=1,UnitsInStock=12},
                new(){ProductID=3,ProductName="Koltuk",UnitPrice=100,CategoryID=2,UnitsInStock=13}
            };
        }
        public void Add(Product product)
        {
            _products.Add(product);
        }

        public void Delete(Product product)
        {
            Product? productToDelete=_products.FirstOrDefault(p => p.ProductID == product.ProductID);
            _products.Remove(productToDelete);
        }

        public Product Get(Expression<Func<Product, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Product> GetAll()
        {
            return _products;
        }

        public List<Product> GetAll(Expression<Func<Product, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public List<Product> GetAllByCategory(int categoryID)
        {
            return _products.Where(p=>p.CategoryID== categoryID).ToList();
        }

        public void Update(Product product)
        {
            Product? productToUpdate = _products.FirstOrDefault(p => p.ProductID == product.ProductID);
            productToUpdate.ProductName=product.ProductName;
            productToUpdate.UnitPrice=product.UnitPrice;
            productToUpdate.CategoryID=product.CategoryID;
            productToUpdate.UnitsInStock=product.UnitsInStock;
        }
    }
}
